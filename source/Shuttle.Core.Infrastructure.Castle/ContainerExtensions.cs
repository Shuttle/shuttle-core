using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Shuttle.Core.Infrastructure.Castle
{
    public static class ContainerExtensions
    {
        private static readonly Specification<Type>[] noExclusions = new List<Specification<Type>>().ToArray();

        public static void Register<TService>(this IWindsorContainer container, TService instance)
        {
            Guard.AgainstNull(instance, "instance");

            container.Register(Component.For<TService>().Instance(instance));
        }

        public static void RegisterSingleton<TService, TImplementation>(this IWindsorContainer container) where TImplementation : TService
        {
            container.Register(Component.For<TService>().ImplementedBy<TImplementation>());
        }

        public static void RegisterSingleton<TInterface>(this IWindsorContainer container, string assembly)
        {
            container.RegisterSingleton<TInterface>(assembly, noExclusions);
        }

        public static void RegisterSingleton<TInterface>(this IWindsorContainer container, string assembly,
                                                         params Specification<Type>[] exclude)
        {
            RegisterSingleton(container, assembly, typeof(TInterface), configurer => configurer.LifeStyle.Singleton, exclude);
        }

        public static void RegisterTransient<TService, TImplementation>(this IWindsorContainer container) where TImplementation : TService
        {
            container.Register(Component.For<TService>().ImplementedBy<TImplementation>().LifeStyle.Transient);
        }

        public static void RegisterTransient<TInterface>(this IWindsorContainer container, string assembly)
        {
            container.RegisterTransient(assembly, typeof(TInterface), noExclusions);
        }

        public static void RegisterTransient<TInterface>(this IWindsorContainer container, string assembly,
                                                         params Specification<Type>[] exclude)
        {
            RegisterSingleton(container, assembly, typeof(TInterface), configurer => configurer.LifeStyle.Transient, exclude);
        }

        public static void RegisterSingleton(this IWindsorContainer container, string assembly, Type @interface)
        {
            container.RegisterSingleton(assembly, @interface, noExclusions);
        }

        public static void RegisterSingleton(this IWindsorContainer container, string assembly, Type @interface,
                                             params Specification<Type>[] exclude)
        {
            RegisterSingleton(container, assembly, @interface, configurer => configurer.LifeStyle.Singleton, exclude);
        }

        public static void RegisterTransient(this IWindsorContainer container, string assembly, Type @interface)
        {
            container.RegisterTransient(assembly, @interface, noExclusions);
        }

        public static void RegisterTransient(this IWindsorContainer container, string assembly, Type @interface,
                                             params Specification<Type>[] exclude)
        {
            RegisterSingleton(container, assembly, @interface, configurer => configurer.LifeStyle.Transient, exclude);
        }

        private static void RegisterSingleton(IWindsorContainer container, string assembly, Type @interface,
                                              ConfigureDelegate configuration, params Specification<Type>[] exclude)
        {
            var exclusions = new AndSpecification<Type>(exclude);
            Type conditionType = null;
            Type serviceType = null;

            try
            {
                container.Register(
                    AllTypes
                        .FromAssemblyNamed(assembly)
                        .Pick()
                        .If(
                            type =>
                            {
                                conditionType = type;

                                return !type.IsInterface && type.IsAssignableTo(@interface) && !exclusions.IsSatisfiedBy(type);
                            })
                        .WithService.Select(
                            (type, basetype) =>
                            {
                                serviceType = type;

                                return type.FirstInterface(@interface);
                            })
                        .Configure(configuration));
            }
            catch (Exception ex)
            {
                var message =
                    string.Format("IWindsorContainer.RegisterSingleton Exception (conditionType: {0}, serviceType: {1}): {2}",
                                  conditionType != null
                                    ? conditionType.FullName
                                    : "null",
                                  serviceType != null
                                    ? serviceType.FullName
                                    : "null",
                                  ex.CompactMessages());

                Log.For(container).Error(message);

                throw new DependencyRegistrationException(message);
            }
        }

        public static void RegisterTransient(this IWindsorContainer container, string assembly, string typeFullNamePattern,
                                             params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, configurer => configurer.LifeStyle.Transient, exclude);
        }

        public static void RegisterSingleton(this IWindsorContainer container, string assembly, string typeFullNamePattern,
                                             params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, configurer => configurer.LifeStyle.Singleton, exclude);
        }

        private static void Register(IWindsorContainer container, string assembly, string typeFullNamePattern,
                                     ConfigureDelegate configuration, params Specification<Type>[] exclude)
        {
            var exclusions = new AndSpecification<Type>(exclude);
            var regex = new Regex(typeFullNamePattern);
            Type conditionType = null;

            try
            {
                container.Register(
                    AllTypes
                        .FromAssemblyNamed(assembly)
                        .Pick()
                        .If(
                            type =>
                            {
                                conditionType = type;

                                return
                                    !type.IsInterface
                                    &&
                                    regex.IsMatch(type.FullName ?? string.Empty)
                                    && !exclusions.IsSatisfiedBy(type)
                                    &&
                                    type.HasInterfaces();
                            })
                        .WithService.FirstInterface()
                        .Configure(configuration));
            }
            catch (Exception ex)
            {
                var message =
                    string.Format(
                        "IWindsorContainer.Register Exception (conditionType: {0}, serviceType: 'FirstInterface'): {1}",
                        conditionType != null
                            ? conditionType.FullName
                            : "null",
                        ex.CompactMessages());

                Log.For(container).Error(message);

                throw new DependencyRegistrationException(message);
            }
        }

        public static void RegisterTransient<TInterface>(this IWindsorContainer container, string assembly,
                                                         string typeFullNamePattern, params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, typeof(TInterface), configurer => configurer.LifeStyle.Transient,
                     exclude);
        }

        public static void RegisterSingleton<TInterface>(this IWindsorContainer container, string assembly,
                                                         string typeFullNamePattern, params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, typeof(TInterface), configurer => configurer.LifeStyle.Singleton,
                     exclude);
        }

        public static void RegisterTransient(this IWindsorContainer container, string assembly, string typeFullNamePattern,
                                             Type @interface, params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, @interface, configurer => configurer.LifeStyle.Transient, exclude);
        }

        public static void RegisterSingleton(this IWindsorContainer container, string assembly, string typeFullNamePattern,
                                             Type @interface, params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, @interface, configurer => configurer.LifeStyle.Singleton, exclude);
        }

        private static void Register(IWindsorContainer container, string assembly, string typeFullNamePattern, Type @interface,
                                     ConfigureDelegate configuration, params Specification<Type>[] exclude)
        {
            var exclusions = new AndSpecification<Type>(exclude);
            var regex = new Regex(typeFullNamePattern, RegexOptions.IgnoreCase);
            Type conditionType = null;

            try
            {
                container.Register(
                    AllTypes
                        .FromAssemblyNamed(assembly)
                        .Pick()
                        .If(
                            type =>
                            {
                                conditionType = type;

                                return
                                    !type.IsInterface
                                    &&
                                    regex.IsMatch(type.FullName ?? string.Empty)
                                    &&
                                    !exclusions.IsSatisfiedBy(type)
                                    &&
                                    type.IsAssignableTo(@interface);
                            })
                        .WithService.Select((type, basetype) => new[] { @interface })
                        .Configure(configuration));
            }
            catch (Exception ex)
            {
                var message =
                    string.Format("IWindsorContainer.Register Exception (conditionType: {0}, serviceType: {1}): {2}",
                                  conditionType != null
                                    ? conditionType.FullName
                                    : "null",
                                  @interface.FullName,
                                  ex.CompactMessages());

                Log.For(container).Error(message);

                throw new DependencyRegistrationException(message);
            }
        }

        public static void RegisterTransient(this IWindsorContainer container, string assembly, string typeFullNamePattern,
                                             string interfaceSuffix, params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, interfaceSuffix, configurer => configurer.LifeStyle.Transient,
                     exclude);
        }

        public static void RegisterSingleton(this IWindsorContainer container, string assembly, string typeFullNamePattern,
                                             string interfaceSuffix, params Specification<Type>[] exclude)
        {
            Register(container, assembly, typeFullNamePattern, interfaceSuffix, configurer => configurer.LifeStyle.Singleton,
                     exclude);
        }

        private static void Register(IWindsorContainer container, string assembly, string typeFullNamePattern,
                                     string interfaceFullNamePattern, ConfigureDelegate configuration,
                                     params Specification<Type>[] exclude)
        {
            var exclusions = new AndSpecification<Type>(exclude);
            var typeFullNameRegex = new Regex(typeFullNamePattern, RegexOptions.IgnoreCase);
            Type conditionType = null;
            Type serviceType = null;

            try
            {
                container.Register(
                    AllTypes
                        .FromAssemblyNamed(assembly)
                        .Pick()
                        .If(
                            type =>
                            {
                                conditionType = type;

                                return
                                    !type.IsInterface
                                    &&
                                    typeFullNameRegex.IsMatch(type.FullName ?? string.Empty)
                                    &&
                                    !exclusions.IsSatisfiedBy(type)
                                    &&
                                    type.InterfaceMatching(interfaceFullNamePattern) != null;
                            })
                        .WithService.Select(
                            (type, basetype) =>
                            {
                                serviceType = type.InterfaceMatching(interfaceFullNamePattern);

                                return new[] { serviceType };
                            })
                        .Configure(configuration));
            }
            catch (Exception ex)
            {
                var message =
                    string.Format("IWindsorContainer.Register Exception (conditionType: {0}, serviceType: {1}): {2}",
                                  conditionType != null
                                    ? conditionType.FullName
                                    : "null",
                                  serviceType != null
                                    ? serviceType.FullName
                                    : "null",
                                  ex.CompactMessages());

                Log.For(container).Error(message);

                throw new DependencyRegistrationException(message);
            }
        }

        public static IEnumerable<T> ResolveAssignable<T>(this IWindsorContainer container)
        {
            Guard.AgainstNull(container, "container");

            return container.ResolveAssignable(typeof(T)).Select(implementation => (T)implementation).ToList();
        }

        public static IEnumerable<object> ResolveAssignable(this IWindsorContainer container, Type type)
        {
            Guard.AgainstNull(container, "container");
            Guard.AgainstNull(type, "type");

            var result = new List<object>();

            foreach (var node in container.Kernel.GraphNodes)
            {
                var component = node as ComponentModel;

                if (component == null)
                {
                    continue;
                }

                var assignable = type.IsAssignableFrom(component.Implementation);

                if (!assignable && type.IsGenericType)
                {
                    foreach (var itype in component.Implementation.GetInterfaces())
                    {
                        if (!itype.IsGenericType)
                        {
                            continue;
                        }

                        assignable = type.IsAssignableFrom(itype.GetGenericTypeDefinition());

                        if (assignable)
                        {
                            break;
                        }
                    }
                }

                if (assignable)
                {
                    result.Add(container.Resolve(component.Name, component.Service));
                }
            }

            return result;
        }

        public static void RequireProperties(this IWindsorContainer container, Func<PropertySet, bool> required)
        {
            container.Kernel.ComponentModelBuilder.AddContributor(new RequiredPropertiesComponentModelConstruction(required));
        }
    }
}