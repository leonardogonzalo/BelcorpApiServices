using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Entities.Emontosweb;

namespace Belcorp.ServicesQuerys.Domain.Supervisor
{
    public class SMontosWeb : ISMontosWeb
    {
        IMontosWeb _IMontosWeb;

        public SMontosWeb(IMontosWeb _IMontosWeb) {
                this._IMontosWeb = _IMontosWeb;
        }

        public async Task<List<MontosPROL>> MontosWeb(RqMontosWeb rqMontosWeb)
        {
            List<SQLRqsMontos> _listSQLRqsMontos = new List<SQLRqsMontos>();
            List<MontosPROL> _listMontos = new List<MontosPROL>();
            MontosPROL montos = new MontosPROL();

            /**adicionales**/
            List<ConcursoIncentivos> listconcursoIncentivos = new List<ConcursoIncentivos>();
            List<MensajeCondicional> listmensajeCondicionals = new List<MensajeCondicional>();
            ConcursoIncentivos oConcursoIncentivos;
            MensajeCondicional oMensajeCondicional;

            try
            {
                
                _listSQLRqsMontos = await _IMontosWeb.MontosWeb(rqMontosWeb);

                if (_listSQLRqsMontos.Exists(f => f.tipo == "_M")) {

                    var item = _listSQLRqsMontos.Find(f => f.tipo == "_M");

                    montos.AhorroCatalogo = item.ahorro_catalogo;
                    montos.AhorroRevista =item.ahorro_revista;
                    montos.MontoEscala = item.monto_escala;
                    montos.MontoTotalDescuento = item.monto_total_descuento;
                }
                if (_listSQLRqsMontos.Exists(f => f.tipo == "_I"))
                {
                    foreach (var item in _listSQLRqsMontos.FindAll(f=>f.tipo=="_I")) {
                        oConcursoIncentivos = new ConcursoIncentivos();
                        oConcursoIncentivos.codigoconcurso = item.descripcion;
                        oConcursoIncentivos.puntajeconcurso = item.monto_total_descuento;
                        listconcursoIncentivos.Add(oConcursoIncentivos);
                    }
                    montos.ListaConcursoIncentivos=listconcursoIncentivos;
                }
                if (_listSQLRqsMontos.Exists(f => f.tipo == "_C"))
                {
                    foreach (var item in _listSQLRqsMontos.FindAll(f => f.tipo == "_C")) {
                        oMensajeCondicional = new MensajeCondicional();
                        oMensajeCondicional.CodigoMensaje = item.descripcion;
                        oMensajeCondicional.Mensaje = item.monto_total_descuento;
                        listmensajeCondicionals.Add(oMensajeCondicional);
                    }
                    montos.ListaMensajeCondicional = listmensajeCondicionals;
                }

                /*adiciona el resultado final de montos*/
                    _listMontos.Add(montos);

            }
            catch {

                throw;

            }


            return _listMontos;

        }
    }
}
