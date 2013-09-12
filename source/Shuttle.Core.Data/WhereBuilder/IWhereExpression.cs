namespace Shuttle.Core.Data
{
    public interface IWhereExpression
    {
        MappedColumn Column { get; }
        string Operator { get; }
        string LogicalOperator { get; }
        object Value { get; }
        bool HasValue { get; }
        IWhereExpression WithValue(object value);
    }
}