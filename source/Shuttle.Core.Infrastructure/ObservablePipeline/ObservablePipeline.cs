using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shuttle.Core.Infrastructure
{
	public enum PipelineStages
	{
		Entry = 0
	}

	public class ObservablePipeline
	{
		protected readonly List<IObserver> observers = new List<IObserver>();
		protected readonly Dictionary<string, List<IObserver>> observeEvents = new Dictionary<string, List<IObserver>>();
		protected readonly List<PipelineStage> stages = new List<PipelineStage>();

		private readonly OnPipelineStarting onPipelineStarting = new OnPipelineStarting();
		private readonly OnAbortPipeline onAbortPipeline = new OnAbortPipeline();
		private readonly OnPipelineException onPipelineException = new OnPipelineException();

		private readonly string FirstChanceExceptionHandledByPipeline =
			InfrastructureResources.FirstChanceExceptionHandledByPipeline;

		private readonly string ExecutingPipeline = InfrastructureResources.ExecutingPipeline;
		private readonly string EnteringPipelineStage = InfrastructureResources.EnteringPipelineStage;
		private readonly string RaisingPipelineEvent = InfrastructureResources.RaisingPipelineEvent;

		public Guid Id { get; private set; }
		public bool ExceptionHandled { get; internal set; }
		public Exception Exception { get; internal set; }
		public bool Aborted { get; internal set; }
		public string StageName { get; private set; }
		public PipelineEvent Event { get; private set; }

	    private readonly ILog log;

		public ObservablePipeline()
		{
			Id = Guid.NewGuid();
			State = new State<ObservablePipeline>(this);
			onAbortPipeline.Reset(this);
			onPipelineException.Reset(this);

			var stage = new PipelineStage("__PipelineEntry");

			stage.WithEvent(onPipelineStarting);

			stages.Add(stage);

		    log = Log.For(this);
		}

		public ObservablePipeline RegisterObserver(IObserver observer)
		{
			List<IObserver> observerListForEvent;
			observers.Add(observer);
			var observerInterfaces = observer.GetType().GetInterfaces();

			var implementedEvents = from i in observerInterfaces
			                        where i.IsAssignableTo(typeof (IPipelineObserver<>))
			                        select i;

			foreach (var @event in implementedEvents)
			{
				var pipelineEventName = @event.GetGenericArguments()[0].FullName;
				var pipelineEvent = (from observeEvent in observeEvents
				                     where observeEvent.Key == pipelineEventName
				                     select observeEvent).SingleOrDefault();
				if (pipelineEvent.Key == null)
				{
					observeEvents.Add(pipelineEventName, new List<IObserver>());
				}

				observeEvents.TryGetValue(pipelineEventName, out observerListForEvent);
				observerListForEvent.Add(observer);
			}
			return this;
		}

		public State<ObservablePipeline> State { get; private set; }

		public void Abort()
		{
			Aborted = true;
		}

		public void MarkExceptionHandled()
		{
			ExceptionHandled = true;
		}

		public virtual bool Execute()
		{
			var result = true;

			Aborted = false;
			ExceptionHandled = false;
			Exception = null;

			log.Verbose(string.Format(ExecutingPipeline, GetType().FullName));

			foreach (var stage in stages)
			{
				StageName = stage.Name;

				log.Verbose(string.Format(EnteringPipelineStage, StageName));

				foreach (var @event in stage.Events)
				{
					try
					{
						Event = @event;

						RaiseEvent(@event.Reset(this));

						if (Aborted)
						{
							result = false;

							RaiseEvent(onAbortPipeline);

							break;
						}
					}
					catch (Exception ex)
					{
						result = false;

						Exception = ex.TrimLeading<TargetInvocationException>();

						RaiseEvent(onPipelineException, true);

						if (!ExceptionHandled)
						{
							log.Fatal(string.Format(InfrastructureResources.UnhandledPipelineException, @event.Name, ex.CompactMessages()));

							throw;
						}

						log.Verbose(string.Format(FirstChanceExceptionHandledByPipeline, ex.Message));

						if (Aborted)
						{
							RaiseEvent(onAbortPipeline);

							break;
						}
					}
				}

				if (Aborted)
				{
					break;
				}
			}

			return result;
		}

	    private void RaiseEvent(OnAbortPipeline @event)
	    {
            RaiseEvent(@event, true);
	    }

	    private void RaiseEvent(PipelineEvent @event, bool ignoreAbort = false)
		{
			var observersForEvent = (from e in observeEvents
			                         where e.Key == @event.GetType().FullName
			                         select e.Value).SingleOrDefault();

			if (observersForEvent == null || observersForEvent.Count == 0)
			{
				return;
			}

			foreach (var observer in observersForEvent)
			{
				log.Verbose(string.Format(RaisingPipelineEvent, @event.Name, StageName, observer.FullName()));

				observer.GetType().InvokeMember("Execute",
				                                BindingFlags.FlattenHierarchy | BindingFlags.Instance |
				                                BindingFlags.InvokeMethod | BindingFlags.Public, null,
				                                observer,
				                                new[] {@event});

				if (Aborted && !ignoreAbort)
				{
					return;
				}
			}
		}

		public PipelineStage RegisterStage(string name)
		{
			var stage = new PipelineStage(name);

			stages.Add(stage);

			return stage;
		}

		public PipelineStage GetStage(string name)
		{
			var result = stages.Find(stage => stage.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

			Guard.Against<IndexOutOfRangeException>(result == null,
			                                        string.Format(InfrastructureResources.PipelineStageNotFound, name));

			return result;
		}

		public PipelineStage GetStage(PipelineStages stage)
		{
			return GetStage("__PipelineEntry");
		}
	}
}