using HubFintech.Domain.Entities.Cliente;
using HubFintech.Domain.Interfaces.Repositories.Cliente;
using HubFintech.Domain.Interfaces.Services.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Domain.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepo;

        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public ClienteModel GetById(long clienteId)
        {
            return _clienteRepo.GetById(clienteId);
        }
    }
}
