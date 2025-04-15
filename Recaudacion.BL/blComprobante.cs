using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blComprobante
    {
        beComprobante itmComprobante;
        beReturn itmReturn;
        beRecepcion itmRecepcion;
        beInserComprobante itmInserComprobante;
        
        daComprobante objComprobante = new daComprobante();
        daRecepcion objRecepcion = new daRecepcion();
        daRecepcionDetalle objRecepcionDetalle = new daRecepcionDetalle();
        public beReturn Insert(beComprobante myitmComprobante)
        {
            itmReturn = new beReturn();
            itmReturn = objComprobante.Insert(myitmComprobante);
            return itmReturn;
        }

        public void RegistrarComprobate(int intIdRecepcion)
        {
            itmRecepcion = new beRecepcion();
            itmRecepcion = objRecepcion.Detalle(intIdRecepcion);
            itmRecepcion.lisRecepcionDetalle = objRecepcionDetalle.ListaPorRegistro(itmRecepcion.intIdRecepcion);
            itmReturn = new beReturn();
            foreach (var item in itmRecepcion.lisRecepcionDetalle)
            {
                itmInserComprobante = new beInserComprobante();
                itmInserComprobante.IdCliente = "20000002";
                itmInserComprobante.IdAlumnmo = "20000002";
                itmInserComprobante.IdTipoComprobante = 3;
                itmInserComprobante.DesLocal = "HUANCAVELICA";
                itmInserComprobante.Serie = "016";
                itmInserComprobante.Numero = "000000501";
                itmInserComprobante.Importe = 200.00m;
                itmInserComprobante.Dscto = 0;
                itmInserComprobante.TotalPago = 200.00m;
                itmInserComprobante.Periodo = Convert.ToDateTime("2016-11-01 00:00:00");
                itmInserComprobante.Fecha = Convert.ToDateTime("2016-11-03 21:01:46.730");
                itmInserComprobante.Terminal = "PC-INF/Informatica";
                itmInserComprobante.User = "1112240135";
                itmInserComprobante.Local = "5";
                itmInserComprobante.Credito = false;
                itmInserComprobante.IdComprobante = "";
            }
        }

        public int BuscarNroRecibo(int IdTipoComprobante, string Serie, string Numero)
        {
            return objComprobante.BuscarNroRecibo(IdTipoComprobante, Serie, Numero);
        }
    }
}
