using System;

namespace Shuttle.Core.Infrastructure
{
	public class PipelineContextRequiredException : Exception
	{
		public PipelineContextRequiredException(string message) : base(message)
		{
		}
	}
}