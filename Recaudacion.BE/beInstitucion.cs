using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beInstitucion
    {
        public beInstitucion()
        {
            this.lisLocal = new HashSet<beLocal>();
        }

        public byte IdInstitucion { get; set; }
        public string CodUbigeo { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocialRes { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public byte[] LogoPequeno { get; set; }
        public byte[] Logo { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        public virtual ICollection<beLocal> lisLocal { get; set; }
    }
}
