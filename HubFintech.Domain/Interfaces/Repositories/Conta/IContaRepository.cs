using HubFintech.Domain.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Interfaces.Repositories.Conta
{
    public interface IContaRepository
    {
        void Create(ContaModel conta);        
        ContaModel GetById(long contaId);
        bool ValidarHierarquia(long contaAId, long contaBId);
    }
}
