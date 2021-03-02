using System;
using System.Collections.Generic;
using System.Text;
using Lamar.IoC.Instances;
using Lamar;
using System.Linq;

namespace lamar.dependecy.injection.infrastructor.Logger
{
    public class LogConvention : ConfiguredInstancePolicy
    {
        protected override void apply(IConfiguredInstance instance)
        {
            instance.ImplementationType
                    .GetConstructors()
                    .SelectMany(x => x.GetParameters())
                    .Where(param => param.ParameterType == typeof(ILogger))
                    .ToList()
                    .ForEach(param =>
                    {
                        instance.Ctor<ILogger>(param.Name).Is(Logger.GetLogger(instance.ImplementationType));
                    });
                    
        }
    }
}
