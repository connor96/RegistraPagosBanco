using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beCurso
    {
        public beCurso()
        {
            //this.Pregunta = new HashSet<Pregunta>();
            //this.NotaMinino = new HashSet<NotaMinino>();
            //this.Ciclo = new HashSet<Ciclo>();
            //this.Combo = new HashSet<Combo>();
            //this.CursosAlternativos = new HashSet<CursosAlternativos>();
        }

        public string CodCurso { get; set; }
        public short IdCurso { get; set; }
        public string CodNivelCurso { get; set; }
        public string CodMYELT { get; set; }
        public string DesCurso { get; set; }
        public short Orden { get; set; }
        public string PreRequisito { get; set; }
        public string EdadMi { get; set; }
        public string EdadMa { get; set; }
        public byte Disponible { get; set; }
        public System.Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        //public virtual ICollection<Pregunta> Pregunta { get; set; }
        //public virtual ICollection<NotaMinino> NotaMinino { get; set; }
        //public virtual ICollection<Ciclo> Ciclo { get; set; }
        //public virtual ICollection<Combo> Combo { get; set; }
        //public virtual NivelCurso NivelCurso { get; set; }
        //public virtual ICollection<CursosAlternativos> CursosAlternativos { get; set; }
    }
}
