namespace Test.All
{
	public interface IAnotherGeneric<T>
	{
		T GetDefault { get; }
	}

	internal class AnotherGeneric<T> : IAnotherGeneric<T>
	{
		public T GetDefault
		{
			get { return default(T); }
		}
	}
}