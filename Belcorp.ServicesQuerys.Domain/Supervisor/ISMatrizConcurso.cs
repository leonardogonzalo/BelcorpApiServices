using Belcorp.ServicesQuerys.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public interface ISMatrizConcurso
    {
        Task<List<RangoConcurso>> GetRangoConcurso(string isoPais, string periodo);
    }
}
