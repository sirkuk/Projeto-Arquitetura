using HubFintech.Domain.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Interfaces.Services.Conta
{
    public interface IContaService
    {
        void Create(ContaModel conta);
        ContaModel GetByCodigoTransacao(string codigoTransacao);
        ContaModel GetById(long contaId);
    }
}
