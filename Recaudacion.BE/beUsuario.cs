using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beUsuario
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string IdUser { get; set; }
        [Display(Name = "Clave")]
        public string strClave { get; set; }
        [Display(Name = "Activo")]
        public bool bitActivo { get; set; }
    }
}
