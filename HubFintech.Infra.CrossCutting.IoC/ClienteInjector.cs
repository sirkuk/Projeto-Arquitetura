using DFK.Application.Interfaces.Cliente;
using DFK.Application.Services.Cliente;
using DFK.Domain.Interfaces.Repositories.Cliente;
using DFK.Domain.Interfaces.Services.Cliente;
using DFK.Domain.Services.Cliente;
using DFK.Infra.Data.Repositories.Cliente;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Infra.CrossCutting.IoC
{
    public class ClienteInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
        }
    }
}
