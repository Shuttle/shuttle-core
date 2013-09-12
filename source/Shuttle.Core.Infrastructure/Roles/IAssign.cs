namespace Shuttle.Core.Infrastructure
{
	public interface IAssign<in T>
	{
		void Assign(T instance);
	}
}