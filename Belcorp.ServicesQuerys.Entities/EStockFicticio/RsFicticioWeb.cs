using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities.EStockFicticio
{
    public class RsFicticioWeb
    {
        public string isoPais { get; set; }
        public string periodo { get; set; }
        public string listaSap { get; set; }
        public string listaUnidades { get; set; }
        public string tipoCarga { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
    }
}
