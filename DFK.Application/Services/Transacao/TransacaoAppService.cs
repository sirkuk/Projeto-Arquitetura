using AutoMapper;
using DFK.Application.Interfaces.Transacao;
using DFK.Application.ViewModel.Transacao;
using DFK.Domain.Entities.Transacao;
using DFK.Domain.Interfaces.Services.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.Services.Transacao
{
    public class TransacaoAppService : ITransacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly ITransacaoService _transacaoService;

        public TransacaoAppService(ITransacaoService transacaoService, IMapper mapper)
        {
            _transacaoService = transacaoService;
            _mapper = mapper;
        }

        public string Create(TransacaoViewModel transacao)
        {
            return _transacaoService.Create(_mapper.Map<TransacaoModel>(transacao));
        }

        public string Estornar(TransacaoViewModel transacao)
        {
           return _transacaoService.Estornar(_mapper.Map<TransacaoModel>(transacao));
        }

        public IList<TransacaoViewModel> GetAll()
        {
            return _mapper.Map<IList<TransacaoViewModel>>( _transacaoService.GetAll());
        }
    }
}
