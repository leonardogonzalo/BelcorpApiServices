using Belcorp.ServicesQuerys.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Interfaces
{
    public interface IMatrizConcurso <T> where T:class
    {
        Task<List<ConcursoPremioRango>> GetRangoConcurso(string isoPais, string periodo);
    }
}
