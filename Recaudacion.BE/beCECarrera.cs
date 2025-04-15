using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beCECarrera
    {
        public int IdCE { get; set; }
        public byte IdSede { get; set; }
        public short IdCarrera { get; set; }
        public string DesCarrera { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        //public virtual beCarrera Carrera { get; set; }
        public virtual beCE itmCE { get; set; }
    }
}
