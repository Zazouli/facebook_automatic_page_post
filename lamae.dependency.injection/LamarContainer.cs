using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using lamar.dependecy.injection.infrastructor;
using Lamar;
using Microsoft.Extensions.Configuration;

namespace lamae.dependency.injection
{
    public class LamarContainer
    {
        public static IContainer Init()
        {
            return new Container(c =>
            {
                c.IncludeRegistry<InfrastructorRegistery>();

                var configutation = Configutarion();

                c.For<IConfiguration>().Use(configutation);
            });
        }

        private static IConfiguration Configutarion()
        {
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    .AddEnvironmentVariables()
                                    .Build();
            return configuration;
        }
    }
}
