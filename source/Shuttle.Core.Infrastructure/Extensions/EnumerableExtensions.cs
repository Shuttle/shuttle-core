using System;
using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
	public static class EnumerableExtensions
	{
		public static void VisitAllItemsUsing<T>(this IEnumerable<T> items, IVisitor<T> visitor)
		{
			new EnumerableActions<T>(items).VisitAllItemsUsing(visitor);
		}

		public static TResult GetResultOfVisitingAllItemsWith<T, TResult>(this IEnumerable<T> items,
		                                                                  IValueReturningVisitor<TResult, T> visitor)
		{
			return new EnumerableActions<T>(items).GetResultOfVisitingAllItemsWith(visitor);
		}

		public static IEnumerable<T> AllSatisfying<T>(this IEnumerable<T> items, Specification<T> specification)
		{
			return new EnumerableActions<T>(items).AllMatching(specification);
		}

		public static IEnumerable<TOutput> MapAllUsing<T, TOutput>(this IEnumerable<T> itemsToMap,
		                                                           IMapper<T, TOutput> mapper)
		{
			return new EnumerableActions<T>(itemsToMap).MapAllUsing(mapper);
		}

		public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (var item in collection)
			{
				action(item);
			}
		}

		public static void ForEach<T>(this IEnumerator<T> collection, Action<T> action)
		{
			while (collection.MoveNext())
			{
				action(collection.Current);
			}
		}

		public static IEnumerable<TOutput> ConvertTo<TInput, TOutput>(this IEnumerable<TInput> collection)
			where TInput : TOutput
		{
			var result = new List<TOutput>();

			collection.ForEach(item => result.Add(item));

			return result;
		}

		public static void AttemptDispose<T>(this IEnumerable<T> collection)
		{
			foreach (var item in collection)
			{
				item.AttemptDispose();
			}
		}

		public static void AttemptDispose<T>(this IEnumerator<T> collection)
		{
			while (collection.MoveNext())
			{
				collection.Current.AttemptDispose();
			}
		}
	}
}