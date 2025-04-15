using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class beBanco
    {
        public beBanco()
        {
            this.lisBancoDetalle = new HashSet<beBancoDetalle>();
            this.lisTipoRegistro = new HashSet<beTipoRegistro>();
        }

        [Key]
        [Display(Name = "Código")]
        public int intIdBanco { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strNombre { get; set; }
        [Display(Name = "Nombre corto")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strNombreCorto { get; set; }
        [Display(Name = "Activo")]
        public bool bitActivo { get; set; }

        public virtual ICollection<beBancoDetalle> lisBancoDetalle { get; set; }
        public virtual ICollection<beTipoRegistro> lisTipoRegistro { get; set; }
    }
}
