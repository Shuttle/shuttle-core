namespace Shuttle.Core.Data
{
    public interface ISelectBuilderOrderByThen : ISelectBuilderBuild
    {
        IOrderByClauseItem Then(MappedColumn column);
    }
}