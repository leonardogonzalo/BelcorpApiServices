using Belcorp.ServicesQuerys.Entities;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public class SValidadorActivacionProl : ISValidadorActivacionProl
    {
        IValidadorActivacionProl<ValidadorActivacionProl> ivalidadorActivacionProl;

        public SValidadorActivacionProl(IValidadorActivacionProl<ValidadorActivacionProl> _ivalidadorActivacionProl) {
            ivalidadorActivacionProl = _ivalidadorActivacionProl;
        }

        public async Task<List<ValidadorActivacionProl>> ValidarActivacionProl(string pais)
        {
            throw new System.NotImplementedException();
        }
    }
}
