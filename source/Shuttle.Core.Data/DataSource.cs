using System;
using System.Collections.Generic;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class DataSource
	{
		private readonly Dictionary<string, IQueryFactory> queryFactories = new Dictionary<string, IQueryFactory>();

		public DataSource(string name, IDbDataParameterFactory dbDataParameterFactory, params IQueryFactory[] factories)
		{
			Guard.AgainstNull(dbDataParameterFactory, "dbDataParameterFactory");

			DbDataParameterFactory = dbDataParameterFactory;

			Name = name;
			Key = name.ToLower();

			if (factories != null)
			{
				foreach (var factory in factories)
				{
					var key = factory.QueryType.ToLower();

					Guard.Against<DuplicateEntryException>(queryFactories.ContainsKey(key), string.Format(DataResources.DuplicateQueryFactory, factory.QueryType));

					queryFactories.Add(key, factory);
				}
			}
		}

		public string Name { get; private set; }
		public string Key { get; private set; }

		public IDbDataParameterFactory DbDataParameterFactory { get; private set; }

		private IQueryFactory GetQueryFactory(IQuery query)
		{
			var key = query.QueryType.ToLower();

			Guard.Against<DuplicateEntryException>(!queryFactories.ContainsKey(key), string.Format(DataResources.MissingQueryFactory, query.QueryType));

			return queryFactories[key];
		}

		public IExecutableQuery GetExecutableQuery(IQuery query)
		{
			Guard.AgainstNull(query, "query");

			if (query is IExecutableQuery)
			{
				return (IExecutableQuery) query;
			}

			var definition = query as QueryDefinition;

			if (definition == null)
			{
				throw new ArgumentException(string.Format(DataResources.UnsupportedIQueryImplementation, query.GetType().FullName));
			}

			return GetQueryFactory(query).Create(definition);
		}
	}
}