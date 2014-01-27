using System.Threading;

namespace Shuttle.Core.Infrastructure
{
	internal class ProcessorThread : IActiveState
	{
		private readonly IProcessor processor;
		private volatile bool active;

		private readonly int threadJoinTimeoutInterval =
			ConfigurationItem<int>.ReadSetting("ThreadJoinTimeoutInterval", 1000).GetValue();

		private Thread thread;

		private readonly ILog log;

		public ProcessorThread(IProcessor processor)
		{
			this.processor = processor;

			log = Log.For(this);
		}

		public void Start()
		{
			if (active)
			{
				return;
			}

			thread = new Thread(Work);

			thread.SetApartmentState(ApartmentState.MTA);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.Normal;

			active = true;

			thread.Start();

			log.Trace(string.Format(InfrastructureResources.TraceProcessorThreadStarting, thread.ManagedThreadId,
			                        processor.GetType().FullName));

			while (!thread.IsAlive && active)
			{
			}

			if (active)
			{
				log.Trace(string.Format(InfrastructureResources.TraceProcessorThreadActive, thread.ManagedThreadId,
				                        processor.GetType().FullName));
			}
		}

		public void Stop()
		{
			log.Trace(string.Format(InfrastructureResources.TraceProcessorThreadStopping, thread.ManagedThreadId,
			                        processor.GetType().FullName));

			active = false;

			if (thread.IsAlive)
			{
				thread.Join(threadJoinTimeoutInterval);
			}
		}

		private void Work()
		{
			while (active)
			{
				log.Verbose(string.Format(InfrastructureResources.VerboseProcessorExecuting, thread.ManagedThreadId,
				                          processor.GetType().FullName));

				processor.Execute(this);
			}

			log.Trace(string.Format(InfrastructureResources.TraceProcessorThreadStopped, thread.ManagedThreadId,
			                        processor.GetType().FullName));
		}

		public bool Active
		{
			get { return active; }
		}

		internal void Deactivate()
		{
			active = false;
		}
	}
}