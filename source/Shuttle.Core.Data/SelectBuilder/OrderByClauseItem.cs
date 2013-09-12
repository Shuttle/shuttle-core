namespace Shuttle.Core.Data
{
    public class OrderByClauseItem : IOrderByClauseItem
    {
        private readonly SelectBuilder builder;
        private readonly MappedColumn column;

        public OrderByClauseItem(SelectBuilder builder, MappedColumn column)
        {
            this.builder = builder;
            this.column = column;
        }

        public ISelectBuilderOrderByThen Ascending()
        {
            builder.AddOrderByItem(new OrderByItem(column, OrderByItem.SortOrderType.Ascending));

            return builder;
        }

        public ISelectBuilderOrderByThen Descending()
        {
            builder.AddOrderByItem(new OrderByItem(column, OrderByItem.SortOrderType.Descending));

            return builder;
        }
    }
}