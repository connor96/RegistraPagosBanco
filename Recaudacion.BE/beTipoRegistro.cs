using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beTipoRegistro
    {
        public beTipoRegistro()
        {
            this.lisTransmisionDetalle = new HashSet<beTransmisionDetalle>();
        }

        [Key]
        [Display(Name = "Código")]
        public int intIdTipoRegistro { get; set; }
        [Display(Name = "Tipode archivo")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int intIdTipoArchivo { get; set; }
        [Display(Name = "Tipo de registro")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strTipoRegistro { get; set; }
        [Display(Name = "Caracter de reconocimiento")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strCaracter { get; set; }

        public virtual beTipoArchivo itmTipoArchivo { get; set; }
        public virtual ICollection<beTransmisionDetalle> lisTransmisionDetalle { get; set; }
    }
}
