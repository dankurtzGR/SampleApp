using System;
using Microsoft.Extensions.Configuration;
using ConsoleAppBusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace DanKurtzConsoleApp
{
    /// <summary>
    /// Sample .net core console app
    /// Configurable output ( console or api )
     /// </summary>
    class Program
    {
        
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {

            // configure the app 
            Configure();

            // configure services that will be used
            var serviceProvider = GetServiceProvider();

            IWriter outputTo = serviceProvider.GetRequiredService<IWriter>();
            ILogger logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            try
            {
                string message = "Hello World";

                WriteHelloWorld writer = new WriteHelloWorld(outputTo);

                var success = writer.Write(message);

                Console.ReadLine();
                
            }
            catch (Exception ex)
            {
                logger.LogError("Error sample message", ex, args);
            }
        }

        private static void Configure()
        {
            Configuration = new ConfigurationBuilder()
                    .AddJsonFile("AppSettings.json",false)
                     .Build();
        }

        /// <summary>
        /// Used to inject services at runt time
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider GetServiceProvider()
        {

            IServiceCollection services = new ServiceCollection();
                        
            // add logging - sample logging using microsofts logging extension library
            // log4net, nLog libraries could be used
            services
                 .AddLogging()
                 .AddSingleton(
                     new LoggerFactory()
             );

            services.AddOptions();

            // requirement determine output source at run time using a configuration file
            // could be configured to read different configuration files dependending on the environment ( production, development etc. )
            AppSettings appSettings = new AppSettings();
            appSettings.OutputWriter = Configuration["configuration:OutputWriter"].ToString();
              
            if (appSettings.OutputWriter == "ConsoleWriter")
            {
                services.AddTransient<IWriter, ConsoleWriter>();
            }

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
