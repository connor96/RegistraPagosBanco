using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beCiclo
    {
        public beCiclo()
        {
        //    this.Matricula = new HashSet<Matricula>();
            this.lisPreMatricula = new HashSet<bePreMatricula>();
        }

        public string IdPeriodo { get; set; }
        public string IdCiclo { get; set; }
        public byte IdLocal { get; set; }
        public string Local { get; set; }
        public string IdProgramacion { get; set; }
        public byte IdSede { get; set; }
        public string CodCurso { get; set; }
        public short IdAula { get; set; }
        public string DesAula { get; set; }
        public string IdDocente { get; set; }
        public short IdTurnoSede { get; set; }
        public string Obs { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }
        public string DesCurso { get; set; }
        public string DesMallaCurricular { get; set; }
        public string PreRequisito { get; set; }
        public string DesTurno { get; set; }
        public byte IdHoras { get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }
        //public Nullable<System.DateTimeOffset> Inicio { get; set; }
        //public Nullable<System.DateTimeOffset> Final { get; set; }
        public int Capacidad { get; set; }
        public int Matriculado { get; set; }
        public int Vacante { get; set; }
        public int Prematriculado { get; set; }

        //public virtual Aula Aula { get; set; }
        //public virtual ICollection<Matricula> Matricula { get; set; }
        public virtual ICollection<bePreMatricula> lisPreMatricula { get; set; }
        //public virtual Docente Docente { get; set; }
        public virtual beCurso itmCurso { get; set; }
        public virtual beProgramacion itmProgramacion { get; set; }
        //public virtual TurnoSede TurnoSede { get; set; }
    }
}
