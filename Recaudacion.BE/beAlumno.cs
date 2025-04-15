using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beAlumno
    {
        //public Alumno()
        //{
        //    this.Matricula = new HashSet<Matricula>();
        //}

        public string IdAlumno { get; set; }
        public byte IdLocal { get; set; }
        public string Clave { get; set; }
        public System.Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public byte NroVeces { get; set; }
        public string Obs { get; set; }
        public System.DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        //public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
