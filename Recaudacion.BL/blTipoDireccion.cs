using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blTipoDireccion
    {
        beTipoDireccion itmTipoDireccion;
        List<beTipoDireccion> lisTipoDireccion;
        daTipoDireccion objTipoDireccion = new daTipoDireccion();
        public beTipoDireccion Detalle(string IdTipoDireccion)
        {
            itmTipoDireccion = new beTipoDireccion();
            itmTipoDireccion = objTipoDireccion.Detalle(IdTipoDireccion);
            return itmTipoDireccion;
        }
        public List<beTipoDireccion> Lista()
        {
            lisTipoDireccion = new List<beTipoDireccion>();
            lisTipoDireccion = objTipoDireccion.Lista();
            return lisTipoDireccion;
        }
    }
}
