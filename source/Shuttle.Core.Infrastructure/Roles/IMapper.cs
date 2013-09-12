namespace Shuttle.Core.Infrastructure
{
	public interface IMapper<in TInput, out TOutput> 
    {
        TOutput MapFrom(TInput input);
    }
}
