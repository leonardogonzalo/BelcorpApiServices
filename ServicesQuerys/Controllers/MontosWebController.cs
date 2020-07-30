using Microsoft.AspNetCore.Mvc;
using Belcorp.ServicesQuerys.Domain.Supervisor;
using System.Threading.Tasks;
using System.Collections.Generic;
using Belcorp.ServicesQuerys.Entities.Emontosweb;
using System;

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


    }
}