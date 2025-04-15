using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beDeuda
    {
        public int intIdDeudas { get; set; }
        public string idPrematricula { get; set; }
        public decimal Deuda { get; set; }
        public string Periodo { get; set; }
        public string CodAlumno { get; set; }
        public string Alumno { get; set; }
        public string idCurso { get; set; }
        public string Hora { get; set; }
        public string idAula { get; set; }
        public string CodIncripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
