using HubFintech.Application.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.Interfaces.Conta
{
    public interface IContaAppService
    {
        void Create(ContaViewModel conta);
        ContaViewModel GetById(long contaId);
    }
}
