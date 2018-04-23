using AutoMapper;
using DFK.Application.ViewModel.Conta;
using DFK.Domain.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.AutoMapper.Conta
{
    public class ContaMappingProfile : Profile
    {
        public ContaMappingProfile()
        {
            CreateMap<ContaModel, ContaViewModel>();
        }
    }
}
