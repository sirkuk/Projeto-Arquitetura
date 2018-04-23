using DFK.Application.ViewModel.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.Interfaces.Cliente
{
    public interface IClienteAppService
    {
        long Create(ClienteViewModel cliente);
        ClienteViewModel GetById(long clienteId);
    }
}
