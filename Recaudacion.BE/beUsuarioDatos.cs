using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beUsuarioDatos
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string IdUser { get; set; }
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string DNI { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string Nickname { get; set; }
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
        [Display(Name = "Caja")]
        public string DesCaja { get; set; }
        //public string Clave { get; set; }
        [Display(Name = "Activo")]
        public bool bitActivo { get; set; }
    }
}
