using System;
using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public class ProcessorThreadPool : IProcessorThreadPool
    {
        private readonly string name;
        private readonly IProcessorFactory processorFactory;
        private readonly int threadCount;
        private readonly List<ProcessorThread> threads = new List<ProcessorThread>();
        private bool disposed;
        private bool started;

        public ProcessorThreadPool(string name, int threadCount, IProcessorFactory processorFactory)
        {
            this.name = name;
            this.threadCount = threadCount;
            this.processorFactory = processorFactory;
        }

        public void Pause()
        {
            foreach (var thread in threads)
            {
                thread.Stop();
            }

            Log.For(this).Information(string.Format(InfrastructureResources.TaskPoolStatusChange, name, "paused"));
        }

        public void Resume()
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }

            Log.For(this).Information(string.Format(InfrastructureResources.TaskPoolStatusChange, name, "resumed"));
        }

        public IProcessorThreadPool Start()
        {
            if (started)
            {
                return this;
            }

            if (threadCount < 1)
            {
                throw new ThreadCountZeroException();
            }

            StartThreads();

            started = true;

            Log.For(this).Information(string.Format(InfrastructureResources.TaskPoolStatusChange, name, "started"));

            return this;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void StartThreads()
        {
            var i = 0;

            while (i++ < threadCount)
            {
                var thread = new ProcessorThread(processorFactory.Create());

                threads.Add(thread);

                thread.Start();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (var thread in threads)
                {
                    thread.Deactivate();
                }

				foreach (var thread in threads)
				{
					thread.Stop();
				}
			}

            disposed = true;
        }
    }
}