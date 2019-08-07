using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities
{
    public class MatrizPromocion
    {
        public string cod_venta { get; set; }
        public int factor_repeticion { get; set; }
        public string des_producto { get; set; }
        public string cod_producto { get; set; }
        public decimal precio_unitario { get; set; }
        public int pag_catalogo { get; set; }
        public int ind_promocion { get; set; }
        public decimal factor_cuadre { get; set; }
        public int ind_apoya_promo { get; set; }
        public string msjError { get; set; }

    }
}
