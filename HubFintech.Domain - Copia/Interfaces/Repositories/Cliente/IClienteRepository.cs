using HubFintech.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Interfaces.Repositories.Cliente
{
    public interface IClienteRepository
    {
        ClienteModel GetById(long clienteId);
    }
}
