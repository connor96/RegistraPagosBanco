using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beLocal
    {
        public byte IdLocal { get; set; }
        public byte IdSede { get; set; }
        public byte IdInstitucion { get; set; }
        public byte CodLocal { get; set; }
        public string CodUbigeo { get; set; }
        public string Local { get; set; }
        public string Direccion { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }
        public byte _IdLocal { get; set; }

        //public virtual Institucion Institucion { get; set; }
        public virtual beSede beSede { get; set; }
        //public virtual beSede
    }
}
