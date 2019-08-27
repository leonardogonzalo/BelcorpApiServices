using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Data.Connection;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace Belcorp.ServicesQuerys.Data.Repository
{
    public class RepMatrizConcurso:IMatrizConcurso<RangoConcurso>
    {
        private readonly IConfiguration configuration;
        AbConnetion abConnetion;
        private String ConnetionString { get; set; }

        public RepMatrizConcurso(IConfiguration _configuration) {
            configuration = _configuration;
        }

        public async Task<List<RangoConcurso>> GetRangoConcurso(string isoPais, string periodo)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);
            var parameters = new DynamicParameters();

            parameters.Add("COD_PERIODO", periodo);

            RangoConcurso rangoConcurso = new RangoConcurso();


            using (IDbConnection con = abConnetion.Conectar(isoPais))
            {
                return (await con.QueryAsync<RangoConcurso>("P_RANGO_CONCURSO_PAIS", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
         }
    }
}
