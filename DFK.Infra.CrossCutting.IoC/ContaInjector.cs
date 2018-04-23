using DFK.Application.Interfaces.Conta;
using DFK.Application.Services.Conta;
using DFK.Domain.Interfaces.Repositories.Conta;
using DFK.Domain.Interfaces.Services.Conta;
using DFK.Domain.Services.Conta;
using DFK.Infra.Data.Repositories.Conta;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Infra.CrossCutting.IoC
{
    public class ContaInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<IContaClienteAppService, ContaClienteAppService>();
        }
    }
}
