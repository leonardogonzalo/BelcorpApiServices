using System.Collections.Generic;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public class SMatrizConcurso : ISMatrizConcurso
    {
        IMatrizConcurso<RangoConcurso> imatrizConcurso;

        public SMatrizConcurso(IMatrizConcurso<RangoConcurso> _imatrizConcurso) {

            imatrizConcurso = _imatrizConcurso;
        }
        
        public async Task<List<RangoConcurso>> GetRangoConcurso(string isoPais, string periodo)
        {
            return await imatrizConcurso.GetRangoConcurso(isoPais,periodo);
        }
    }
}
