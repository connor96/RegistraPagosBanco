using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beRecuperarClave
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string idpersona { get; set; }
    }
}
