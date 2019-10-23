using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities
{
    public class ConcursoPaisCampania
    {
        public string cod_periodo { get; set; }
        public int numero_nivel { get; set; }
        public int numero_rango { get; set; }
        public decimal rango_inferior { get; set; }
        public decimal rango_superior { get; set; }
    }
}
