using System;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;

namespace Shuttle.Core.Infrastructure.Castle
{
    public class RequiredPropertiesComponentModelConstruction : IContributeComponentModelConstruction
    {
        private readonly Func<PropertySet, bool> required;

        public RequiredPropertiesComponentModelConstruction(Func<PropertySet, bool> required)
        {
            Guard.AgainstNull(required, "required");

            this.required = required;
        }

        public RequiredPropertiesComponentModelConstruction()
            : this((PropertySet) => true)
        {
        }

        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            foreach (var propertySet in model.Properties.Where(propertySet => required.Invoke(propertySet)))
            {
                propertySet.Dependency.IsOptional = false;
            }
        }
    }
}