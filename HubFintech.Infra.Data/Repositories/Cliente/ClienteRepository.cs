using Dapper;
using HubFintech.Domain.Entities.Cliente;
using HubFintech.Domain.Interfaces.Repositories.Cliente;
using HubFintech.Infra.Data.Factories.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public void Create(ClienteModel cliente)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {                    
                    var clienteId = conn.ExecuteScalar<long>(
                            @"INSERT INTO cliente 
                                (
                                DataNascimento, 
                                DataCadastro, 
                                Cpf,
                                NomeCompleto,
                                Cnpj,
                                Razaosocial,
                                NomeFantasia)
                                
                                VALUES
                                (
                                @DataNascimento, 
                                @DataCadastro, 
                                @Cpf,
                                @NomeCompleto,
                                @Cnpj,
                                @Razaosocial,
                                @NomeFantasia)                                                                                                                

                                SELECT CAST(@@IDENTITY AS BIGINT)", new
                    {
                        DataNascimento = cliente.DataNascimento,
                        DataCadastro = DateTime.Now,
                        Cpf = cliente.Cpf,
                        NomeCompleto = cliente.NomeCompleto,
                        Cnpj = cliente.Cnpj,
                        Razaosocial = cliente.Razaosocial,
                        NomeFantasia = cliente.NomeFantasia
                    });
                    cliente.Id = clienteId;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel GetByCNPJ(string cnpj)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<ClienteModel>(
                                        @"select 
                                            Id,
                                            DataNascimento, 
                                            DataCadastro, 
                                            Cpf,
                                            NomeCompleto,
                                            Cnpj,
                                            Razaosocial,
                                            NomeFantasia
                                            from cliente (nolock)
                                          where
                                            Cnpj = @Cnpj
                                        ", new { Cnpj = cnpj }
                        ).FirstOrDefault();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel GetByCPF(string cpf)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<ClienteModel>(
                                        @"select 
                                            Id,
                                            DataNascimento, 
                                            DataCadastro, 
                                            Cpf,
                                            NomeCompleto,
                                            Cnpj,
                                            Razaosocial,
                                            NomeFantasia
                                            from cliente (nolock)
                                          where
                                            Cpf = @Cpf
                                        ", new { Cpf = cpf }
                        ).FirstOrDefault();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel GetById(long clienteId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<ClienteModel>(
                                        @"select 
                                            Id,
                                            DataNascimento, 
                                            DataCadastro, 
                                            Cpf,
                                            NomeCompleto,
                                            Cnpj,
                                            Razaosocial,
                                            NomeFantasia
                                            from cliente (nolock)
                                          where
                                            id = @Id
                                        ", new {Id=clienteId}
                        ).FirstOrDefault();
                   
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
