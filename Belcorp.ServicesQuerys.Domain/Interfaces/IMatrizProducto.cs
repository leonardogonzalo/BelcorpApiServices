using Belcorp.ServicesQuerys.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Interfaces
{
    public interface IMatrizProducto <T> where T:class
    {
        Task<List<T>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs);
        Task<List<MatrizPromocion>> ListaMatrizPromociones(string isoPais, string periodo, string tipocatalogo);

        Task<List<MatrizPromocionNivel>> ListaMatrizPromocionesNivel(string isoPais, string periodo, string tipocatalogo);

        Task<List<StockSapBin>> ConsultarStockSapVenta(string isoPais, string periodo, string lcodigosap);
        Task<List<StockSapBin>> ConsultarStockSapFacturacion(string isoPais, string periodo, string lcodigosap);

    }
}
