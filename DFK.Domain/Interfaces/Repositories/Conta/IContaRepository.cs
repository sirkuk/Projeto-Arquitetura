using DFK.Domain.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Interfaces.Repositories.Conta
{
    public interface IContaRepository
    {
        void Create(ContaModel conta);        
        ContaModel GetById(long contaId);
        bool ValidarHierarquia(long contaAId, long contaBId);
    }
}
