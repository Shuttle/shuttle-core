using System;
using System.Security.Principal;

namespace Shuttle.Core.Infrastructure
{
	public class Impersonation : IDisposable
	{
		private readonly IntPtr token;
		private readonly IntPtr tokenDuplicate;
		private readonly WindowsImpersonationContext impersonationContext;

		public bool ImpersonationFailed { get; private set; }

		private readonly bool impersonating;

		public string Account { get; private set; }

		private Impersonation(bool impersonate, string user, string domain, string password)
		{
			Account = string.Empty;
			ImpersonationFailed = false;

			if (!impersonate)
			{
				Log.For(this).Trace(string.Format(@"Using account: {0}\{1}.", Environment.UserDomainName, Environment.MachineName));

				return;
			}

			Account = string.Format(@"{0}\{1}", domain, user);

			Log.For(this).Trace(string.Format("Impersonating account: {0}", Account));

			if (!NativeMethods.LogonUser(
				user,
				domain,
				password,
				NativeMethods.LogonType.NewCredentials,
				NativeMethods.LogonProvider.Default,
				out token))
			{
				Log.For(this).Trace("--- impersonation failed (LogonUser)");

				ImpersonationFailed = true;

				return;
			}

			if (!NativeMethods.DuplicateToken(
				token,
				NativeMethods.SecurityImpersonationLevel.Impersonation,
				out tokenDuplicate))
			{
				if (token != IntPtr.Zero)
				{
					NativeMethods.CloseHandle(token);
				}

				Log.For(this).Trace("--- impersonation failed (DuplicateToken)");

				ImpersonationFailed = true;

				return;
			}

			impersonationContext = new WindowsIdentity(tokenDuplicate).Impersonate();
			impersonating = true;
		}

		public static Impersonation Impersonate(bool impersonate, string account, string password)
		{
			var user = string.Empty;
			var domain = string.Empty;

			if (impersonate)
			{
				var split = account.Split(new[] { '\\' });

				if (split.Length == 1)
				{
					user = split[0];
				}
				else if (split.Length == 2)
				{
					domain = split[0];
					user = split[1];
				}
				else
				{
					throw new InvalidOperationException(string.Format(InfrastructureResources.AccountInvalid, account));
				}
			}

			return new Impersonation(impersonate, user, domain, password);
		}

		public void Dispose()
		{
			if (!impersonating)
			{
				return;
			}

			if (impersonationContext != null)
			{
				impersonationContext.Undo();
			}

			if (token != IntPtr.Zero)
			{
				NativeMethods.CloseHandle(token);
			}

			if (tokenDuplicate != IntPtr.Zero)
			{
				NativeMethods.CloseHandle(tokenDuplicate);
			}

			Log.For(this).Trace(string.Format("No longer impersonating: {0}", Account));
		}
	}
}