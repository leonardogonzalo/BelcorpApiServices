using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities
{
    public class RangoConcurso
    {
        public string codigoPeriodo { get; set; }
        public int numeroRango { get; set; }
        public string rangoInferior{ get; set; }
        public string rangoSuperior{ get; set; }
        public List<RangoPremio> listaPremio = new List<RangoPremio>();
        public string msjerror { get; set; }
    }
}
