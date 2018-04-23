using Dapper;
using DFK.Domain.Entities.Conta;
using DFK.Domain.Interfaces.Repositories.Conta;
using DFK.Infra.Data.Factories.SQLServer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DFK.Domain.Enum;
using DFK.Domain.Entities.Cliente;

namespace DFK.Infra.Data.Repositories.Conta
{
    public class ContaRepository : IContaRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ContaRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Create(ContaModel conta)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var contaId = conn.ExecuteScalar<long>(
                            @"INSERT INTO Conta 
                                (
                                ContaPaiId,
                                Matriz,
                                Nome,
                                ClienteId,
                                Status,
                                DataCriacao)
                                
                                VALUES
                                (
                                @ContaPaiId,
                                @Matriz,
                                @Nome,
                                @ClienteId,
                                @Status,
                                @DataCriacao)                                                                                                               

                                SELECT CAST(@@IDENTITY AS BIGINT)", new
                            {
                                ContaPaiId = conta.ContaPaiId,
                                Matriz = conta.Matriz,
                                Nome = conta.Nome,
                                ClienteId = conta.Cliente.Id,
                                Status = EnumSituacaoConta.Ativo,
                                DataCriacao = DateTime.Now
                            });
                    conta.Id = contaId;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContaModel GetById(long contaId)
        {
            try
            {
                ContaModel conta = null;

                var consulta =
                            @"
                               SELECT
                                   c.Id,
                                   c.ContaPaiId,
                                   c.Matriz,
                                   c.Nome,
                                   c.ClienteId,
                                   c.Status,
                                   c.DataCriacao,
                                   cli.Id as ClienteId,
                                   cli.DataNascimento,
                                   cli.DataCadastro,
                                   cli.CPF,
                                   cli.NomeCompleto,
                                   cli.CNPJ,
                                   cli.RazaoSocial,
                                   cli.NomeFantasia
                                FROM
                                    Conta c (nolock)

                                JOIN Cliente cli (nolock) ON c.ClienteId = cli.Id

                                WHERE
                                    c.Id = @Id
                            ";
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {

                    using (var queryMultiple = conn.QueryMultiple(consulta, new { Id = contaId }))
                    {
                        conta = queryMultiple.Read<ContaModel, ClienteModel, ContaModel>(
                            (c, cl) =>
                            {
                                c.Id = contaId;
                                c.Cliente = cl;
                                c.Cliente.Id = c.ClienteId;

                                return c;
                            }, splitOn: "Id, ClienteId").DefaultIfEmpty(null).FirstOrDefault();
                    }

                    return conta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarHierarquia(long contaAId, long contaBId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var validarHierarquia = conn.ExecuteScalar<short>(
                            @";WITH ret AS(
                                SELECT  Id, Id as topo
                                FROM    Conta
                                WHERE   ContaPaiId IS null
                                UNION ALL
                                SELECT  c.Id, r.topo as topo
                                FROM    Conta c INNER JOIN
				                        ret r ON c.ContaPaiId = r.Id
                                )

                                SELECT  COUNT(DISTINCT topo)
                                FROM    ret
                                WHERE ID in (@ContaAId,@ContaBId)
                                GROUP BY topo",
                            new
                            {
                                ContaAId = contaAId,
                                ContaBId = contaBId
                            });
                    return validarHierarquia == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
