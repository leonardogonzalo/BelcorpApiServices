using System;
using System.Collections.Generic;
using System.Text;


namespace Belcorp.ServicesQuerys.Entities
{
    public class MatrizProducto
    {
        public string campania { get; set; }
        public string codigoVenta { get; set;}
        public bool esCupon { get; set;}
        public string codigoCupon { get; set;}
        public string codigoEstrategia { get; set; }
        public string descripcionEstrategia { get; set;}
        public int cantidadA { get; set;}
        public decimal precioUnitario { get; set;}
        public int digitable { get; set; }
        public int indicadorDespachoCompleto { get; set; }
        public bool indicaodrDespachoAutomatico { get; set; }
        public string codigoSap { get; set; }
        public string descripcionCatalogo { get; set;}
        public string paginaCatalogo { get; set;}
        public bool indicadorProductoComisionable { get; set; }
        public bool indicadorAportaEscala { get; set; }
        public string marcaProducto { get; set; }
        public string unidadNegocio { get; set; }
        public int ubicacionFactura { get; set; }

        public string msjError { get; set; }


    }
}
