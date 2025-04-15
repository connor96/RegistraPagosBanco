using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blMatriculaUltima
    {
        beMatriculaUltima itmMatriculaUltima;
        daMatriculaUltima objMatriculaUltima = new daMatriculaUltima();
        public beMatriculaUltima PagoMaricula(string idPersona)
        {
            itmMatriculaUltima = new beMatriculaUltima();
            itmMatriculaUltima = objMatriculaUltima.PagoMaricula(idPersona);
            return itmMatriculaUltima;
        }
    }
}
