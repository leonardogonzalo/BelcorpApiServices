using System.Data;
namespace Belcorp.ServicesQuerys.Data.Connection
{
    public interface IConnection
    {
        IDbConnection ConectarSql();
        IDbConnection ConectarOracle();
        IDbConnection ConectarMysql();
        
    }
}
