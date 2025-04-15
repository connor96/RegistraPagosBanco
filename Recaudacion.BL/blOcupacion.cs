using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blOcupacion
    {
        beOcupacion itmOcupacion;
        List<beOcupacion> lisOcupacion;
        daOcupacion objOcupacion = new daOcupacion();
        public List<beOcupacion> Lista()
        {
            lisOcupacion = new List<beOcupacion>();
            lisOcupacion = objOcupacion.Lista();
            return lisOcupacion;
        }
    }
}
