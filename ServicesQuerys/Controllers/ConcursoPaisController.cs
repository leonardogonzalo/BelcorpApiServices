using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Domain.Supervisor;
using Belcorp.ServicesQuerys.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServicesQuerys.Controllers
{
    [Produces("application/json")]
    [Route("api/ConcursoPais")]
    public class ConcursoPaisController : ControllerBase
    {
        public readonly ISMatrizConcurso isMatrizConcurso;

        public ConcursoPaisController(ISMatrizConcurso _isMatrizConcurso) {

            isMatrizConcurso = _isMatrizConcurso;
        }

        [HttpPost("RangoConcursoPais")]
        public async Task<List<RangoConcurso>> RangoConcursoPais([FromBody] FiltroConsultaGenerica filtrogenerico) {

            List<RangoConcurso> lsrangoConcursos = new List<RangoConcurso>();
            RangoConcurso rangoConcurso;

            try
            {
                return (await isMatrizConcurso.GetRangoConcurso(filtrogenerico.Pais, filtrogenerico.CodigoPeriodo));
            }
            catch (Exception ex)
            {
                rangoConcurso = new RangoConcurso();

                rangoConcurso.msjerror = ex.Message.ToString();

                lsrangoConcursos.Add(rangoConcurso);

            }

            return lsrangoConcursos;

        }


    }
}