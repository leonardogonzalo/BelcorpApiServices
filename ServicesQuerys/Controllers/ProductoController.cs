﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Belcorp.ServicesQuerys.Domain.Supervisor;
using Belcorp.ServicesQuerys.Entities;
using Belcorp.ServicesQuerys.Entities.OfertaCatalogo;
using Belcorp.ServicesQuerys.Entities.EStockFicticio;
using Belcorp.ServicesQuerys.Entities.ETombola;

namespace ServicesQuerys.Controllers
{
    [Produces("application/json")]
    [Route("api/Producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ISMatrizProducto isMatrizProducto;

        public ProductoController(ISMatrizProducto _isMatrizProducto) {

            isMatrizProducto = _isMatrizProducto;
        }

        [HttpPost("Ofertas_catalogo")]
        public async Task<ObjOfertaCatalogos> Ofertas_catalogo([FromBody]EInputOfertaCatalogo eInputOferta) {

            ObjOfertaCatalogos objOferta = new ObjOfertaCatalogos();
            try {

                return await isMatrizProducto.Ofertas_catalogo(eInputOferta);
            }
            catch (Exception ex) {
                objOferta.msjerror = ex.Message.ToString();
            }

            return objOferta;

        }

        [HttpPost("MatrizProductoProl")]
        public async Task<List<MatrizProducto>> MatrizProductoProl([FromBody]FiltroMatrizProducto filtroMatrizProducto) {

            List<MatrizProducto> matriz = new List<MatrizProducto>();
            try {

                return (await isMatrizProducto.GetMatrizProductoProl(filtroMatrizProducto.pais, filtroMatrizProducto.periodo, filtroMatrizProducto.cuv));
            }
            catch (Exception ex)
            {


                matriz.Add(new MatrizProducto() { msjError = ex.Message });

                return matriz;

            }

        }

        [HttpPost("ListarMatrizPromociones")]
        public async Task<List<MatrizPromocion>> ListarMatrizPromociones([FromBody]FiltroMatrizPromo filtroMatrizPromo)
        {
            List<MatrizPromocion> matriz = new List<MatrizPromocion>();
            try
            {

                return (await isMatrizProducto.ListaMatrizPromociones(filtroMatrizPromo.pais, filtroMatrizPromo.periodo, filtroMatrizPromo.tipoCatalogo));
            }
            catch (Exception ex)
            {


                matriz.Add(new MatrizPromocion() { msjError = ex.Message });

                return matriz;

            }
        }
        [HttpPost("ListarMatrizPromocionNivel")]
        public async Task<List<MatrizPromocionNivel>> ListarMatrizPromocionNivel([FromBody]FiltroMatrizPromo filtroMatrizPromo)
        {
            List<MatrizPromocionNivel> matriz = new List<MatrizPromocionNivel>();
            try
            {

                return (await isMatrizProducto.ListaMatrizPromocionesNivel(filtroMatrizPromo.pais, filtroMatrizPromo.periodo, filtroMatrizPromo.tipoCatalogo));
            }
            catch (Exception ex)
            {
                matriz.Add(new MatrizPromocionNivel() { msjError = ex.Message });

                return matriz;

            }
        }

        [HttpPost("ConsultaStockPorSap")]

        public async Task<List<StockSapBin>> ConsultaStockSap([FromBody] FConsultaStock FiltroConsultaStock) {

            List<StockSapBin> stockSapBins = new List<StockSapBin>();

            try
            {
                /**Si esta en sus días de facturación**/
                if (FiltroConsultaStock.FlagFacturacion == 1)
                {
                    return (await isMatrizProducto.ConsultarStockSapFacturacion(FiltroConsultaStock.Pais, FiltroConsultaStock.Campania, FiltroConsultaStock.ListaSap));
                }

                /**Si esta fuera de sus días de facturación - Días Venta**/

                return (await isMatrizProducto.ConsultarStockSapVenta(FiltroConsultaStock.Pais, FiltroConsultaStock.Campania, FiltroConsultaStock.ListaSap));
            }
            catch (Exception ex)
            {
                stockSapBins.Add(new StockSapBin() { CodigoSap="0" });
            }

            return stockSapBins;
        }

        [HttpPost("CargaStockFicticio")]
        public async Task<RpFicticioWeb> CargaStockFicticio([FromBody]RsFicticioWeb rsFicticioWeb) {

            RpFicticioWeb respuesta = new RpFicticioWeb();
            try
            {
                respuesta=await isMatrizProducto.CargarFictio(rsFicticioWeb);

            }
            catch (Exception ex) {
                respuesta.mensaje= ex.Message.ToString();
            }

            return respuesta;
        }

        [HttpPost("ConfiguracionTombola")]
        public async Task<RpTombolaWeb> ConfiguracionTombola([FromBody]RsTombolaWeb rsTombolaWeb)
        {
            RpTombolaWeb respuesta = new RpTombolaWeb();
            try
            {
                respuesta = await isMatrizProducto.CargarTombola(rsTombolaWeb);
            }
            catch (Exception ex) {
                respuesta.mensaje = ex.Message.ToString();
            }

            return respuesta;

        }


    }
}