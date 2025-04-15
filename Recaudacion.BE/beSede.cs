using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class beSede
    {
        public beSede()
        {
            this.beLocal = new HashSet<beLocal>();
        }

        public byte IdSede { get; set; }
        public byte IdInstitucion { get; set; }
        public string CodUbigeo { get; set; }
        public string Sede { get; set; }
        public System.Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public System.DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public Nullable<System.DateTimeOffset> FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }
        public Nullable<byte> C_IdSede { get; set; }

        public virtual ICollection<beLocal> beLocal { get; set; }
    }
}
