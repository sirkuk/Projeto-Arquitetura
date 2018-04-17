using HubFintech.Application.ViewModel.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.Interfaces.Cliente
{
    public interface IClienteAppService
    {
        ClienteViewModel GetById(long clienteId);
    }
}
