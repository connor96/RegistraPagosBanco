using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blInstitucion
    {
        beInstitucion itmInstitucion;
        List<beInstitucion> lisInstitucion;
        daInstitucion objInstitucion = new daInstitucion();
        public beInstitucion Detalle(int IdInstitucion)
        {
            itmInstitucion = new beInstitucion();
            itmInstitucion = objInstitucion.Detalle(IdInstitucion);
            return itmInstitucion;
        }
        public List<beInstitucion> Lista()
        {
            lisInstitucion = new List<beInstitucion>();
            lisInstitucion = objInstitucion.Lista();
            return lisInstitucion;
        }

    }
}
