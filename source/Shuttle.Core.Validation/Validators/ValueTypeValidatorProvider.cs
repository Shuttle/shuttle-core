using System.Collections.Generic;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public class ValueTypeValidatorProvider : IValueTypeValidatorProvider
    {
        private readonly Dictionary<string, IValueTypeValidator> validators = new Dictionary<string, IValueTypeValidator>();

        public ValueTypeValidatorProvider(IEnumerable<IValueTypeValidator> valueTypeValidators)
        {
            valueTypeValidators.ForEach(validator => validators.Add(validator.Type.ToLower(), validator));
        }

        public IValueTypeValidator Get(string type)
        {
            if (!validators.ContainsKey(type.ToLower()))
            {
                throw new KeyNotFoundException(string.Format(InfrastructureResources.KeyNotFoundException, type, "ValueTypeValidatorProvider"));
            }

            return validators[type.ToLower()];
        }

        public bool Has(string type)
        {
            return validators.ContainsKey(type.ToLower());
        }
    }
}
