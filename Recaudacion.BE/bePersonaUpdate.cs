using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class bePersonaUpdate
    {
        [Key]
        [Display(Name = "Código")]
        public string IdPersona { get; set; }
        [Display(Name = "Ocupación")]
        public int IdOcupacion { get; set; }
        [Display(Name = "Código de ubigeo")]
        public string CodUbigeo { get; set; }
        [Display(Name = "Tipo vía")]
        public int IdTipoVia { get; set; }
        [Display(Name = "Nombre de la vía")]
        public string NombreVia { get; set; }
        [Display(Name = "Denominación")]
        public string DenominacionUrbana { get; set; }
        [Display(Name = "Tipo de documento")]
        public int IdTipoDocumento { get; set; }
        [Display(Name = "Primer nombre")]
        public string Nombres1 { get; set; }
        [Display(Name = "Segundo nombre")]
        public string Nombres2 { get; set; }
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Número de DNI")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string DNI { get; set; }
        [Display(Name = "Fec. Nacimiento")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FNacimiento { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Tipo dir.")]
        public string TipoDireccion { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [Display(Name = "Local")]
        public int IdLocal { get; set; }
        [Display(Name = "Estado")]
        public int Estado { get; set; }
        [Display(Name = "Terminal")]
        public string Terminal { get; set; }
        [Display(Name = "Usuario que modifica")]
        public string User { get; set; }
        //[DisplayFormat()]
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato incorrecto de {0}")]
        [EmailAddressAttribute(ErrorMessage = "Formato incorrecto de {0}")]
        public string Email { get; set; }

        public virtual beDistrito itmDistrito { get; set; }
    }
}
