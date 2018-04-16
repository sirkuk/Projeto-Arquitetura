using System.Data;

namespace HubFintech.Infra.Data.Factories.SQLServer
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
