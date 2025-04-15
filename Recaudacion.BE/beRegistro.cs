using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class beRegistro
    {
        [Key]
        [Display(Name = "Código")]
        public string IdPersona { get; set; }
        [Display(Name = "Tipo de documento de identidad")]
        public byte IdTipoDocumento { get; set; }
        [Display(Name = "Primer nombre")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string Nombres1 { get; set; }
        [Display(Name = "Segundo nombre")]
        public string Nombres2 { get; set; }
        [Display(Name = "Apellido paterno")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido materno")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Nro. DNI")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        [StringLength(8, ErrorMessage = "¡Error en el formato de {0}!")]
        [RegularExpression("^[0-9]{8}$",ErrorMessage = "¡No es un {0}!")]
        public string DNI { get; set; }
        [Display(Name = "Fec. Nacimiento")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Formato incorrecto de {0}")]
        public DateTime FNacimiento { get; set; }
        [Required(ErrorMessage = "¡{0} Requerido!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato incorrecto de {0}")]
        //[EmailAddress]
        [EmailAddressAttribute(ErrorMessage = "Formato incorrecto de {0}")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        //[Display(Name = "Contraseña")]
        //[Required(ErrorMessage = "¡{0} Requerido!")]
        [DataType(DataType.Password)]
        [MaxLength(6, ErrorMessage = "¡{0} Máximo 6 dígitos!")]
        public string Clave { get; set; }
        //[Display(Name = "Repita Contraseña")]
        //[Required(ErrorMessage = "¡{0} Requerido!")]
        [DataType(DataType.Password)]
        [MaxLength(6, ErrorMessage = "¡{0} Máximo 6 dígitos!")]
        [Compare("Clave", ErrorMessage = "Contraseña no coincide")]
        public string ClaveRepite { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "¡Para continuar debe conocer y aceptar las políticas de privacidad de datos!")]
        //[Display(Name = "Accept terms and conditions")]
        public bool AceptarTerminos { get; set; }

        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
    }
}
