using Belcorp.ServicesQuerys.Entities.Emontosweb;
using Belcorp.ServicesQuerys.Entities.EmontosWebNiveles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belcorp.ServicesQuerys.Domain.Interfaces
{
    public interface IMontosWeb 
    {
        Task<List<SQLRqsMontos>> MontosWeb(RqMontosWeb rqMontosWeb);
        Task<FestivalDescuentoNivel> MontoFestivalNivel(EFestival festival);
    }
}
