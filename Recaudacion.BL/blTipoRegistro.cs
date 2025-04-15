using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTipoRegistro
    {
        List<beTipoRegistro> lisTipoRegistro;
        beTipoRegistro itmTipoRegistro;
        beReturn itmReturn;
        daTipoRegistro objTipoRegistro = new daTipoRegistro();
        blTipoArchivo objTipoArchivo = new blTipoArchivo();
        public List<beTipoRegistro> ListaPorTipoArchivo(int intIdTipoArchivo)
        {
            lisTipoRegistro = new List<beTipoRegistro>();
            lisTipoRegistro = objTipoRegistro.ListaPorTipoArchivo(intIdTipoArchivo);
            foreach (var item in lisTipoRegistro)
            {
                item.itmTipoArchivo = objTipoArchivo.Detalle(item.intIdTipoArchivo);
            }
            return lisTipoRegistro;
        }
        public beTipoRegistro Detalle(int intIdTipoRegistro)
        {
            itmTipoRegistro = new beTipoRegistro();
            itmTipoRegistro = objTipoRegistro.Detalle(intIdTipoRegistro);
            itmTipoRegistro.itmTipoArchivo = objTipoArchivo.Detalle(itmTipoRegistro.intIdTipoArchivo);
            return itmTipoRegistro;
        }
        public beReturn Insert(beTipoRegistro myitmTipoRegistro)
        {
            itmReturn = new beReturn();
            itmReturn = objTipoRegistro.Insert(myitmTipoRegistro);
            return itmReturn;
        }
        public beReturn Update(beTipoRegistro myitmTipoRegistro)
        {
            itmReturn = new beReturn();
            itmReturn = objTipoRegistro.Update(myitmTipoRegistro);
            return itmReturn;
        }
    }
}
