namespace Shuttle.Core.Data
{
    public interface ISelectBuilderOrderBy : ISelectBuilderBuild
    {
        IOrderByClauseItem OrderBy(MappedColumn column);
    }
}