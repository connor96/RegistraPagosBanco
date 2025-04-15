using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beContacto
    {
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public short IdTipoContacto { get; set; }
        [Display(Name = "Usuario")]
        public string IdPersona { get; set; }
        public string Anexo { get; set; }
        [Display(Name = "Número o Correo de apoderado")]
        [Required(ErrorMessage = "¡{0} Requerido!")]
        public string NumMail { get; set; }
        [Display(Name = "Para emergencia")]
        public bool Emergencia { get; set; }
        [Display(Name = "Nombres del apoderado")]
        public string Obs { get; set; }
        public Guid rowguid { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }

        public virtual bePersona itmPersona { get; set; }
        public virtual beTipoContacto itmTipoContacto { get; set; }
    }
}
