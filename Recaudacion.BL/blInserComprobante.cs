using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blInserComprobante
    {
        beInserComprobante itmInserComprobante;
        beReturn itmReturn;
        beNroComprobante itmNroComprobante;
        beComprobante itmComprobante;
        blComprobante objComprobante = new blComprobante();
        daInserComprobante objInserComprobante = new daInserComprobante();
        public beInserComprobante SearchByInsert(int intIdRecepcionDetalle, int IdTipoComprobante, string User, string terminal)
        {
            itmInserComprobante = new beInserComprobante();
            itmInserComprobante = objInserComprobante.SearchByInsert(intIdRecepcionDetalle, IdTipoComprobante, User, terminal);
            return itmInserComprobante;
        }

        public beReturn Insert(beRecepcionDetalle myitmRecepcionDetalle, string User, string terminal)
        {
            itmInserComprobante = new beInserComprobante();
            itmInserComprobante = SearchByInsert(myitmRecepcionDetalle.intIdRecepcionDetalle, 3, User, terminal);

            itmReturn = new beReturn();
            itmNroComprobante = new beNroComprobante();
            itmNroComprobante = ActualizaNumeracion(3, itmInserComprobante.IdTipoComprobante.ToString(), User);
            int intResultado = objComprobante.BuscarNroRecibo(itmInserComprobante.IdTipoComprobante, itmInserComprobante.Serie, itmInserComprobante.Numero);
            if (intResultado == 0)
            {
                itmReturn = objInserComprobante.Insert(itmInserComprobante);
                if (itmReturn.intIdReturn > 0)
                {
                    if (Convert.ToInt32(itmInserComprobante.Numero) < Convert.ToInt32(itmNroComprobante.Final))
                    {
                        itmNroComprobante = ActualizaNumeracion(4, itmInserComprobante.IdTipoComprobante.ToString(), User);
                    }
                }
            }
            else
            {
                if (Convert.ToInt32(itmInserComprobante.Numero) < Convert.ToInt32(itmNroComprobante.Final))
                {
                    itmNroComprobante = ActualizaNumeracion(4, itmInserComprobante.IdTipoComprobante.ToString(), User);
                }
                itmReturn.intIdReturn = 0;
                itmReturn.strReturn = "El comprobante " + itmInserComprobante.Serie + "-" + itmInserComprobante.Numero + " asignado ya existe";
            }
            return itmReturn;
        }

        public beNroComprobante ActualizaNumeracion(int Tipo, string Busqueda, string IdUser)
        {
            return objInserComprobante.ActualizaNumeracion(Tipo, Busqueda, IdUser);
        }

    }
}
