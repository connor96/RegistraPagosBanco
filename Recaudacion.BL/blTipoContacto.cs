using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTipoContacto
    {
        List<beTipoContacto> lisTipoContacto;
        beTipoContacto itmTipoContacto;
        daTipoContacto objTipoContacto = new daTipoContacto();
        public List<beTipoContacto> Lista()
        {
            lisTipoContacto = new List<beTipoContacto>();
            lisTipoContacto = objTipoContacto.Lista();
            return lisTipoContacto;
        }
    }
}
