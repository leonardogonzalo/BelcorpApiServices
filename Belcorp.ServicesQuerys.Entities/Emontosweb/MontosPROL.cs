using System;
using System.Collections.Generic;


namespace Belcorp.ServicesQuerys.Entities.Emontosweb
{
    public class MontosPROL
    {
        public string MontoTotalDescuento { get; set; }
        public string MontoEscala { get; set; }
        public string AhorroCatalogo { get; set; }
        public string AhorroRevista { get; set; }
        public List<ConcursoIncentivos> ListaConcursoIncentivos { get; set; }
        public string observacion { get; set; }
        public List<MensajeCondicional> ListaMensajeCondicional { get; set; }
        public string msjerror { get; set; }
    }
}
