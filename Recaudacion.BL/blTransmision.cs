using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTransmision
    {
        List<beTransmision> lisTransmision;
        beTransmision itmTransmision;
        beReturn itmReturn;
        daTransmision objTransmision = new daTransmision();
        blBancoDetalle objBancoDetalle = new blBancoDetalle();
        blInstitucion objInstitucion = new blInstitucion();
        blTipoArchivo objTipoArchivo = new blTipoArchivo();
        blTransmisionDetalle objTransmisionDetalle = new blTransmisionDetalle();
        blPreMatricula objPreMatricula = new blPreMatricula();
        public List<beTransmision> ListaPorFecha(DateTime dtmFecha)
        {
            lisTransmision = new List<beTransmision>();
            lisTransmision = objTransmision.ListaPorFecha(dtmFecha);
            foreach (var item in lisTransmision)
            {
                item.itmInstitucion = objInstitucion.Detalle(item.IdInstitucion);
                item.itmBancoDetalle = objBancoDetalle.Detalle(item.intIdBancoDetalle);
                item.itmTipoArchivo = objTipoArchivo.Detalle(item.intIdTipoArchivo);
            }
            return lisTransmision;
        }
        public List<beTransmision> ListaPorFechas(DateTime dtmFechaInicio, DateTime dtmFechaFinal)
        {
            lisTransmision = new List<beTransmision>();
            lisTransmision = objTransmision.ListaPorFechas(dtmFechaInicio, dtmFechaFinal);
            foreach (var item in lisTransmision)
            {
                item.itmInstitucion = objInstitucion.Detalle(item.IdInstitucion);
                item.itmBancoDetalle = objBancoDetalle.Detalle(item.intIdBancoDetalle);
                item.itmTipoArchivo = objTipoArchivo.Detalle(item.intIdTipoArchivo);
            }
            return lisTransmision;
        }
        public beTransmision Detalle(int intIdTransmision)
        {
            itmTransmision = new beTransmision();
            itmTransmision = objTransmision.Detalle(intIdTransmision);
            itmTransmision.itmInstitucion = objInstitucion.Detalle(itmTransmision.IdInstitucion);
            itmTransmision.itmBancoDetalle = objBancoDetalle.Detalle(itmTransmision.intIdBancoDetalle);
            itmTransmision.itmTipoArchivo = objTipoArchivo.Detalle(itmTransmision.intIdTipoArchivo);
            return itmTransmision;
        }
        public beReturn Insert(beTransmision myitmbeTransmision)
        {
            itmReturn = new beReturn();
            itmReturn = objTransmision.Insert(myitmbeTransmision);
            return itmReturn;
        }
        public beReturn Generar(beTransmision myitmbeTransmision, int intIdTipoRegistro)
        {
            itmReturn = new beReturn();
            itmReturn = objTransmision.Generar(myitmbeTransmision, intIdTipoRegistro);
            return itmReturn;
        }
        public beReturn InsertAutogenerago(beTransmision myitmbeTransmision)
        {
            itmReturn = new beReturn();
            itmReturn = objTransmision.InsertAutogenerago(myitmbeTransmision);
            return itmReturn;
        }
        public beReturn Update(beTransmision myitmbeTransmision)
        {
            itmReturn = new beReturn();
            itmReturn = objTransmision.Update(myitmbeTransmision);
            return itmReturn;
        }
        public beReturn Procesar(beTransmision myitmbeTransmision, int intIdTipoRegistro, string[] Prematriculas)
        {
            itmReturn = new beReturn();
            if (Prematriculas != null)
            {
                itmReturn = Insert(myitmbeTransmision);
                if (itmReturn.intIdReturn > 0)
                {
                    beReturn itmReturnx = new beReturn();
                    bePreMatricula itmPreMatricula;
                    beTransmisionDetalle itmTransmisionDetalle;
                    foreach (var pm in Prematriculas)
                    {
                        itmPreMatricula = new bePreMatricula();
                        itmPreMatricula = objPreMatricula.Detalle(Guid.Parse(pm));
                        itmTransmisionDetalle = new beTransmisionDetalle();

                        itmTransmisionDetalle.intIdTransmision = Convert.ToInt32(itmReturn.strReturnValue);
                        itmTransmisionDetalle.IdPreMatricula = itmPreMatricula.IdPreMatricula;
                        itmTransmisionDetalle.dtmFechaEmision = itmPreMatricula.FechaRegistro;
                        itmTransmisionDetalle.dtmFechaVencimiento = itmPreMatricula.FechaCaducar;
                        itmTransmisionDetalle.dblMonto = itmPreMatricula.DeudaAnterior+ itmPreMatricula.DeudaMatricula+ itmPreMatricula.DeudaPreinscripcion;
                        itmTransmisionDetalle.dblMora = 0;
                        itmTransmisionDetalle.dblMinimo = 0;
                        itmTransmisionDetalle.intTipoRegistro = intIdTipoRegistro;
                        itmReturnx = objTransmisionDetalle.Insert(itmTransmisionDetalle);
                    }
                }
            }
            else
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = "NO existe Pre-matrículas seleccionadas.";
            }
            return itmReturn;
        }
    }
}
