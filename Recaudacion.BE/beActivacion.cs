using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beActivacion
    {
        [Key]
        public int intIdActivacion { get; set; }
        [Display(Name = "Fecha y hora de inicio")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato incorrecto de {0}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        //[RegularExpression(@"(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))) (((0[1-9])|(1[0-9])|(2[0-4]))|([1-9])):(((0[0-9])|([1-5][0-9]))|([1-9])))$)", ErrorMessage = "Se debe de indicar un {0} válido")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public DateTime dtmInicio { get; set; }
        [Display(Name = "Fecha y hora final")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato incorrecto de {0}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public DateTime dtmFinal { get; set; }
    }
}
