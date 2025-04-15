using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blDetalleComprobante
    {
        List<beDetalleComprobante> lisDetalleComprobante;
        beDetalleComprobante itmDetalleComprobante;
        beReturn itmReturn;

        daDetalleComprobante objDetalleComprobante = new daDetalleComprobante();
        public beReturn Insert(beDetalleComprobante myitmDetalleComprobante)
        {
            itmReturn = new beReturn();
            itmReturn = objDetalleComprobante.Insert(myitmDetalleComprobante);
            return itmReturn;
        }
    }
}
