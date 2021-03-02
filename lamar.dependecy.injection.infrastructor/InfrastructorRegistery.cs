using System;
using System.Collections.Generic;
using System.Text;
using lamar.dependecy.injection.infrastructor.Logger;
using Lamar;

namespace lamar.dependecy.injection.infrastructor
{
    public class InfrastructorRegistery : ServiceRegistry
    {
        public InfrastructorRegistery()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });

            Policies.Add<LogConvention>();
            
        }
    }
}
