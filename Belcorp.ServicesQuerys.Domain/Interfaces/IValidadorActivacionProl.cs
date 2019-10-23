using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Interfaces
{
    public interface IValidadorActivacionProl <T> where T:class
    {
        Task<List<T>> ValidarActivacionProl(string pais);
    }
}
