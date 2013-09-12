namespace Shuttle.Core.Data
{
    public interface IOrderByClauseItem
    {
        ISelectBuilderOrderByThen Ascending();
        ISelectBuilderOrderByThen Descending();
    }
}