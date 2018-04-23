using DFK.Application.ViewModel.Cliente;
using DFK.Application.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.Interfaces.Conta
{
    public interface IContaClienteAppService
    {
        void Create(ContaViewModel conta);
    }
}
