using HubFintech.Infra.Data.Factories.SQLServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Infra.CrossCutting.IoC
{
    public class SqlServerDbInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>(); 
        }
    }
}
