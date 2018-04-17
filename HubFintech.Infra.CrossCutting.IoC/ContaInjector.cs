using HubFintech.Application.Interfaces.Conta;
using HubFintech.Application.Services.Conta;
using HubFintech.Domain.Interfaces.Repositories.Conta;
using HubFintech.Domain.Interfaces.Services.Conta;
using HubFintech.Domain.Services.Conta;
using HubFintech.Infra.Data.Repositories.Conta;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Infra.CrossCutting.IoC
{
    public class ContaInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IContaAppService, ContaAppService>();
        }
    }
}
