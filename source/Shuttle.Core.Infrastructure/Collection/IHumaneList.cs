using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shuttle.Core.Infrastructure
{
    public interface IHumaneList<T> : IList<T>
    {
        int Capacity { get; set; }

        void AddRange(IEnumerable<T> collection);

        ReadOnlyCollection<T> AsReadOnly();

        int BinarySearch(int index, int count, T item, IComparer<T> comparer);

        int BinarySearch(T item);

        int BinarySearch(T item, IComparer<T> comparer);

        IHumaneList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);

        void CopyTo(T[] array);

        void CopyTo(int index, T[] array, int arrayIndex, int count);

        bool Exists(Predicate<T> match);

        T Find(Predicate<T> match);

        IHumaneList<T> FindAll(Predicate<T> match);

        int FindIndex(Predicate<T> match);

        int FindIndex(int startIndex, Predicate<T> match);

        int FindIndex(int startIndex, int count, Predicate<T> match);

        T FindLast(Predicate<T> match);

        int FindLastIndex(Predicate<T> match);

        int FindLastIndex(int startIndex, Predicate<T> match);

        int FindLastIndex(int startIndex, int count, Predicate<T> match);

        void ForEach(Action<T> action);

        IHumaneList<T> GetRange(int index, int count);

        TResult GetResultOfVisitingAllItemsWith<TResult>(IValueReturningVisitor<TResult, T> visitor);

        int IndexOf(T item, int index);

        int IndexOf(T item, int index, int count);

        void InsertRange(int index, IEnumerable<T> collection);

        int LastIndexOf(T item);

        int LastIndexOf(T item, int index);

        int LastIndexOf(T item, int index, int count);

        IEnumerable<TOutput> MapAllUsing<TOutput>(IMapper<T, TOutput> mapper);

        int RemoveAll(Predicate<T> match);

        void RemoveRange(int index, int count);

        void Reverse();

        void Reverse(int index, int count);

        void Sort();

        void Sort(IComparer<T> comparer);

        void Sort(int index, int count, IComparer<T> comparer);

        void Sort(Comparison<T> comparison);

        T[] ToArray();

        void TrimExcess();

        bool TrueForAll(Predicate<T> match);

        void VisitAllItemWith(IVisitor<T> visitor);
    }
}
