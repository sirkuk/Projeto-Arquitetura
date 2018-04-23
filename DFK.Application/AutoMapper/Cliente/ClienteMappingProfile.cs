using AutoMapper;
using DFK.Application.ViewModel.Cliente;
using DFK.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Application.AutoMapper.Cliente
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<ClienteModel, ClienteViewModel>();
        }
    }
}
