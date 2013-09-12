using System;

namespace Shuttle.Core.Infrastructure
{
	public class DependencyRegistrationException : Exception
	{
		public DependencyRegistrationException(string message) : base(message)
		{
		}
	}
}