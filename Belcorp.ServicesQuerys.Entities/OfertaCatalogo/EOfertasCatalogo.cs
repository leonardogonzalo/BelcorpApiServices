using System;
using System.Collections.Generic;
using System.Text;

namespace Belcorp.ServicesQuerys.Entities.OfertaCatalogo
{
   public class ObjOfertaCatalogos
    {
        public ObjOfertaCatalogos() { }

        public string tipo_oferta { get; set; }

        public string cuv_catalogo { get; set; }
        public string sap_catalogo { get; set; }
        public string precio_catalogo { get; set; }

        public string cuv_revista { get; set; }
        public string sap_revista { get; set; }
        public string precio_revista { get; set; }

        public string ganancia { get; set; }

        public List<ObjNivel> lista_ObjNivel = new List<ObjNivel>();

        public List<ObjGratis> lista_oObjGratis = new List<ObjGratis>();

        public List<ObjPack> lista_oObjPack = new List<ObjPack>();

        public List<ObjItemPack> lista_oObjItemPack = new List<ObjItemPack>();

        public string msjerror { get; set; }

    }

    public class ObjNivel
    {
        public ObjNivel() { }

        public string escala_nivel { get; set; }
        public string nombre_nivel { get; set; }
        public string precio_nivel { get; set; }

        public string ganancia_nivel { get; set; }


    }

    public class ObjGratis
    {
        public ObjGratis() { }
        public string escala_nivel_gratis { get; set; }
        public int cantidad { get; set; }
        public string codsap_nivel_gratis { get; set; }
        public string descripcion_gratis { get; set; }

        public string imagen_gratis { get; set; }
        public string volumen { get; set; }


    }

    public class ObjPack
    {
        public ObjPack() { }

        public string cuv_pack { get; set; }
        public string nombre_pack { get; set; }
        public string precio_pack { get; set; }
        public string valorizado { get; set; }
        public string ganancia_pack { get; set; }




    }

    public class ObjItemPack
    {
        public ObjItemPack() { }
        public string cuv_pack_item { get; set; }
        public string cuv_item { get; set; }
        public string descripcion_item_pack { get; set; }
        public string cantidad_item_pack { get; set; }
        public string codsap_item_pack { get; set; }

        public string imagen_item_pack { get; set; }

        public string volumen { get; set; }
    }

}
