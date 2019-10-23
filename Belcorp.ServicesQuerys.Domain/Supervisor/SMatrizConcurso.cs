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
            ConcursoPaisCampania oconcursoPaisCampania;

            List<ConcursoPremioRango> listconcursoPremioRangos = new List<ConcursoPremioRango>();
            List<ConcursoPaisCampania> oListconcursoPaisCampania = new List<ConcursoPaisCampania>();



            listconcursoPremioRangos = await imatrizConcurso.GetRangoConcurso(isoPais, periodo);

            
            int contador = 1;
            string campania = string.Empty;
            int numero_nivel = 0;
            int numero_rango_item = 0;


            foreach (var item in listconcursoPremioRangos)
            {
                campania = item.cod_periodo;
                numero_nivel = item.numero_nivel;
                numero_rango_item = item.numero_rango;

                if (!oListconcursoPaisCampania.Exists(i=>i.cod_periodo==campania&i.numero_nivel==numero_nivel&i.numero_rango==numero_rango_item)){

                    oconcursoPaisCampania = new ConcursoPaisCampania();
                    oconcursoPaisCampania.cod_periodo = item.cod_periodo;
                    oconcursoPaisCampania.numero_nivel = item.numero_nivel;
                    oconcursoPaisCampania.numero_rango = item.numero_rango;
                    oconcursoPaisCampania.rango_inferior = item.rango_inferior;
                    oconcursoPaisCampania.rango_superior = item.rango_superior;
                    oListconcursoPaisCampania.Add(oconcursoPaisCampania);
                }


            }


            foreach (var item in oListconcursoPaisCampania) {



                    numero_rango_item = item.numero_rango;

                    rangoConcurso = new RangoConcurso();
                   
                    rangoConcurso.codigoPeriodo = item.cod_periodo;
                    rangoConcurso.numeroRango = item.numero_rango;
                    rangoConcurso.rangoInferior = (item.rango_inferior).ToString();
                    rangoConcurso.rangoSuperior = (item.rango_superior).ToString();

                foreach (var itempremio in listconcursoPremioRangos.FindAll(itempremio=> itempremio.numero_rango==numero_rango_item)) {
                    rangoPremio = new RangoPremio();
                    rangoPremio.codigoVenta = itempremio.cod_venta;
                    rangoPremio.codigoEstrategia = itempremio.estrategia;
                    rangoPremio.numeroNivel = itempremio.numero_nivel;
                    rangoPremio.indicadorDigitable = itempremio.digitable;
                    rangoPremio.cantidad = itempremio.unidad;

                    rangoConcurso.listaPremio.Add(rangoPremio);

                    contador++;
                }


                    lisrangoConcursos.Add(rangoConcurso);
  
            }


            return lisrangoConcursos;
        }
    }
}
