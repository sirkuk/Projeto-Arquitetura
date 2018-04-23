using AutoMapper;
using DFK.Application.Interfaces.Conta;
using DFK.Application.ViewModel.Conta;
using DFK.Domain.Entities.Conta;
using DFK.Domain.Interfaces.Services.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.Services.Conta
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

        public ContaViewModel GetById(long contaId)
        {
            return _mapper.Map<ContaViewModel>(_contaService.GetById(contaId));
        }
    }
}
