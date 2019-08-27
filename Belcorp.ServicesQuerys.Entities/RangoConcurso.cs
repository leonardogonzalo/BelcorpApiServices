using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities
{
    public class RangoConcurso
    {
        public string CodigoPeriodo { get; set; }
        public string RangoInferior{ get; set; }
        public string RangoSuperior{ get; set; }
        public List<RangoPremio> ListaPremio { get; set; }
        public string msjerror { get; set; }
    }
}
