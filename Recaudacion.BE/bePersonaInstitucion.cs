using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class bePersonaInstitucion
    {
        [Display(Name = "Código de alumno")]
        public string IdPersona { get; set; }
        [Display(Name = "Ocupación")]
        public int IdOcupacion { get; set; }
        [Display(Name = "Sede")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int IdSede { get; set; }
        [Display(Name = "Centro educativo")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public int IdCE { get; set; }
        [Display(Name = "Carrera")]
        public int IdCarrera { get; set; }
        [Display(Name = "Nro. carné")]
        public string NCarnet { get; set; }
        [Display(Name = "Fecha de vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> FVencimiento { get; set; }
        public Guid rowguid { get; set; }
        [Display(Name = "Activo")]
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }
    }
}
