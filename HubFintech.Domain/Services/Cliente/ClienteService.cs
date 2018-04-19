using HubFintech.Domain.Entities.Cliente;
using HubFintech.Domain.Interfaces.Repositories.Cliente;
using HubFintech.Domain.Interfaces.Services.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public long Create(ClienteModel cliente)
        {
            ClienteModel clienteExiste = null;

            if ((cliente.Id > 0 && (clienteExiste = GetById(cliente.Id)) == null) || cliente.Id <= 0)
            {
                if((!string.IsNullOrEmpty(cliente.Cpf) && (clienteExiste = _clienteRepo.GetByCPF(cliente.Cpf)) == null) ||
                    (!string.IsNullOrEmpty(cliente.Cnpj) && (clienteExiste = _clienteRepo.GetByCNPJ(cliente.Cnpj)) == null))
                _clienteRepo.Create(cliente);
            }

            if(!cliente.IsValid())
                throw new Exception(cliente.ValidationResult.Erros.Aggregate((i, j) => i + "," + j));

            if (clienteExiste != null)
                return clienteExiste.Id;

            return cliente.Id;
        }

        public ClienteModel GetById(long clienteId)
        {
            return _clienteRepo.GetById(clienteId);
        }
    }
}
