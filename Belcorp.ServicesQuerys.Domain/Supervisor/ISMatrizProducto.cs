using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Entities;
using Belcorp.ServicesQuerys.Entities.EStockFicticio;
using Belcorp.ServicesQuerys.Entities.ETombola;
using Belcorp.ServicesQuerys.Entities.OfertaCatalogo;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public interface ISMatrizProducto
    {
        Task<List<MatrizProducto>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs);
        Task<List<MatrizPromocion>> ListaMatrizPromociones(string isoPais, string periodo, string tipocatalogo);

        Task<List<MatrizPromocionNivel>> ListaMatrizPromocionesNivel(string isoPais, string periodo, string tipocatalogo);

        Task<List<StockSapBin>> ConsultarStockSapVenta(string isoPais, string periodo, string lcodigosap);
        Task<List<StockSapBin>> ConsultarStockSapFacturacion(string isoPais, string periodo, string lcodigosap);

        Task<ObjOfertaCatalogos> Ofertas_catalogo(EInputOfertaCatalogo ofertaCatalogo);

        Task<RpFicticioWeb> CargarFictio(RsFicticioWeb rsqFicticioWeb);
        Task<RpTombolaWeb> CargarTombola(RsTombolaWeb rsTombolaWeb);
    }
}
