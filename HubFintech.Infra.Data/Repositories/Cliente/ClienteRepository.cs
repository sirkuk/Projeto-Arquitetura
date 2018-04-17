﻿using Dapper;
using HubFintech.Domain.Entities.Cliente;
using HubFintech.Domain.Interfaces.Repositories.Cliente;
using HubFintech.Infra.Data.Factories.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HubFintech.Infra.Data.Repositories.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ClienteRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public ClienteModel GetById(long clienteId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<ClienteModel>(
                                        @""
                        );

                    var resultado2 = new ClienteModel()
                    {
                        Id = 1,
                        NomeCompleto = "Teste",
                        Cpf = "12345689031"
                    };
                    return resultado2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
