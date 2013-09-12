namespace Shuttle.Core.Data
{
    public class OrderByItem : IOrderByItem
    {
        public enum SortOrderType
        {
            Ascending = 0,
            Descending = 1
        }

        public OrderByItem(MappedColumn column, SortOrderType sortOrder)
        {
            Column = column;
            SortOrder = sortOrder;
        }

        public MappedColumn Column { get; private set; }
        public SortOrderType SortOrder { get; private set; }
    }
}