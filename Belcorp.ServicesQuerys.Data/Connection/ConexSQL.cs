using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Belcorp.ServicesQuerys.Data.Connection
{
    public class ConexSQL: AbConnetion
    {
        private readonly IConfiguration configuration;

        private string bdPais = string.Empty;
        public int tipoServer = 0;
        public const int CX_PROL = 1;
        public const int CX_SOMOSBELCORP = 2;

        public ConexSQL(IConfiguration _configuration, int _tipoServer)
        {

            configuration = _configuration;
            tipoServer = _tipoServer;
        }


        public override IDbConnection Conectar(string pais)
        {

            switch (tipoServer)
            {

                case CX_PROL:
                    bdPais = ConexionPROL.StringPais(pais);
                    break;
                case CX_SOMOSBELCORP:
                    bdPais = ConexionSomosBelcorp.StringPais(pais);
                    break;
            }


            return new SqlConnection(configuration.GetConnectionString(bdPais));

        }

        private class ConexionPROL
        {
            public ConexionPROL() { }
            public const string PROL = "PROL{0}";

            public static string StringPais(string pais)
            {
                return string.Format(PROL, pais);
            }

        }

        private class ConexionSomosBelcorp
        {

            public static string bdSB = "Belcorp{0}";
            public ConexionSomosBelcorp() { }
            public static string StringPais(string pais)
            {

                switch (pais)
                {

                    case "PE": return string.Format(bdSB, "Peru");
                    case "CO": return string.Format(bdSB, "Colombia");
                    case "MX": return string.Format(bdSB, "Mexico");
                    case "PA": return string.Format(bdSB, "Panama");
                    default: return null;
                }


            }

        }
    }
}
