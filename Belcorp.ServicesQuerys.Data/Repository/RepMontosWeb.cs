using Belcorp.ServicesQuerys.Data.Connection;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities.Emontosweb;
using Belcorp.ServicesQuerys.Entities.EmontosWebNiveles;
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

            parameters.Add("@LISTA_CODVTA", rqMontosWeb.lstProductos);
            parameters.Add("@LISTA_CANT", rqMontosWeb.lstCantidades);
            parameters.Add("@PERIODO", rqMontosWeb.periodo);
            parameters.Add("@ZONA", rqMontosWeb.zona);
            parameters.Add("@COD_CONSULTORA", rqMontosWeb.codigoconsultora);
            parameters.Add("@@LISTA_CONCURSOS", rqMontosWeb.Listaconcursos);

            using (IDbConnection con = abConnetion.Conectar(rqMontosWeb.pais))
            {
                return (await con.QueryAsync<SQLRqsMontos>("P_MONTOS_PEDIDO_WEB", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
        }

        public async Task<FestivalDescuentoNivel> MontoFestivalNivel(EFestival festival)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);
            var parameters = new DynamicParameters();

            parameters.Add("@PERIODO", festival.periodo);
            parameters.Add("@LISTA_CODVTA", festival.lista_cuvs);
            parameters.Add("@LISTA_CANT", festival.lista_unidades);
            
            using (IDbConnection con = abConnetion.Conectar(festival.pais))
            {
                return (await con.QueryFirstAsync<FestivalDescuentoNivel>("P_MONTOS_NIVELES_WEB", parameters, commandType: CommandType.StoredProcedure));
            }
        }
    }
}
