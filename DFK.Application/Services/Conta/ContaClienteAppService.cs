using AutoMapper;
using DFK.Application.Interfaces.Cliente;
using DFK.Application.Interfaces.Conta;
using DFK.Application.ViewModel.Cliente;
using DFK.Application.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DFK.Application.Services.Conta
{
    public class ContaClienteAppService : IContaClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteAppService _clienteAppService;
        private readonly IContaAppService _contaAppService;

        public ContaClienteAppService(IClienteAppService clienteAppService, IContaAppService contaAppService, IMapper mapper)
        {
            _clienteAppService = clienteAppService;
            _contaAppService = contaAppService;
            _mapper = mapper;
        }
        public void Create(ContaViewModel conta)
        {
            try
            {                
                    //Na versão atual Core 2.0 constam problemas para TransactionScope (No Standard, este problema não existe).
                    //Assim, para não realizar muitos workarounds, alguns tratamentos foram adotados na camada de domínio.
                    conta.Cliente.Id = _clienteAppService.Create(conta.Cliente);
                    _contaAppService.Create(conta);             
            }
            catch(Exception erro)
            {
                // Tratamento/Log

                throw erro;
            }
        }
    }
}
