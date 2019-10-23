using System.Collections.Generic;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Entities;
namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public interface ISValidadorActivacionProl
    {
        Task<List<ValidadorActivacionProl>> ValidarActivacionProl(string pais);
    }
}
