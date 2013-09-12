namespace Shuttle.Core.Data
{
    public interface IWhereBuilderLogical : IWhereExpressionBuilderLogical<IWhereBuilderLogical>
    {
        string Build();
    }
}