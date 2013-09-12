namespace Test.All
{
    public interface IHaveGenericParameter<T>
    {
        void DoSomethingUsing(T item);
    }
}