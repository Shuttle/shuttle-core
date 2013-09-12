namespace Test.All
{
	public class FirstInterface : IFirstInterfaceBottom
	{
	}

	public interface IFirstInterfaceBottom : IFirstInterfaceMiddle
	{
	}

	public interface IFirstInterfaceMiddle : IFirstInterfaceTop
	{
	}

	public interface IFirstInterfaceTop
	{
	}
}