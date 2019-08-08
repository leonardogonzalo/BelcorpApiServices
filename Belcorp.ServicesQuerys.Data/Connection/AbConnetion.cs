using System.Data;

namespace Belcorp.ServicesQuerys.Data.Connection
{
    public abstract class AbConnetion
    {
        public abstract IDbConnection Conectar(string pais);
    }
}
