using System.Data;

namespace DFK.Infra.Data.Factories.SQLServer
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
