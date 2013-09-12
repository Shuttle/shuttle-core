namespace Shuttle.Core.Data
{
    public interface IWhereExpressionBuilder<T>
    {
        T WithLike();
        T WithEqualTo();
        T WithNotLike();
        T WithNotEqualTo();
        T WithGreaterThan();
        T WithLessThan();
        T WithGreaterThanOrEqualTo();
        T WithLessThanOrEqualTo();

        T Like<TValue>(TValue value);
        T EqualTo<TValue>(TValue value);
        T NotLike<TValue>(TValue value);
        T NotEqualTo<TValue>(TValue value);
        T GreaterThan<TValue>(TValue value);
        T LessThan<TValue>(TValue value);
        T GreaterThanOrEqualTo<TValue>(TValue value);
        T LessThanOrEqualTo<TValue>(TValue value);
        T Null();
    }
}