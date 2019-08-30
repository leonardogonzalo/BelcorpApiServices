namespace Belcorp.ServicesQuerys.Entities
{
    public class ConcursoPremioRango
    {
        public string cod_periodo { get; set; }
        public int numero_nivel { get; set; }
        public int numero_rango { get; set; }
        public string cod_venta { get; set; }
        public int estrategia { get; set; }
        public int digitable { get; set; }
        public int unidad { get; set; }
        public decimal rango_inferior { get; set; }
        public decimal rango_superior { get; set; }
    }
}
