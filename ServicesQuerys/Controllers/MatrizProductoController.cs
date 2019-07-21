using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Belcorp.ServicesQuerys.Domain.Supervisor;
using Belcorp.ServicesQuerys.Entities;

namespace ServicesQuerys.Controllers
{
    [Produces("application/json")]
    [Route("api/MatrizProducto")]
    public class MatrizProductoController : ControllerBase
    {
        private readonly ISMatrizProducto isMatrizProducto;

        public MatrizProductoController(ISMatrizProducto _isMatrizProducto) {

            isMatrizProducto = _isMatrizProducto;
        }

        [HttpPost("getMatrizProductoProl")]
        public async Task<List<MatrizProducto>> getMatrizProductoProl([FromBody]FiltroMatrizProducto filtroMatrizProducto) {

            List<MatrizProducto> matriz = new List<MatrizProducto>();
            try {

                return (await isMatrizProducto.GetMatrizProductoProl(filtroMatrizProducto.pais,filtroMatrizProducto.periodo,filtroMatrizProducto.cuv));
            }
            catch (Exception ex)
            {


                matriz.Add(new MatrizProducto() { msjError=ex.Message});

                return matriz;

            }

        }


    }
}