using System;
using System.Globalization;

namespace Shuttle.Core.Infrastructure
{
	public class Guard
	{
		public static void Against<TException>(bool assertion, string message) where TException : Exception
		{
			if (!assertion)
			{
				return;
			}

			Exception exception;

			try
			{
				exception = (TException) Activator.CreateInstance(typeof (TException), message);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(string.Format(InfrastructureResources.InvalidGuardExceptionType,
				                                                  typeof (TException).FullName, ex.CompactMessages()));
			}

			throw exception;
		}

		public static void Against<TException>(Func<bool> assertion, string message) where TException : Exception
		{
			Against<TException>(assertion(), message);
		}

		public static void AgainstNull(object value, string name)
		{
			if (value == null)
			{
				throw new NullReferenceException(string.Format(CultureInfo.CurrentCulture,
				                                               InfrastructureResources.NullValueException,
				                                               name));
			}
		}

		public static void AgainstNullOrEmptyString(string value, string name)
		{
			AgainstNull(value, name);

			if (value.Length == 0)
				throw new EmptyStringException(string.Format(CultureInfo.CurrentCulture, InfrastructureResources.EmptyStringException, name));
		}

		public static void Implements<TInterface>(object instance, string message)
		{
			Implements<TInterface>(instance.GetType(), message);
		}

		public static void Implements<TInterface>(Type type, string message)
		{
			if (!typeof (TInterface).IsAssignableFrom(type)) throw new InvalidOperationException(message);
		}

		public static void InheritsFrom<TBase>(object instance, string message) where TBase : Type
		{
			InheritsFrom<TBase>(instance.GetType(), message);
		}

		public static void InheritsFrom<TBase>(Type type, string message)
		{
			if (type.BaseType != typeof (TBase)) throw new InvalidOperationException(message);
		}

		public static void IsEqual<TException>(object compare, object instance, string message)
			where TException : Exception
		{
			if (compare != instance) throw (TException) Activator.CreateInstance(typeof (TException), message);
		}

		public static void TypeOf<TType>(object instance, string message)
		{
			if (!(instance is TType)) throw new InvalidOperationException(message);
		}

		public static void AgainstNullDependency(object dependency, string name)
		{
			if (dependency != null)
			{
				return;
			}

			throw new NullDependencyException(string.Format(InfrastructureResources.NullDependencyException, name));
		}

		public static void AgainstReassignment(object variable, string name)
		{
			if (variable == null)
			{
				return;
			}

			throw new ReassignmentException(string.Format(InfrastructureResources.ReassignmentException, name));
		}

		public static void AgainstMissing<T>(object entity, object key)
		{
			if (entity != null)
			{
				return;
			}

			throw new MissingEntityException(string.Format(InfrastructureResources.MissingEntityException, typeof (T).Name, key));
		}

		public static void AgainstDuplicate<T>(bool assertion, string attribute, string value)
		{
			if (!assertion)
			{
				return;
			}

			throw new DuplicateEntityException(string.Format(InfrastructureResources.DuplicateEntityException, typeof (T).Name,
			                                                 attribute, value));
		}
	}
}