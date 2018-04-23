using AutoMapper;
using DFK.Application.ViewModel.Transacao;
using DFK.Domain.Entities.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.AutoMapper.Transacao
{
    public class TransacaoMappingProfile: Profile
    {
        public TransacaoMappingProfile()
        {
            CreateMap<TransacaoModel, TransacaoViewModel>();
        }
    }
}
