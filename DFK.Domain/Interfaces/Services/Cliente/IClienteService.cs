using DFK.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        long Create(ClienteModel cliente);
        ClienteModel GetById(long clienteId);
    }
}
