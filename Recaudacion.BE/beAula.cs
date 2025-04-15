using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beAula
    {
        public beAula()
        {
            this.lisCiclo = new HashSet<beCiclo>();
        }

        public short IdAula { get; set; }
        public byte IdLocal { get; set; }
        public string DesAula { get; set; }
        public short Capacidad { get; set; }
        public byte CapacidadAdicional { get; set; }
        public string Piso { get; set; }
        public string Obs { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        public virtual ICollection<beCiclo> lisCiclo { get; set; }
    }
}
