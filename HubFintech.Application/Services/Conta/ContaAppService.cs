using AutoMapper;
using HubFintech.Application.Interfaces.Conta;
using HubFintech.Application.ViewModel.Conta;
using HubFintech.Domain.Entities.Conta;
using HubFintech.Domain.Interfaces.Services.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.Services.Conta
{
    public class ContaAppService : IContaAppService
    {
        private readonly IMapper _mapper;
        private readonly IContaService _contaService;

        public ContaAppService(IContaService contaService, IMapper mapper)
        {
            _contaService = contaService;
            _mapper = mapper;
        }
        public void Create(ContaViewModel conta)
        {
            _contaService.Create(_mapper.Map<ContaModel>(conta));
        }

        public ContaViewModel GetByCodigoTransacao(string codigoTransacao)
        {
            throw new NotImplementedException();
        }
    }
}
