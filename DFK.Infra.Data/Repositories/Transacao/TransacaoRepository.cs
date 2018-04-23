using Dapper;
using DFK.Domain.Entities.Transacao;
using DFK.Domain.Interfaces.Repositories.Transacao;
using DFK.Infra.Data.Factories.SQLServer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFK.Infra.Data.Repositories.Transacao
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public TransacaoRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IList<TransacaoModel> GetAll()
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<TransacaoModel>(
                                        @"select 
                                            Id,
                                            CodigoTransacao,
                                            ReferenciaId,
                                            ContaOrigemId,
                                            ContaDestinoId,
                                            DataCadastro,
                                            DataAtualizacao,
                                            Valor
                                            from transacao (nolock)"
                        ).ToList();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Create(TransacaoModel transacao)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {                
                    conn.Execute(
                            @"INSERT INTO transacao 
                                (
                                CodigoTransacao,
                                ReferenciaId,
                                ContaOrigemId,
                                ContaDestinoId,
                                DataCadastro,
                                DataAtualizacao,
                                Valor)
                                
                                VALUES
                                (
                                @CodigoTransacao,
                                @ReferenciaId,
                                @ContaOrigemId,
                                @ContaDestinoId,
                                @DataCadastro,
                                @DataAtualizacao,
                                @Valor)                                                                                                              
                            ", new
                            {                                
                                CodigoTransacao = transacao.CodigoTransacao,
                                ReferenciaId = transacao.ReferenciaId,
                                ContaOrigemId = transacao.ContaOrigemId,
                                ContaDestinoId = transacao.ContaDestinoId,
                                DataCadastro = transacao.DataCadastro,
                                DataAtualizacao = transacao.DataAtualizacao,
                                Valor = transacao.Valor
                            });
                    return transacao.CodigoTransacao;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransacaoModel GetById(long transacaoId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<TransacaoModel>(
                                        @"SELECT 
                                            Id,
                                            CodigoTransacao,
                                            ReferenciaId,
                                            ContaOrigemId,
                                            ContaDestinoId,
                                            DataCadastro,
                                            DataAtualizacao,
                                            Valor
                                          FROM transacao (nolock)
                                          WHERE
                                            id = @Id
                                        ", new { Id = transacaoId }
                        ).FirstOrDefault();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransacaoModel GetByCodTransacao(string codigoTransacao)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<TransacaoModel>(
                                        @"SELECT 
                                            Id,
                                            CodigoTransacao,
                                            ReferenciaId,
                                            ContaOrigemId,
                                            ContaDestinoId,
                                            DataCadastro,
                                            DataAtualizacao,
                                            Valor
                                          FROM transacao (nolock)
                                          WHERE
                                            CodigoTransacao = @CodigoTransacao
                                        ", new { CodigoTransacao = codigoTransacao }
                        ).FirstOrDefault();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool TransacaoEstornada(long referenciaId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.ExecuteScalar<short>(
                                        @"SELECT 
                                            COUNT(0)
                                          FROM transacao (nolock)
                                          WHERE
                                            ReferenciaId = @ReferenciaId
                                        ", new { ReferenciaId = referenciaId }
                        );
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
