using Microsoft.AspNetCore.Mvc;
using Belcorp.ServicesQuerys.Domain.Supervisor;
using System.Threading.Tasks;
using System.Collections.Generic;
using Belcorp.ServicesQuerys.Entities.Emontosweb;
using System;
using Belcorp.ServicesQuerys.Entities.EmontosWebNiveles;

namespace ServicesQuerys.Controllers
{
    [Produces("application/json")]
    [Route("api/MontosWeb")]
    public class MontosWebController : ControllerBase
    {
        public readonly ISMontosWeb iSMontoWeb;


        public MontosWebController(ISMontosWeb _iSMontoWeb) {
            this.iSMontoWeb = _iSMontoWeb;
        }

        [HttpPost("PostMontosWeb")]
        public async Task<MontosPROL> PostMontosWeb([FromBody] RqMontosWeb rqMontosWeb) {

            //List<MontosPROL> listmontosPROL;
            MontosPROL montosPROL;
            try
            {

                return (await (iSMontoWeb.MontosWeb(rqMontosWeb)))[0];

            }
            catch (Exception ex)
            {
                //listmontosPROL = new List<MontosPROL>();
                montosPROL = new MontosPROL();
                montosPROL.MontoEscala = "0";
                montosPROL.MontoTotalDescuento = "0";
                montosPROL.AhorroCatalogo = "0";
                montosPROL.AhorroRevista = "0";
                montosPROL.msjerror = ex.Message.ToString();
                //listmontosPROL.Add(montosPROL);

            }
            
            return montosPROL;

        }

        [HttpPost("MontoFestivalNivel")]
        public async Task<FestivalDescuentoNivel> MontoFestivalNivel([FromBody] EFestival festival) {

            FestivalDescuentoNivel listFestivalesDescuento = new FestivalDescuentoNivel();

            try {

                listFestivalesDescuento = await iSMontoWeb.MontoFestivalNivel(festival);
            }
            catch (Exception ex) {

                listFestivalesDescuento.periodo = "0";
                listFestivalesDescuento.cuvFestival = "0";
                listFestivalesDescuento.montoTotalApoyo = "0";
                listFestivalesDescuento.montoDescuentoNivel = "0";
                listFestivalesDescuento.msjerror = ex.Message.ToString();
                

            }

            return listFestivalesDescuento;

        }


    }
}