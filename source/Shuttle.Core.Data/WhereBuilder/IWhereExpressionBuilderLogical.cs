namespace Shuttle.Core.Data
{
    public interface IWhereExpressionBuilderLogical<T>
    {
        IWhereExpressionBuilder<T> And(MappedColumn column);
        IWhereExpressionBuilder<T> Or(MappedColumn column);
    }
}