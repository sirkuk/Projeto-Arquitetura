using DFK.Domain.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Interfaces.Services.Conta
{
    public interface IContaService
    {
        void Create(ContaModel conta);
        ContaModel GetById(long contaId);
    }
}
