namespace Shuttle.Core.Data
{
    public interface IOrderByItem
    {
        MappedColumn Column { get; }
        OrderByItem.SortOrderType SortOrder { get; }
    }
}