namespace Shuttle.Core.Validation
{
    public interface IRuleCollectionBuilder
    {
        IRuleCollectionBuilder MinimumLength(int minimumLength);
        IRuleCollectionBuilder MaximumLength(int maximumLength);
        IRuleCollectionBuilder Required();
        IRuleCollectionBuilder Decimal();
        IRuleCollectionBuilder DateTime();
        IRuleCollectionBuilder Integer();
        IRuleCollectionBuilder Custom(IRule<object> rule);

        IRuleCollection<object> Create();
    }
}
