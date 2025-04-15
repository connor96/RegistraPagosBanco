using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blRecepcion
    {
        List<beRecepcion> lisRecepcion;
        beRecepcion itmRecepcion;
        beReturn itmReturn;
        daRecepcion objRecepcion = new daRecepcion();
        daRecepcionDetalle objRecepcionDetalle = new daRecepcionDetalle();
        public List<beRecepcion> ListaPorFechas(DateTime dtmFechaInicio, DateTime dtmFechaFinal)
        {
            lisRecepcion = new List<beRecepcion>();
            lisRecepcion = objRecepcion.ListaPorFechas(dtmFechaInicio, dtmFechaFinal);
            return lisRecepcion;
        }
        public beRecepcion Detalle(int intIdRecepcion)
        {
            itmRecepcion = new beRecepcion();
            itmRecepcion = objRecepcion.Detalle(intIdRecepcion);
            return itmRecepcion;
        }
        public beRecepcion DetalleCodigoInterno(string strCodigoInterno)
        {
            itmRecepcion = new beRecepcion();
            itmRecepcion = objRecepcion.DetalleCodigoInterno(strCodigoInterno);
            return itmRecepcion;
        }
        public beRecepcion DetalleFechaProceso(DateTime dtmFechaProceso)
        {
            itmRecepcion = new beRecepcion();
            itmRecepcion = objRecepcion.DetalleFechaProceso(dtmFechaProceso);
            return itmRecepcion;
        }

        public beReturn Insert(beRecepcion myitmRecepcion)
        {
            itmReturn = new beReturn();
            itmReturn = objRecepcion.Insert(myitmRecepcion);
            return itmReturn;
        }

        public beRecepcion DetalleTXT(string strArchivoTXT,string idUSuario, string PCTerminal="")
        {
            beRecepcion itmRecepciontxt = new beRecepcion();
            itmRecepciontxt = objRecepcion.DetalleTXT(strArchivoTXT);
            itmRecepciontxt.UserRegistro = idUSuario;
            itmReturn = new beReturn();
            itmReturn = InsertByTXT(itmRecepciontxt);
            itmRecepcion = new beRecepcion();
            if (itmReturn.intIdReturn > 0)
            {
                itmRecepcion = Detalle(Convert.ToInt16(itmReturn.strReturn));
                itmRecepcion.lisRecepcionDetalle = objRecepcionDetalle.ListaPorRegistro(itmRecepcion.intIdRecepcion);
            }
            return itmRecepcion;
        }

        public beReturn InsertByTXT(beRecepcion myitmRecepcion)
        {
            itmReturn = new beReturn();
            itmRecepcion = new beRecepcion();
            //itmRecepcion = DetalleCodigoInterno(myitmRecepcion.strCodigoInterno);
            itmRecepcion = DetalleFechaProceso(myitmRecepcion.dtmFechaProceso);
            if (itmRecepcion.strCodigoInterno == null)
            {
                try
                {

                    itmReturn = objRecepcion.Insert(myitmRecepcion);
                    foreach (var item in myitmRecepcion.lisRecepcionDetalle)
                    {
                        item.intIdRecepcion = Convert.ToInt16(itmReturn.strReturn);
                        beReturn itmReturnDetalle = new beReturn();
                        itmReturnDetalle = objRecepcionDetalle.Insert(item);
                    }
                }
                catch (Exception)
                {
                    itmReturn.intIdReturn = 0;
                    itmReturn.strReturn = "Ocurrio un problema al prosesar los datos";
                }
            }
            else
            {
                itmReturn.intIdReturn = 1;
                itmReturn.strReturn = itmRecepcion.intIdRecepcion.ToString();
            }
            return itmReturn;
        }
    }
}
