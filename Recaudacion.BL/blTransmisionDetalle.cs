using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTransmisionDetalle
    {
        List<beTransmisionDetalle> lisTransmisionDetalle;
        beTransmisionDetalle itmTransmisionDetalle;
        beReturn itmReturn;
        daTransmisionDetalle objTransmisionDetalle = new daTransmisionDetalle();
        blPreMatricula objPrematricula = new blPreMatricula();
        //blTransmision objTransmision = new blTransmision();
        blTipoRegistro objTipoRegistro = new blTipoRegistro();
        public List<beTransmisionDetalle> ListaPorTransmision(int intIdTransmision)
        {
            lisTransmisionDetalle = new List<beTransmisionDetalle>();
            lisTransmisionDetalle = objTransmisionDetalle.ListaPorTransmision(intIdTransmision);
            foreach (var item in lisTransmisionDetalle)
            {
                item.itmPreMatricula = objPrematricula.Detalle(item.IdPreMatricula);
                //item.itmTransmision = objTransmision.Detalle(item.intIdTransmision);
                item.itmTipoRegistro = objTipoRegistro.Detalle(item.intTipoRegistro);
            }
            return lisTransmisionDetalle;
        }
        public beTransmisionDetalle Detalle(int intIdTransmisionDetalle)
        {
            itmTransmisionDetalle = new beTransmisionDetalle();
            itmTransmisionDetalle = objTransmisionDetalle.Detalle(intIdTransmisionDetalle);
            itmTransmisionDetalle.itmPreMatricula = objPrematricula.Detalle(itmTransmisionDetalle.IdPreMatricula);
            //itmTransmisionDetalle.itmTransmision = objTransmision.Detalle(itmTransmisionDetalle.intIdTransmision);
            itmTransmisionDetalle.itmTipoRegistro = objTipoRegistro.Detalle(itmTransmisionDetalle.intTipoRegistro);
            return itmTransmisionDetalle;
        }
        public beReturn Insert(beTransmisionDetalle myitmTransmisionDetalle)
        {
            itmReturn = new beReturn();
            itmReturn = objTransmisionDetalle.Insert(myitmTransmisionDetalle);
            return itmReturn;
        }
        public beReturn InsertUpdate(beTransmisionDetalle myitmTransmisionDetalle)
        {
            itmReturn = new beReturn();
            itmReturn = objTransmisionDetalle.InsertUpdate(myitmTransmisionDetalle);
            return itmReturn;
        }
    }
}
