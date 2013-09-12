using System;
using System.Collections.Specialized;
using System.Resources;

namespace Shuttle.Core.Web
{
    public class FormElement<T>
    {
        private static string keyPrefix = string.Empty;
        private static string keySuffix = string.Empty;
        public static bool initialized;

        public static void Initialize(string labelTextKeyPrefix, string labelTextKeySuffix)
        {
            if (initialized)
            {
                throw new InvalidOperationException();
            }

            keyPrefix = labelTextKeyPrefix;
            keySuffix = labelTextKeySuffix;

            initialized = true;
        }

        private static readonly Type GuidType = typeof (Guid);
        private bool isEnum;
        private Type underlyingSystemType;

        public FormElement(string elementName)
        {
            ElementName = elementName;

            HasDefault = false;

            GetUnderlyingSystemType();
        }

        public FormElement(string elementName, T defaultValue)
        {
            ElementName = elementName;
            DefaultValue = defaultValue;

            HasDefault = true;

            GetUnderlyingSystemType();
        }

        public string ElementName { get; private set; }
        public T DefaultValue { get; private set; }
        public bool HasDefault { get; private set; }

        public override string ToString()
        {
            return ElementName;
        }

        public static implicit operator string(FormElement<T> element)
        {
            return element.ElementName;
        }

        public object RetrieveRawValueFrom(NameValueCollection form)
        {
            return form[ElementName];
        }

        public bool IsNullFor(NameValueCollection form)
        {
            return ((RetrieveRawValueFrom(form) == null) || (RetrieveRawValueFrom(form).ToString().Length == 0));
        }

        public T MapFrom(NameValueCollection form)
        {
            try
            {
                return (IsNullFor(form)
                                ? (HasDefault
                                           ? DefaultValue
                                           : default(T))
                                : (!isEnum
                                           ? typeof (T).IsAssignableFrom(GuidType)
                                                     ? (T)(object)new Guid((string)RetrieveRawValueFrom(form))
                                                     : (T)Convert.ChangeType(RetrieveRawValueFrom(form), underlyingSystemType)
                                           : (T)Enum.Parse(underlyingSystemType, RetrieveRawValueFrom(form).ToString())));
            }
            catch
            {
                return (HasDefault
                                ? DefaultValue
                                : default(T));
            }
        }

        private void GetUnderlyingSystemType()
        {
            underlyingSystemType = Nullable.GetUnderlyingType(typeof (T)) ?? typeof (T);

            isEnum = typeof (Enum).IsAssignableFrom(underlyingSystemType);
        }

        public FormElement<T> AppendToName(string value)
        {
            return !HasDefault
                           ? new FormElement<T>(ElementName + value)
                           : new FormElement<T>(ElementName + value, DefaultValue);
        }

        public string LabelText(ResourceManager resourceManager)
        {
            var key = string.Format("{0}{1}{2}", keyPrefix, ElementName, keySuffix);
            var result = resourceManager.GetString(key);

            return !string.IsNullOrEmpty(result)
                           ? result
                           : string.Format("{{{0}}}", key);
        }
    }
}
