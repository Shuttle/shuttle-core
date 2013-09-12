using System;
using System.Collections.Generic;

namespace Shuttle.Core.Domain
{
	public class Cycle<T> : IDisposable
	{
		private readonly IDictionary<IComparable, string> cycle;
		private readonly IComparable id;

		public Cycle(IDictionary<IComparable, string> cycle, IComparable id)
		{
			this.cycle = cycle;
			this.id = id;

			cycle.Add(id, typeof(T).Name);
		}

		public void Dispose()
		{
			cycle.Remove(id);
		}
	}
}