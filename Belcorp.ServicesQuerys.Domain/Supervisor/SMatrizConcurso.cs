using System.Collections.Generic;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public class SMatrizConcurso : ISMatrizConcurso
    {
        IMatrizConcurso<RangoConcurso> imatrizConcurso;

        public SMatrizConcurso(IMatrizConcurso<RangoConcurso> _imatrizConcurso) {

            imatrizConcurso = _imatrizConcurso;
        }
        
        public async Task<List<RangoConcurso>> GetRangoConcurso(string isoPais, string periodo)
        {
            List<RangoConcurso> lisrangoConcursos = new List<RangoConcurso>();

            RangoConcurso rangoConcurso;
            RangoPremio rangoPremio;

            List<ConcursoPremioRango> listconcursoPremioRangos = new List<ConcursoPremioRango>();

            listconcursoPremioRangos= await imatrizConcurso.GetRangoConcurso(isoPais, periodo);

            int contador = 1;
            
            
            foreach(var item in listconcursoPremioRangos) {

                rangoConcurso = new RangoConcurso();
                rangoPremio = new RangoPremio();
                rangoConcurso.codigoPeriodo = item.cod_periodo;
                rangoConcurso.numeroRango = contador;
                rangoConcurso.rangoInferior = (item.rango_inferior).ToString();
                rangoConcurso.rangoSuperior = (item.rango_superior).ToString();


                rangoPremio.codigoVenta = item.cod_venta;
                rangoPremio.codigoEstrategia = item.estrategia;
                rangoPremio.numeroNivel = item.numero_nivel;
                rangoPremio.indicadorDigitable = item.digitable;
                rangoPremio.cantidad = item.unidad;

                rangoConcurso.listaPremio.Add(rangoPremio);

                lisrangoConcursos.Add(rangoConcurso);

                contador++;

            }

            



                
            



            return lisrangoConcursos;
        }
    }
}
