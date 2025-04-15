using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTipoVia
    {
        beTipoVia itmTipoVia;
        List<beTipoVia> lisTipoVia;
        daTipoVia objTipoVia = new daTipoVia();
        public beTipoVia Detalle(string IdTipoVia)
        {
            itmTipoVia = new beTipoVia();
            itmTipoVia = objTipoVia.Detalle(IdTipoVia);
            return itmTipoVia;
        }
        public List<beTipoVia> Lista()
        {
            lisTipoVia = new List<beTipoVia>();
            lisTipoVia = objTipoVia.Lista();
            return lisTipoVia;
        }
    }
}
