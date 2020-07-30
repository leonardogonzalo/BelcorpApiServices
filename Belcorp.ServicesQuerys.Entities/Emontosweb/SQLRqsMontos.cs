using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities.Emontosweb
{
    public class SQLRqsMontos
    {
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public string monto_total_descuento { get; set; }
        public string monto_escala { get; set; }
        public string ahorro_revista { get; set; }
        public string ahorro_catalogo { get; set; }
    }
}
