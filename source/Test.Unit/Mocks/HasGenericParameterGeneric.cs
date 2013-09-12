namespace Test.All
{
	public class HasGenericParameterGeneric : IHaveGenericParameter<IAnotherGeneric<string>>
	{
		public void DoSomethingUsing(IAnotherGeneric<string> item)
		{
		}
	}
}