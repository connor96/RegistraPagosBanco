using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beBancoDetalle
    {
        [Key]
        [Display(Name = "Código")]
        public int intIdBancoDetalle { get; set; }
        [Display(Name = "Banco")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int intIdBanco { get; set; }
        [Display(Name = "Número de cuenta")]
        [RegularExpression("^([0-9]{3})[-.]?([0-9]{7})[-.]?([0-9]{1})[-.]?([0-9]{2})$", ErrorMessage = "¡Formato incorrecto (123-1234567-1-12)!")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string strCuenta { get; set; }
        //public string strNombreEmpresa { get; set; }
        //public int intIdTipoArchivo { get; set; }
        //public string strCodigoServicio { get; set; }
        [Display(Name = "Activo")]
        public bool bitActivo { get; set; }

        public virtual beBanco itmBanco { get; set; }
        public virtual beTipoArchivo itmTipoArchivo { get; set; }
    }
}
