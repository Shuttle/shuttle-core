using System;

namespace Shuttle.Core.Infrastructure
{
	public struct Range<T>
		where T : IComparable<T>
	{
		public Range(T from, T to)
			: this()
		{
			From = from;
			To = to;

			if (from.CompareTo(to) != -1)
			{
				throw new InvalidOperationException(
					string.Format(InfrastructureResources.RangeException, from, to));
			}
		}

		public T From { get; private set; }
		public T To { get; private set; }
	}
}