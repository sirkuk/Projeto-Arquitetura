using AutoMapper;
using HubFintech.Application.ViewModel.Conta;
using HubFintech.Domain.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.AutoMapper.Conta
{
    public class ContaMappingProfile : Profile
    {
        public ContaMappingProfile()
        {
            CreateMap<ContaModel, ContaViewModel>();
        }
    }
}
