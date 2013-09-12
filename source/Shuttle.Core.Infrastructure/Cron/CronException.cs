using System;

namespace Shuttle.Core.Infrastructure
{
	public class CronException : Exception
	{
		public CronException(string message) : base(message)
		{
		}
	}
}