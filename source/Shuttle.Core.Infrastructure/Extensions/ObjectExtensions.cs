using System;

namespace Shuttle.Core.Infrastructure
{
	public static class ObjectExtensions
	{
		public static void AttemptDispose(this object o)
		{
			var disposable = o as IDisposable;

			if (disposable != null)
			{
				disposable.Dispose();
			}
		}

		public static string FullName(this Object instance)
		{
			return instance.GetType().FullName;
		}

		public static bool IsNull(this Object instance)
		{
			return instance == null;
		}
	}
}