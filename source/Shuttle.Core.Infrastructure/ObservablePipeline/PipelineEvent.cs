namespace Shuttle.Core.Infrastructure
{
	public abstract class PipelineEvent
	{
		public ObservablePipeline Pipeline { get; private set; }

		public string Name
		{
			get { return GetType().FullName; }
		}

		internal PipelineEvent Reset(ObservablePipeline pipeline)
		{
			Guard.AgainstNull(pipeline, "pipeline");

			Pipeline = pipeline;

			return this;
		}
	}
}