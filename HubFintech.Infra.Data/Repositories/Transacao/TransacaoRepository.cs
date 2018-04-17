using Dapper;
using HubFintech.Domain.Entities.Transacao;
using HubFintech.Domain.Interfaces.Repositories.Transacao;
using HubFintech.Infra.Data.Factories.SQLServer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Infra.Data.Repositories.Transacao
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public TransacaoRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<TransacaoModel> GetById(int transacaoId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<TransacaoModel>(
                                        @""
                        );

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
