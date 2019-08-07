﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Entities;
using Belcorp.ServicesQuerys.Domain.Interfaces;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public class SMatrizProducto : ISMatrizProducto
    {

        IMatrizProducto<MatrizProducto> iMatrizProducto;

        public SMatrizProducto(IMatrizProducto<MatrizProducto> _iMatrizProducto) {

            iMatrizProducto = _iMatrizProducto;
        }

        public async Task<List<MatrizProducto>> GetMatrizProductoProl(string isoPais,string periodo,string cuvs)
        {
            return await iMatrizProducto.GetMatrizProductoProl(isoPais,periodo,cuvs);
        }

        public async Task<List<MatrizPromocion>> ListaMatrizPromociones(string isoPais, string periodo, string tipocatalogo)
        {
            return await iMatrizProducto.ListaMatrizPromociones(isoPais, periodo, tipocatalogo);
        }

        public async Task<List<MatrizPromocionNivel>> ListaMatrizPromocionesNivel(string isoPais, string periodo, string tipocatalogo)
        {
            return await iMatrizProducto.ListaMatrizPromocionesNivel(isoPais, periodo, tipocatalogo);
        }
    }
}
