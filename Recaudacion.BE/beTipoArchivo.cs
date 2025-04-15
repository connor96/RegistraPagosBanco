using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beTipoArchivo
    {
        public beTipoArchivo()
        {
            this.lisBancoDetalle = new HashSet<beBancoDetalle>();
            this.lisTransmision = new HashSet<beTransmision>();
            this.lisTipoRegistro = new HashSet<beTipoRegistro>();
        }

        [Key]
        [Display(Name = "Código")]
        public int intIdTipoArchivo { get; set; }
        [Display(Name = "Banco")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int intIdBanco { get; set; }
        [Display(Name = "Tipode Archivo")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strTipoArchivo { get; set; }
        [Display(Name = "Caracter de reconocimiento")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strCaracter { get; set; }
        [Display(Name = "Activo")]
        public bool bitActivo { get; set; }

        public virtual ICollection<beBancoDetalle> lisBancoDetalle { get; set; }
        public virtual ICollection<beTransmision> lisTransmision { get; set; }
        public virtual ICollection<beTipoRegistro> lisTipoRegistro { get; set; }

    }
}
