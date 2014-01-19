using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data.Castle
{
	public static class ContainerExtensions
	{
		public static void RegisterDataAccess(this IWindsorContainer container, string assembly)
		{
			Guard.AgainstNull(container, "container");
			Guard.AgainstNullOrEmptyString(assembly, "assembly");

			container.Register(
				Classes
					.FromAssemblyNamed(assembly)
					.BasedOn(typeof (IAssembler<>))
					.WithServiceFirstInterface());

			container.Register(
				Classes
					.FromAssemblyNamed(assembly)
					.BasedOn(typeof (IDataRowMapper<>))
					.WithServiceFirstInterface());

			container.Register(
				Classes
					.FromAssemblyNamed(assembly)
					.Pick()
					.If(type => type.Name.EndsWith("Repository"))
					.Configure(configurer => configurer.Named(configurer.Implementation.Name.ToLower()))
					.WithService.Select((type, basetype) => new[]{ type.InterfaceMatching(RegexPatterns.EndsWith("Repository"))}));

			container.Register(
				Classes
					.FromAssemblyNamed(assembly)
					.Pick()
					.If(type => type.Name.EndsWith("QueryFactory"))
					.Configure(configurer => configurer.Named(configurer.Implementation.Name.ToLower()))
					.WithService.Select((type, basetype) => new[] { type.InterfaceMatching(RegexPatterns.EndsWith("QueryFactory")) }));
		}

		public static void RegisterDataAccessCore(this IWindsorContainer container)
		{
			Guard.AgainstNull(container, "container");

			container.Register(Component.For<IDatabaseGateway>().ImplementedBy<DatabaseGateway>());
			container.Register(Component.For<IDatabaseConnectionFactory>().ImplementedBy<DatabaseConnectionFactory>());
			container.Register(Component.For(typeof(IDataRepository<>)).ImplementedBy(typeof(DataRepository<>)));

			container.Register(
				Classes
					.FromAssemblyNamed("Shuttle.Core.Data")
					.Pick()
					.If(type => type.Name.EndsWith("Factory"))
					.Configure(configurer => configurer.Named(configurer.Implementation.Name.ToLower()))
					.WithService.Select((type, basetype) => new[] { type.InterfaceMatching(RegexPatterns.EndsWith("Factory")) }));
		}

		public static void RegisterDataAccessDefaults(this IWindsorContainer container)
		{
			Guard.AgainstNull(container, "container");
			
			container.Register(Component.For<IDbConnectionConfiguration>().ImplementedBy<DbConnectionConfiguration>());
			container.Register(Component.For<IDbConnectionConfigurationProvider>().ImplementedBy<DbConnectionConfigurationProvider>());
		}

		public static void RegisterThreadStaticDatabaseConnectionCache(this IWindsorContainer container)
		{
			Guard.AgainstNull(container, "container");

			container.Register(Component.For<IDatabaseConnectionCache>().ImplementedBy<ThreadStaticDatabaseConnectionCache>());
		}
	}
}
