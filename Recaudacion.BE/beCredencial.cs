using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beCredencial
    {
        [Display(Name = "Código de alumno")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        //[StringLength(8, ErrorMessage = "¡Error en el formato de {0}!")]
        public string IdPersona { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        [DataType(DataType.Password)]
        //[MaxLength(6, ErrorMessage = "¡{0} Máximo 6 dígitos!")]
        //[MinLength(6, ErrorMessage = "¡{0} Minimo 6 dígitos!")]
        public string Clave { get; set; }
        [Display(Name = "Recordar Credencial")]
        public bool bitRecordar { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public string EdaDetallada { get; set; }
        public string DNI { get; set; }
        public int intEdad { get; set; }
    }
}
