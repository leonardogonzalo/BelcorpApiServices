using System;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities;
using Microsoft.Extensions.Configuration;
using Belcorp.ServicesQuerys.Data.Repository;
using Belcorp.ServicesQuerys.Data.Connection;
using Microsoft.Data.SqlClient;
using Belcorp.ServicesQuerys.Constants;
using System.Collections.Generic;

namespace Belcorp.ServicesQuerys.Data.Repository
{
    public class RepMatrizProducto : IMatrizProducto<MatrizProducto>,IConnection
    {
        private readonly IConfiguration _configuration;
        private String ConnetionString { get; set; }
        public RepMatrizProducto(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ConectarSql()
        {
            return new SqlConnection(ConnetionString);
        }
        public IDbConnection ConectarOracle()
        {
            throw new NotImplementedException();
        }

        public IDbConnection ConectarMysql()
        {
            throw new NotImplementedException();
        }


        public async Task<List<MatrizProducto>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs)
        {
            ConnetionString = _configuration.GetConnectionString(String.Format(Constants.Constants.ConnectionSql.ConnetionProl, isoPais));

            MatrizProducto matrizProducto = new MatrizProducto();

            var parameters = new DynamicParameters();

            parameters.Add("@COD_PERIODO",periodo);
            parameters.Add("@COD_VENTA",cuvs);

            using (IDbConnection con=ConectarSql()) {

                return (await con.QueryAsync<MatrizProducto>("P_MATRIZ_PRODUCTO", parameters,commandType:CommandType.StoredProcedure)).AsList();
            }

        }


    }
}
