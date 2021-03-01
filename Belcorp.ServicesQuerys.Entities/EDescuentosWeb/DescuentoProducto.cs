using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities.EDescuentosWeb
{
    public class DescuentoProducto
    {
        public string codigoVenta { get; set; }
        public decimal porcentajeDescuento { get; set; }
        public decimal montoSubtotalProducto { get; set; }
        public decimal montoTotalDescuento { get; set; }
        public string tipoDescuento { get; set; }
        public string error { get; set; }

    }
}
