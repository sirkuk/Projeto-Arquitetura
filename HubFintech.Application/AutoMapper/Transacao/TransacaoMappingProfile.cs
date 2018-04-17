using AutoMapper;
using HubFintech.Application.ViewModel.Transacao;
using HubFintech.Domain.Entities.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.AutoMapper.Transacao
{
    public class TransacaoMappingProfile: Profile
    {
        public TransacaoMappingProfile()
        {
            CreateMap<TransacaoModel, TransacaoViewModel>();
        }
    }
}
