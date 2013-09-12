using System;
using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public class HumaneList<T> : List<T>, IHumaneList<T>
    {
        public HumaneList(IEnumerable<T> collection) : base(collection)
        {
        }

        public HumaneList(int capacity) : base(capacity)
        {
        }

        public HumaneList()
        {
        }

        public IEnumerable<TOutput> MapAllUsing<TOutput>(IMapper<T, TOutput> mapper)
        {
            return ConvertAll<TOutput>(mapper.MapFrom);
        }

        public new IHumaneList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            return new HumaneList<TOutput>(base.ConvertAll(converter));
        }

        public new IHumaneList<T> FindAll(Predicate<T> match)
        {
            return new HumaneList<T>(base.FindAll(match));
        }

        public new IHumaneList<T> GetRange(int index, int count)
        {
            return new HumaneList<T>(base.GetRange(index, count));
        }

        public void VisitAllItemWith(IVisitor<T> visitor)
        {
            ForEach(visitor.Visit);
        }

        public TResult GetResultOfVisitingAllItemsWith<TResult>(IValueReturningVisitor<TResult, T> visitor)
        {
            VisitAllItemWith(visitor);
            return visitor.GetResult();
        }
    }
}
