using DFK.Application.Interfaces.Transacao;
using DFK.Application.Services.Transacao;
using DFK.Domain.Interfaces.Repositories.Transacao;
using DFK.Domain.Interfaces.Services.Transacao;
using DFK.Domain.Services.Transacao;
using DFK.Infra.Data.Repositories.Transacao;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Infra.CrossCutting.IoC
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
