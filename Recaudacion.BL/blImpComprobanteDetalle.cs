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
    public class blImpComprobanteDetalle
    {
        beImpComprobanteDetalle itmImpComprobanteDetalle;
        List<beImpComprobanteDetalle> lisImpComprobanteDetalle;

        daImpComprobanteDetalle objImpComprobanteDetalle = new daImpComprobanteDetalle();
        public List<beImpComprobanteDetalle> ListaPorComprobante(string IdComprobante)
        {
            lisImpComprobanteDetalle = new List<beImpComprobanteDetalle>();
            lisImpComprobanteDetalle = objImpComprobanteDetalle.ListaPorComprobante(IdComprobante);
            return lisImpComprobanteDetalle;
        }
        public DataTable DataTableListaPorComprobante(string IdComprobante)
        {
            return objImpComprobanteDetalle.DataTableListaPorComprobante(IdComprobante);
        }
        public DataTable DataTableListaPorRecepcion(int intIdRecepcion)
        {
            return objImpComprobanteDetalle.DataTableListaPorRecepcion(intIdRecepcion);
        }
        //public DataSet DataSetListaPorComprobante(string IdComprobante)
        //{
        //    return objImpComprobanteDetalle.DataSetListaPorComprobante(IdComprobante);
        //}
        //public DataSet DataSetListaPorRecepcion(int intIdRecepcion)
        //{
        //    return objImpComprobanteDetalle.DataSetListaPorRecepcion(intIdRecepcion);
        //}
    }
}
