namespace Shuttle.Core.Data
{
    public interface IInsertBuilder
    {
        IInsertBuilderAdd Add(MappedColumn column);
        QueryDefinition Into(string tableName);
    }
}