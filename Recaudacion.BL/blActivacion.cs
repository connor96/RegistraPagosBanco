using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blActivacion
    {
        beActivacion itmAlumno;
        List<beActivacion> lisAlumno;
        daActivacion objActivacion = new daActivacion();
        beReturn itmReturn;
        public beActivacion Detalle(int id)
        {
            itmAlumno = new beActivacion();
            itmAlumno = objActivacion.Detalle(id);
            return itmAlumno;
        }
        public List<beActivacion> Activos()
        {
            lisAlumno = new List<beActivacion>();
            lisAlumno = objActivacion.Activos();
            return lisAlumno;
        }
        public int ActivosInt()
        {
            return objActivacion.ActivosInt();
        }
        public beReturn Insert(beActivacion myitmActivacion)
        {
            itmReturn = new beReturn();
            itmReturn = objActivacion.Insert(myitmActivacion);
            return itmReturn;
        }
        public beReturn Delete(int intIdActivacion)
        {
            itmReturn = new beReturn();
            itmReturn = objActivacion.Delete(intIdActivacion);
            return itmReturn;
        }
    }
}
