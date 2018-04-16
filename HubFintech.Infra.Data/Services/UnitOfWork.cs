using HubFintech.Infra.Data.Factories.SQLServer;
using HubFintech.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HubFintech.Infra.Data.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private IDbTransaction _transaction;
        private IDbConnection _connection;  

        public UnitOfWork(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _connection = _dbConnectionFactory.CreateConnection();
        }

        public void BeginTransaction()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                {
                    _connection.Open();
                    _transaction = _connection.BeginTransaction();
                }
            }
            catch { }
        }

        public void Commit()
        {
            try
            {
                if (_transaction.Connection.State == ConnectionState.Open)
                    _transaction.Commit();

                Dispose();
            }
            catch { }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction.Connection.State == ConnectionState.Open)
                    _transaction.Rollback();

                Dispose();
            }
            catch { }
        }

        public void Dispose()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Dispose();

                if (_connection != null)
                    _connection.Dispose();

                GC.SuppressFinalize(this);
            }
            catch
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
