using lamar.dependecy.injection.infrastructor;
using System.Linq;
using System.Threading.Tasks;
using lamar.dependecy.injection.domain;
using System;
using log4net;
using log4net.Config;
using Lamar;
using System.IO;
using System.Reflection;

namespace lamae.dependency.injection
{
    class Program
    {
        private static IContainer _container;
        private static ILog _logger;
        private static void Init()
        {
            GlobalContext.Properties["LogFileFolder"] = @"C:\Users\oussa\source\repos\lamae.dependency.injection\LoggingFile";

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo($@"{basePath}\log4net.config"));

            _logger = LogManager.GetLogger(typeof(Program));

            _container = LamarContainer.Init();

        }
        static async Task Main(string[] args)
        {
            Init();

            _logger.Info("The program has Started");

            var postOnFaceBook = _container.GetInstance<IPostOnFaceBookPage>();

            await postOnFaceBook.Run();

        }
    }
}


