using Belcorp.ServicesQuerys.Entities.Emontosweb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public interface ISMontosWeb
    {
        Task<List<MontosPROL>> MontosWeb(RqMontosWeb rqMontosWeb);
    }
}
