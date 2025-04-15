using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beCicloUltimo
    {
        public string IdMatricula { get; set; }
        public string IdComprobante { get; set; }
        public string IdAlumno { get; set; }
        public DateTime FechaMatricula { get; set; }
        public string IdCiclo { get; set; }
        public byte IdSede { get; set; }
        public short IdAula { get; set; }
        public string CodCurso { get; set; }
        public string PreRequisito { get; set; }
        public byte Mes { get; set; }
        public string Yea { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public Int16 NotaFinal { get; set; }
        //public string NotaFinal { get; set; }
        public DateTime FechaActual { get; set; }
        public int Meses { get; set; }

        public virtual beAula itmAula { get; set; }
        public virtual beCurso itmCurso { get; set; }
    }
}
