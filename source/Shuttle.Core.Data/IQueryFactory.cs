using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public interface IQueryFactory : ISpecification<QueryDefinition>
	{
		IExecutableQuery Create(QueryDefinition definition);
		string QueryType { get; }
	}
}