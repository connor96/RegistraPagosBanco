using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beRecepcion
    {
        public beRecepcion()
        {
            this.lisRecepcionDetalle = new HashSet<beRecepcionDetalle>();
        }
        [Key]
        public int intIdRecepcion { get; set; }
        [Display(Name = "Número de cuenta")]
        public string strCuenta { get; set; }
        [Display(Name = "Fecha de proceso")]
        public DateTime dtmFechaProceso { get; set; }
        [Display(Name = "Número de registros")]
        public int intRegistros { get; set; }
        [Display(Name = "Monto total")]
        public decimal dblMontoTotal { get; set; }
        [Display(Name = "Código interno")]
        public string strCodigoInterno { get; set; }
        [Display(Name = "Código teletransfer")]
        public string strCodigoTeletransfer { get; set; }
        [Display(Name = "Código de servicio")]
        public string strCodigoServicio { get; set; }
        [Display(Name = "Usuario")]
        public string UserRegistro { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime dtmFechaRegistro { get; set; }
        public virtual ICollection<beRecepcionDetalle> lisRecepcionDetalle { get; set; }
    }
}
