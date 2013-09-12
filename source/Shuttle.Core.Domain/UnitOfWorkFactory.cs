using System;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Domain
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		[ThreadStatic]
		private static IUnitOfWork currentUnitOfWork;

		private readonly IRepositoryProvider repositoryProvider;

		public UnitOfWorkFactory()
			: this(new FaultRepositoryProvider())
		{
		}

		public UnitOfWorkFactory(IRepositoryProvider repositoryProvider)
		{
			Guard.AgainstNull(repositoryProvider, "repositoryProvider");

			this.repositoryProvider = repositoryProvider;
		}

		public IUnitOfWork Current
		{
			get { return currentUnitOfWork; }
			set { currentUnitOfWork = value; }
		}

		public IUnitOfWork Create()
		{
			return new UnitOfWork(repositoryProvider);
		}
	}
}