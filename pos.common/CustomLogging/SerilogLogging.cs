using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;



namespace pos.common.logger
{
    public class SerilogLogging
    
    {
        public static void ConfigureLogging(IServiceCollection services, IConfiguration configuration)
        {
            // Create a Serilog logger instance using configuration from appsettings.json
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration) // Reads from appsettings.json
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(Log.Logger, dispose: true);
            });
        }


        public static void CloseAndFlush()
        {
            Log.CloseAndFlush(); // Make sure to flush the logs when the application shuts down
        }
    }
}