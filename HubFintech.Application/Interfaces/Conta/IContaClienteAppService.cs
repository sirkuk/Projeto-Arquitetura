using HubFintech.Application.ViewModel.Cliente;
using HubFintech.Application.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.Interfaces.Conta
{
    public interface IContaClienteAppService
    {
        void Create(ContaViewModel conta);
    }
}
