using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class beCE
    {
        public beCE()
        {
            this.lisCECarrera = new HashSet<beCECarrera>();
        }

        public int IdCE { get; set; }
        public byte IdSede { get; set; }
        public short IdOcupacion { get; set; }
        public string NivelCE { get; set; }
        public string CodUbigeo { get; set; }
        public string NombreCE { get; set; }
        public string Resumen { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        public virtual ICollection<beCECarrera> lisCECarrera { get; set; }
    }
}
