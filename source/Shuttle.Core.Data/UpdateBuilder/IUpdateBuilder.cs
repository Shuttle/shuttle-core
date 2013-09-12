namespace Shuttle.Core.Data
{
    public interface IUpdateBuilder
    {
		QueryDefinition In(string table);
    	IUpdateBuilderUpdate Set(MappedColumn column);
    	IWhereExpressionBuilder<IUpdateBuilderLogical> Where(MappedColumn column);
    }
}