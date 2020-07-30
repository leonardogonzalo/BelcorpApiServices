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
        public string des_producto { get; set; }
        public int oid_producto { get; set; }
        public int numero_oferta { get; set; }
        public string codigoEstrategia { get; set; }
        public string descripcionEstrategia { get; set;}
        public int factor_repeticion { get; set; }
        public int cantidadA { get; set;}
        public decimal precioUnitario { get; set;}
        public decimal precioNeto { get; set; }
        public decimal precioPublico { get; set; }
        public int digitable { get; set; }
        public int ind_DespachoCompleto { get; set; }
        public bool ind_DespachoAutomatico { get; set; }
        public string codigoSap { get; set; }
        public string descripcionCatalogo { get; set;}
        public string paginaCatalogo { get; set;}
        public int numero_nivel { get; set; }
        public bool indicadorProductoComisionable { get; set; }
        public bool indicadorAportaEscala { get; set; }
        public string marcaProducto { get; set; }
        public string unidadNegocio { get; set; }
        public int tiene_Gestion_Stock { get; set; }
        public int tiene_reemplazo { get; set; }
        public int es_exclusivo { get; set; }
        public int ubicacionFactura { get; set; }

        public string msjError { get; set; }


    }
}
