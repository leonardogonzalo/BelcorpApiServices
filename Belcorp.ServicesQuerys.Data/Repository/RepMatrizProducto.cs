using System;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities;
using Microsoft.Extensions.Configuration;
using Belcorp.ServicesQuerys.Data.Repository;
using Belcorp.ServicesQuerys.Data.Connection;
using System.Data.SqlClient;
using Belcorp.ServicesQuerys.Constants;
using System.Collections.Generic;
using Belcorp.ServicesQuerys.Entities.OfertaCatalogo;

namespace Belcorp.ServicesQuerys.Data.Repository
{
    public class RepMatrizProducto : IMatrizProducto<MatrizProducto>
    {
        private readonly IConfiguration configuration;
        AbConnetion abConnetion;
        private String ConnetionString { get; set; }
        public RepMatrizProducto(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

 
        public async Task<List<MatrizProducto>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs)
        {
            
            abConnetion =new  BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);

            MatrizProducto matrizProducto = new MatrizProducto();

            var parameters = new DynamicParameters();

            parameters.Add("@COD_PERIODO",periodo);
            parameters.Add("@COD_VENTA",cuvs);

            using (IDbConnection con = abConnetion.Conectar(isoPais)) {

                return (await con.QueryAsync<MatrizProducto>("P_MATRIZ_PRODUCTO", parameters,commandType:CommandType.StoredProcedure)).AsList();
            }

        }

        public async Task<List<MatrizPromocion>> ListaMatrizPromociones(string isoPais, string periodo, string tipocatalogo)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);

            MatrizProducto matrizProducto = new MatrizProducto();

            var parameters = new DynamicParameters();

            parameters.Add("@COD_PERIODO", periodo);
            parameters.Add("@TIPO_CATALOGO", tipocatalogo);

            using (IDbConnection con = abConnetion.Conectar(isoPais))
            {

                return (await con.QueryAsync<MatrizPromocion>("P_MATRIZ_PROMOCIONES", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
        }

        public async Task<List<MatrizPromocionNivel>> ListaMatrizPromocionesNivel(string isoPais, string periodo, string tipocatalogo)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);

            MatrizProducto matrizProducto = new MatrizProducto();

            var parameters = new DynamicParameters();

            parameters.Add("@COD_PERIODO", periodo);
            parameters.Add("@TIPO_CATALOGO", tipocatalogo);

            using (IDbConnection con = abConnetion.Conectar(isoPais))
            {

                return (await con.QueryAsync<MatrizPromocionNivel>("P_MATRIZ_PROMOCIONES_Y_NIVELES", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
        }
        public async Task<List<StockSapBin>> ConsultarStockSapFacturacion(string isoPais, string periodo, string lcodigosap)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);

            var parameters = new DynamicParameters();

            parameters.Add("@COD_PERIODO", periodo);

            parameters.Add("@LISTA_COD_SAP",lcodigosap);

            using (IDbConnection con = abConnetion.Conectar(isoPais))
            {

                return (await con.QueryAsync<StockSapBin>("P_CONSULTA_SAP_FACTURACION", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
        }
        public async Task<List<StockSapBin>> ConsultarStockSapVenta(string isoPais, string periodo, string lcodigosap)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_SOMOSBELCORP);

            var parameters = new DynamicParameters();

            parameters.Add("@COD_PERIODO", periodo);

            parameters.Add("@LISTA_COD_SAP", lcodigosap);

            using (IDbConnection con = abConnetion.Conectar(isoPais))
            {

                return (await con.QueryAsync<StockSapBin>("P_CONSULTA_SAP_VENTA", parameters, commandType: CommandType.StoredProcedure)).AsList();
            }
        }

        public async Task<ObjOfertaCatalogos> Ofertas_catalogo(EInputOfertaCatalogo ofertaCatalogo)
        {
            abConnetion = new BaseConnection().ConectarBD(configuration, BaseConnection.SQL, ConexSQL.CX_PROL);
            ObjOfertaCatalogos objOfertaCatalogos = new ObjOfertaCatalogos();
            var parameters = new DynamicParameters();

            parameters.Add("@CODVTA", ofertaCatalogo.codvta);
            parameters.Add("@PERIODO", ofertaCatalogo.periodo);
            parameters.Add("@ZONA", ofertaCatalogo.zona);
            parameters.Add("@COD_CONSULTORA", ofertaCatalogo.codigoconsultora);
            parameters.Add("@TIPO_OFERTA", ofertaCatalogo.tipo_oferta);

            using (IDbConnection con = abConnetion.Conectar(ofertaCatalogo.pais))
            {

                using (var res = await con.QueryMultipleAsync("P_OFERTAS_CATALOGO", parameters, commandType: CommandType.StoredProcedure)) {


                    //var re1 = res.Read<ECuvCatalogo>().AsList();

                    var cuvcatalogo = res.Read<ECuvCatalogo>().AsList()[0];
                    var cuvnivel = res.Read<ECuvNivel>().AsList();
                    var cuvgratisnivel = res.Read<ECuvNivelGratis>().AsList();
                    var cuvpack = res.Read<ECuvPack>().AsList();
                    var cuvpack_item = res.Read<ECuvPackItem>().AsList();
                    var cuvtipo = res.Read<ECuvTipo>().AsList();

                    objOfertaCatalogos.cuv_catalogo = cuvcatalogo.CUV_CATALOGO;
                    objOfertaCatalogos.sap_catalogo = cuvcatalogo.SAP_CATALOGO;
                    objOfertaCatalogos.precio_catalogo = cuvcatalogo.PRECIO_CATALOGO;
                    objOfertaCatalogos.cuv_revista = cuvcatalogo.CUV_REVISTA;
                    objOfertaCatalogos.sap_revista = cuvcatalogo.SAP_REVISTA;
                    objOfertaCatalogos.precio_revista = cuvcatalogo.PRECIO_REVISTA;
                    objOfertaCatalogos.ganancia = cuvcatalogo.GANANCIA;


                    ObjNivel objNivel = new ObjNivel();


                    objOfertaCatalogos.lista_ObjNivel.Add(objNivel);



                } ; 

            }

            return objOfertaCatalogos;
        }
    }
}
