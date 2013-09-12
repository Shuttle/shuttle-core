using System;

namespace Shuttle.Core.Infrastructure
{
	public static class EnvironmentExtensions
	{
		public static string FullDomainUser()
		{
			return string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
		}
	}
}