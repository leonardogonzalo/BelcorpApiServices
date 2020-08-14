using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Entities;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities.OfertaCatalogo;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public class SMatrizProducto : ISMatrizProducto
    {

        IMatrizProducto<MatrizProducto> iMatrizProducto;

        public SMatrizProducto(IMatrizProducto<MatrizProducto> _iMatrizProducto) {

            iMatrizProducto = _iMatrizProducto;
        }

        public async Task<List<StockSapBin>> ConsultarStockSapFacturacion(string isoPais, string periodo, string lcodigosap)
        {
            return await iMatrizProducto.ConsultarStockSapFacturacion(isoPais, periodo, lcodigosap);
        }

        public async Task<List<StockSapBin>> ConsultarStockSapVenta(string isoPais, string periodo, string lcodigosap)
        {
            return await iMatrizProducto.ConsultarStockSapVenta(isoPais, periodo, lcodigosap);
        }

        public async Task<List<MatrizProducto>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs)
        {
            return await iMatrizProducto.GetMatrizProductoProl(isoPais,periodo,cuvs);
        }

        public async Task<List<MatrizPromocion>> ListaMatrizPromociones(string isoPais, string periodo, string tipocatalogo)
        {
            return await iMatrizProducto.ListaMatrizPromociones(isoPais, periodo, tipocatalogo);
        }

        public async Task<List<MatrizPromocionNivel>> ListaMatrizPromocionesNivel(string isoPais, string periodo, string tipocatalogo)
        {
            return await iMatrizProducto.ListaMatrizPromocionesNivel(isoPais, periodo, tipocatalogo);
        }

        public async Task<ObjOfertaCatalogos> Ofertas_catalogo(EInputOfertaCatalogo ofertaCatalogo)
        {
            var result = await iMatrizProducto.Ofertas_catalogo(ofertaCatalogo);

            return result;

                
        }
    }
}
