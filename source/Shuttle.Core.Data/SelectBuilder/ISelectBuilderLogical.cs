namespace Shuttle.Core.Data
{
    public interface ISelectBuilderLogical : IWhereExpressionBuilderLogical<ISelectBuilderLogical>,
                                             ISelectBuilderOrderBy
    {
    }
}