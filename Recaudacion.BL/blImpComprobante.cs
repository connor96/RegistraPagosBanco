using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;
using System.Data;

namespace Recaudacion.BL
{
    public class blImpComprobante
    {
        beImpComprobante itmImpComprobante;
        List<beImpComprobante> lisImpComprobante;

        daImpComprobante objImpComprobante = new daImpComprobante();
        blImpComprobanteDetalle objImpComprobanteDetalle = new blImpComprobanteDetalle();
        public List<beImpComprobante> ListaPorRecepcion(int intIdRecepcion)
        {
            lisImpComprobante = new List<beImpComprobante>();
            lisImpComprobante = objImpComprobante.ListaPorRecepcion(intIdRecepcion);
            if (lisImpComprobante.Count() > 0)
            {
                foreach (var item in lisImpComprobante)
                {
                    item.lisImpComprobanteDetalle = objImpComprobanteDetalle.ListaPorComprobante(item.IdComprobante);
                }
            }
            return lisImpComprobante;
        }
        public List<beImpComprobante> ListaPorFechas(DateTime dtmFechaInicio, DateTime dtmFechaFinal)
        {
            lisImpComprobante = new List<beImpComprobante>();
            lisImpComprobante = objImpComprobante.ListaPorFechas(dtmFechaInicio, dtmFechaFinal);
            return lisImpComprobante;
        }

        public beImpComprobante Detalle(string IdComprobante)
        {
            itmImpComprobante = new beImpComprobante();
            itmImpComprobante = objImpComprobante.Detalle(IdComprobante);
            itmImpComprobante.lisImpComprobanteDetalle = objImpComprobanteDetalle.ListaPorComprobante(itmImpComprobante.IdComprobante);
            return itmImpComprobante;
        }
        public DataSet DataSetPorRecepcion(int intIdRecepcion)
        {
            return objImpComprobante.DataSetPorRecepcion(intIdRecepcion);
        }
        public DataSet DataSetDetalle(string IdComprobante)
        {
            return objImpComprobante.DataSetDetalle(IdComprobante);
        }
        public DataTable DataTablePorRecepcion(int intIdRecepcion)
        {
            return objImpComprobante.DataTablePorRecepcion(intIdRecepcion);
        }
        public DataTable DataTableDetalle(string IdComprobante)
        {
            return objImpComprobante.DataTableDetalle(IdComprobante);
        }

    }
}
