using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Belcorp.ServicesQuerys.Data.Connection
{
    public class BaseConnection
    {
        /**Gestores de conexion**/
        public const int SQL = 1;
        public const int ORACLE = 2;
        public const int MYSQL = 3;
        public const int MONGODB = 4;

        public BaseConnection() { }

        public AbConnetion ConectarBD(IConfiguration configuration, int tipoGestor, int tipoServer)
        {

            switch (tipoGestor)
            {

                case SQL: return new ConexSQL(configuration, tipoServer);

                default: return null;

            }

        }
    }
}
