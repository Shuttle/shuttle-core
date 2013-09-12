using System;

namespace Shuttle.Core.Infrastructure
{
	public class InterfaceResolutionException : Exception
	{
		public InterfaceResolutionException(Exception innerException,
		                                    Type interfaceThatCouldNotBeResolvedForSomeReason)
			: base(
				string.Format(InfrastructureResources.InterfaceResolutionException,
				              interfaceThatCouldNotBeResolvedForSomeReason.FullName), innerException)
		{
		}
	}
}