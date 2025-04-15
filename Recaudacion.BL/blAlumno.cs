using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blAlumno
    {
        daAlumno objAlumno = new daAlumno();
        public beAlumno Detalle(string idPersona)
        {
            beAlumno itmAlumno = new beAlumno();
            itmAlumno = objAlumno.Detalle(idPersona);
            return itmAlumno;
        }
        public int Sede(string idPersona)
        {            
            return objAlumno.Sede(idPersona);
        }
    }
}
