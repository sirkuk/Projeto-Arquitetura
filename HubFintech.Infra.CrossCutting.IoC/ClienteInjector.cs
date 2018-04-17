using HubFintech.Domain.Interfaces.Repositories.Cliente;
using HubFintech.Domain.Interfaces.Services.Cliente;
using HubFintech.Domain.Services.Cliente;
using HubFintech.Infra.Data.Repositories.Cliente;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Infra.CrossCutting.IoC
{
    public class ClienteInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
        }
    }
}
