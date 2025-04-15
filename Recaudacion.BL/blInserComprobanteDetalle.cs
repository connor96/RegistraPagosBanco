using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blInserComprobanteDetalle
    {
        beInserComprobanteDetalle itmInserComprobanteDetalle;
        beReturn itmReturn;
        List<beInserComprobanteDetalle> lisInserComprobanteDetalle = new List<beInserComprobanteDetalle>();
        daInserComprobanteDetalle objInserComprobanteDetalle = new daInserComprobanteDetalle();
        public List<beInserComprobanteDetalle> SearchByInsert(int intIdRecepcionDetalle, string IdComprobante, string User, string terminal)
        {
            lisInserComprobanteDetalle = new List<beInserComprobanteDetalle>();
            lisInserComprobanteDetalle = objInserComprobanteDetalle.SearchByInsert(intIdRecepcionDetalle, IdComprobante, User, terminal);
            return lisInserComprobanteDetalle;
        }

        public beReturn Insert(beInserComprobanteDetalle itmInserComprobanteDetalle)
        {
            itmReturn = new beReturn();
            itmReturn = objInserComprobanteDetalle.Insert(itmInserComprobanteDetalle);
            return itmReturn;
        }

    }
}
