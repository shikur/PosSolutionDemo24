using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pos.common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.common.CustomLogging
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
        {
            // Pass both IServiceCollection and IConfiguration to ConfigureLogging
            SerilogLogging.ConfigureLogging(services, configuration);
            return services;
        }
    }

}