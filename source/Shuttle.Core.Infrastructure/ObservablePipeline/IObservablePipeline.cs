namespace Shuttle.Core.Infrastructure
{
	public interface IObservablePipeline
	{
	    State<IObservablePipeline> State { get; }
		IExecuteEventThen OnExecuteRaiseEvent(PipelineEvent pipelineEvent);
		IExecuteEventThen OnExecuteRaiseEvent<TPipelineEvent>() where TPipelineEvent : PipelineEvent, new();
		IRegisterObserverAnd RegisterObserver(IObserver observer);
		RegisterEventBefore BeforeEvent<TPipelineEvent>() where TPipelineEvent : PipelineEvent, new();
		RegisterEventAfter AfterEvent<TPipelineEvent>() where TPipelineEvent : PipelineEvent, new();
	}
}