using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beTransmision
    {
        public beTransmision()
        {
            this.lisTransmisionDetalle = new HashSet<beTransmisionDetalle>();
        }
        [Key]
        public int intIdTransmision { get; set; }
        [Display(Name = "Cuenta del afiliado")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int intIdBancoDetalle { get; set; }
        [Display(Name = "Nombre de la empresa")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int IdInstitucion { get; set; }
        [Display(Name = "Total de registros")]
        public int intTotalRegistros { get; set; }
        [Display(Name = "Monto total")]
        public decimal dblMontoTotal { get; set; }
        [Display(Name = "Tipo de archivo")]
        public int intIdTipoArchivo { get; set; }
        [Display(Name = "Código de servicio")]
        //[Required(ErrorMessage = "¡{0} Requerido!")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "¡No es un {0}!")]
        public string strCodigoServicio { get; set; }
        [Display(Name = "Usuario")]
        public string UserRegistro { get; set; }
        [Display(Name = "Fecha")]
        public DateTime dtmFechaRegistro { get; set; }

        public virtual beTipoArchivo itmTipoArchivo { get; set; }
        public virtual ICollection<beTransmisionDetalle> lisTransmisionDetalle { get; set; }
        public virtual beInstitucion itmInstitucion { get; set; }
        public virtual beBancoDetalle itmBancoDetalle { get; set; }
    }
}
