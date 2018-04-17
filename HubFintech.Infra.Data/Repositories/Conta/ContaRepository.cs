using Dapper;
using HubFintech.Domain.Entities.Conta;
using HubFintech.Domain.Interfaces.Repositories.Conta;
using HubFintech.Infra.Data.Factories.SQLServer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace HubFintech.Infra.Data.Repositories.Conta
{
    public class ContaRepository : IContaRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ContaRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<ContaModel> GetById(int contaId)
        {
            try
            {
                using (IDbConnection conn = _dbConnectionFactory.CreateConnection())
                {
                    var resultado = conn.Query<ContaModel>(
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
