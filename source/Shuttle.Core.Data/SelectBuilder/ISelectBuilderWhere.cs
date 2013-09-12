namespace Shuttle.Core.Data
{
    public interface ISelectBuilderWhere : ISelectBuilder, ISelectBuilderOrderBy
    {
        IWhereExpressionBuilder<ISelectBuilderLogical> Where(MappedColumn column);
    }
}