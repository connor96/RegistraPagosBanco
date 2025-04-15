using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blRecepcionDetalle
    {
        List<beRecepcionDetalle> lisRecepcionDetalle;
        beRecepcionDetalle itmRecepcionDetalle;
        beReturn itmReturn;

        daRecepcionDetalle objRecepcionDetalle = new daRecepcionDetalle();

        public List<beRecepcionDetalle> ListaPorRegistro(int intIdRecepcion)
        {
            lisRecepcionDetalle = new List<beRecepcionDetalle>();
            lisRecepcionDetalle = objRecepcionDetalle.ListaPorRegistro(intIdRecepcion);
            return lisRecepcionDetalle;
        }
        public List<beRecepcionDetalle> ListaNulosPorRegistro(int intIdRecepcion)
        {
            lisRecepcionDetalle = new List<beRecepcionDetalle>();
            lisRecepcionDetalle = objRecepcionDetalle.ListaNulosPorRegistro(intIdRecepcion);
            return lisRecepcionDetalle;
        }
        public beRecepcionDetalle Detalle(int intIdRecepcionDetalle)
        {
            itmRecepcionDetalle = new beRecepcionDetalle();
            itmRecepcionDetalle = objRecepcionDetalle.Detalle(intIdRecepcionDetalle);
            return itmRecepcionDetalle;
        }
        public beReturn Insert(beRecepcionDetalle myitmRecepcionDetalle)
        {
            itmReturn = new beReturn();
            itmReturn = objRecepcionDetalle.Insert(myitmRecepcionDetalle);
            return itmReturn;
        }
        public beReturn UpdateComprobante(int intIdRecepcionDetalle, string IdComprobante)
        {
            itmReturn = new beReturn();
            itmReturn = objRecepcionDetalle.UpdateComprobante(intIdRecepcionDetalle, IdComprobante);
            return itmReturn;
        }

    }
}
