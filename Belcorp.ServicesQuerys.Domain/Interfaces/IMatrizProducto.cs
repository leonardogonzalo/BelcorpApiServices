using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Interfaces
{
    public interface IMatrizProducto <T> where T:class
    {
        Task<List<T>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs);

    }
}
