using System.Collections.Generic;
using System.Linq;

namespace Shuttle.Core.Data
{
	public class DataRepository<T> : IDataRepository<T> where T : class
	{
		private readonly IDatabaseGateway gateway;
		private readonly IDataRowMapper<T> mapper;

		public DataRepository(IDatabaseGateway gateway, IDataRowMapper<T> mapper)
		{
			this.gateway = gateway;
			this.mapper = mapper;
		}

		public IEnumerable<T> FetchAllUsing(DataSource source, IExecutableQuery executableQuery)
		{
			return gateway.GetRowsUsing(source, executableQuery).MappedRowsUsing(mapper).Select(row => row.Result).ToList();
		}

		public T FetchItemUsing(DataSource source, IExecutableQuery executableQuery)
		{
			var row = gateway.GetSingleRowUsing(source, executableQuery);

			return row == null ? default(T) : mapper.Map(row).Result;
		}

		public MappedRow<T> FetchMappedRowUsing(DataSource source, IExecutableQuery executableQuery)
		{
			var row = gateway.GetSingleRowUsing(source, executableQuery);

			return row == null ? null : mapper.Map(row);
		}

		public IEnumerable<MappedRow<T>> FetchMappedRowsUsing(DataSource source, IExecutableQuery executableQuery)
		{
			return gateway.GetRowsUsing(source, executableQuery).MappedRowsUsing(mapper);
		}

		public bool Contains(DataSource source, IExecutableQuery executableQuery)
		{
			return (gateway.GetScalarUsing<int>(source, executableQuery) == 1);
		}

		public IEnumerable<T> FetchAllUsing(DataSource source, IQuery query)
		{
			return FetchAllUsing(source, source.GetExecutableQuery(query));
		}

		public T FetchItemUsing(DataSource source, IQuery query)
		{
			return FetchItemUsing(source, source.GetExecutableQuery(query));
		}

		public MappedRow<T> FetchMappedRowUsing(DataSource source, IQuery query)
		{
			return FetchMappedRowUsing(source, source.GetExecutableQuery(query));
		}

		public IEnumerable<MappedRow<T>> FetchMappedRowsUsing(DataSource source, IQuery query)
		{
			return FetchMappedRowsUsing(source, source.GetExecutableQuery(query));
		}

		public bool Contains(DataSource source, IQuery query)
		{
			return Contains(source, source.GetExecutableQuery(query));
		}
	}
}