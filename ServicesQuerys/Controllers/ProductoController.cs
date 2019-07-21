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
    [Route("api/Producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ISMatrizProducto isMatrizProducto;

        public ProductoController(ISMatrizProducto _isMatrizProducto) {

            isMatrizProducto = _isMatrizProducto;
        }

        [HttpPost("MatrizProductoProl")]
        public async Task<List<MatrizProducto>> MatrizProductoProl([FromBody]FiltroMatrizProducto filtroMatrizProducto) {

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