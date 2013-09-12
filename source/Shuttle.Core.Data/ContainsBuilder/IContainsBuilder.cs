namespace Shuttle.Core.Data
{
    public interface IContainsBuilder
    {
        QueryDefinition In(string table);
    }
}