using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTipoArchivo
    {
        List<beTipoArchivo> lisTipoArchivo;
        beTipoArchivo itmTipoArchivo;
        beReturn itmReturn;
        daTipoArchivo objTipoArchivo = new daTipoArchivo();
        public List<beTipoArchivo> ListaPorBanco(int intIdBanco)
        {
            lisTipoArchivo = new List<beTipoArchivo>();
            lisTipoArchivo = objTipoArchivo.ListaPorBanco(intIdBanco);
            return lisTipoArchivo;
        }
        public beTipoArchivo Detalle(int intIdBancoDetalle)
        {
            itmTipoArchivo = new beTipoArchivo();
            itmTipoArchivo = objTipoArchivo.Detalle(intIdBancoDetalle);
            return itmTipoArchivo;
        }
        public beReturn Insert(beTipoArchivo myitmTipoArchivo)
        {
            itmReturn = new beReturn();
            itmReturn = objTipoArchivo.Insert(myitmTipoArchivo);
            return itmReturn;
        }
        public beReturn Update(beTipoArchivo myitmTipoArchivo)
        {
            itmReturn = new beReturn();
            itmReturn = objTipoArchivo.Update(myitmTipoArchivo);
            return itmReturn;
        }
    }
}
