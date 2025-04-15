using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Recaudacion.BE
{
    public class beSendMail
    {
        [Key]
        [Display(Name = "Código")]
        public int idSendMail { get; set; }
        [Display(Name = "Hosting")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strHost { get; set; }
        [Display(Name = "Puerto")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int intPuerto { get; set; }
        [Display(Name = "Cuenta")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strCuenta { get; set; }
        [Display(Name = "Clave")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strClave { get; set; }
        [Display(Name = "Titular")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strTitular { get; set; }
        [AllowHtml]
        [Display(Name = "Cabecera de página")]
        public string strHeader { get; set; }
        [AllowHtml]
        [Display(Name = "Pie de página")]
        public string strFooter { get; set; }
        [Display(Name = "Estado activo")]
        public bool bitActivo { get; set; }
    }
}
