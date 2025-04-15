using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beTipoDocumento
    {
        //public TipoDocumento()
        //{
        //    this.Persona = new HashSet<bePersona>();
        //}

        public byte IdTipoDocumento { get; set; }
        public string DesTipoDocumento { get; set; }
        public System.Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public System.DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public Nullable<System.DateTimeOffset> FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        public virtual ICollection<bePersona> Persona { get; set; }
    }
}
