using HubFintech.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Interfaces.Services.Cliente
{
    public interface IClienteService
    {
        ClienteModel GetById(long clienteId);
    }
}
