using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Shuttle.Core.Infrastructure;
using Shuttle.Core.Infrastructure.Castle;

namespace Shuttle.Core.Data.Castle
{
	public static class ContainerExtensions
	{
		public static void RegisterDataAccess(this IWindsorContainer container, string assembly)
		{
			Guard.AgainstNull(container, "container");
			Guard.AgainstNullOrEmptyString(assembly, "assembly");

			container.RegisterSingleton(assembly, RegexPatterns.EndsWith("Assembler"));
			container.RegisterSingleton(assembly, RegexPatterns.EndsWith("Mapper"));

			container.Register(
				AllTypes
					.FromAssemblyNamed(assembly)
					.Pick()
					.If(type => type.Name.EndsWith("Repository"))
					.Configure(configurer => configurer.Named(configurer.Implementation.Name.ToLower()))
					.WithService.Select((type, basetype) => new[]{ type.InterfaceMatching(RegexPatterns.EndsWith("Repository"))}));

			container.RegisterSingleton(assembly, RegexPatterns.EndsWith("Query"), RegexPatterns.EndsWith("Query"));
		}

		public static void RegisterDataAccessCore(this IWindsorContainer container)
		{
			Guard.AgainstNull(container, "container");

			container.Register(Component.For<IDatabaseGateway>().ImplementedBy<DatabaseGateway>());
			container.Register(Component.For<IDatabaseConnectionFactory>().ImplementedBy<DatabaseConnectionFactory>());
			container.Register(Component.For(typeof(IDataRepository<>)).ImplementedBy(typeof(DataRepository<>)));

			container.RegisterSingleton("Shuttle.Core.Data", RegexPatterns.EndsWith("Factory"));
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

			container.RegisterSingleton<IDatabaseConnectionCache, ThreadStaticDatabaseConnectionCache>();
		}
	}
}
