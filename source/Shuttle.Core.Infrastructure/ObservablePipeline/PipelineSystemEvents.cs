using System;

namespace Shuttle.Core.Infrastructure
{
	public class OnPipelineException : PipelineEvent
	{
		public OnPipelineException(Exception exception)
		{
			Exception = exception;
		}

		public OnPipelineException()
		{
		}
	}

	public class OnAbortPipeline : PipelineEvent
	{
	}
}