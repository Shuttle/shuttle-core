namespace Shuttle.Core.Data
{
    public interface IDeleteBuilder
    {
        QueryDefinition From(string table);
    }
}