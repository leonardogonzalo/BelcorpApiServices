using Belcorp.ServicesQuerys.Data.Connection;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities.Emontosweb;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Data.Repository
{
    public class RepMontosWeb:IMontosWeb
    {
        private readonly IConfiguration configuration;
        AbConnetion abConnetion;
        private String ConnetionString { get; set; }

        public RepMontosWeb(IConfiguration _configuration) {
            configuration = _configuration;
        }

        public async Task<List<SQLRqsMontos>> MontosWeb(RqMontosWeb rqMontosWeb)
        {

            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);
            var parameters = new DynamicParameters();

            parameters.Add("LISTA_CODVTA", rqMontosWeb.lstProductos);
            parameters.Add("LISTA_CANT", rqMontosWeb.lstCantidades);
            parameters.Add("@PERIODO", rqMontosWeb.periodo);
            parameters.Add("@ZONA", rqMontosWeb.zona);
            parameters.Add("@COD_CONSULTORA", rqMontosWeb.codigoconsultora);
            parameters.Add("@@LISTA_CONCURSOS", rqMontosWeb.Listaconcursos);

            using (IDbConnection con = abConnetion.Conectar(rqMontosWeb.pais))
            {
                return (await con.QueryAsync<SQLRqsMontos>("P_MONTOS_PEDIDO_WEB", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
        }
    }
}
