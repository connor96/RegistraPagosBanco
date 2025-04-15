using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beGradeCard
    {
        public string IdMatricula { get; set; }
        public string IdComprobante { get; set; }
        public string IdAlumno { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaMatricula { get; set; }
        public string IdCiclo { get; set; }
        public int IdSede { get; set; }
        public short IdAula { get; set; }
        public string DesAula { get; set; }
        public string DesTurno { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public string CodCurso { get; set; }
        public string DesCurso { get; set; }
        public string DesNivelCurso { get; set; }
        public string PreRequisito { get; set; }
        public string strMes { get; set; }
        public byte Mes { get; set; }
        public string Yea { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public Int16 NotaFinal { get; set; }
        public string PrerequisitoSiguienteCurso { get; set; }
        public DateTime FechaActual { get; set; }
        public int Meses { get; set; }
        public int intEdad { get; set; }

    }
}
