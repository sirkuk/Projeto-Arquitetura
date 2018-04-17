using AutoMapper;
using HubFintech.Application.ViewModel.Cliente;
using HubFintech.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Application.AutoMapper.Cliente
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<ClienteModel, ClienteViewModel>();
        }
    }
}
