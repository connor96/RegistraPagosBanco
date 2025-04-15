using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beActivarDatos
    {
        [Key]
        public int intIdActivarDatos { get; set; }
        [Display(Name = "Fecha y hora de inicio")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato incorrecto de {0}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public DateTime dtmInicio { get; set; }
        [Display(Name = "Fecha y hora final")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato incorrecto de {0}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public DateTime dtmFinal { get; set; }
    }
}
