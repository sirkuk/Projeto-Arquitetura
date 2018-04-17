using HubFintech.Application.Interfaces.Transacao;
using HubFintech.Application.Services.Transacao;
using HubFintech.Domain.Interfaces.Repositories.Transacao;
using HubFintech.Domain.Interfaces.Services.Transacao;
using HubFintech.Domain.Services.Transacao;
using HubFintech.Infra.Data.Repositories.Transacao;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Infra.CrossCutting.IoC
{
    public class TransacaoInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<ITransacaoAppService, TransacaoAppService>();
        }
    }
}
