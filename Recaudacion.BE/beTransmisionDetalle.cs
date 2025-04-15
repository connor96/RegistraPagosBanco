using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class beTransmisionDetalle
    {
        [Key]
        public int intIdTransmisionDetalle { get; set; }
        public int intIdTransmision { get; set; }
        public Guid IdPreMatricula { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtmFechaEmision { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtmFechaVencimiento { get; set; }
        public decimal dblMonto { get; set; }
        public decimal dblMora { get; set; }
        public decimal dblMinimo { get; set; }
        public int intTipoRegistro { get; set; }

        public virtual beTipoRegistro itmTipoRegistro { get; set; }
        public virtual beTransmision itmTransmision { get; set; }
        public virtual bePreMatricula itmPreMatricula { get; set; }
    }
}
