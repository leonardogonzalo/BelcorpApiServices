using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Entities;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public interface ISMatrizProducto
    {
        Task<List<MatrizProducto>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs);
        Task<List<MatrizPromocion>> ListaMatrizPromociones(string isoPais, string periodo, string tipocatalogo);

        Task<List<MatrizPromocionNivel>> ListaMatrizPromocionesNivel(string isoPais, string periodo, string tipocatalogo);

    }
}
