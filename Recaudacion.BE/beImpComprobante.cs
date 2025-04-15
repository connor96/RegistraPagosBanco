using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recaudacion.BE
{
    public class beImpComprobante
    {
        public beImpComprobante()
        {
            this.lisImpComprobanteDetalle = new HashSet<beImpComprobanteDetalle>();
        }
        [Key]
        public string IdComprobante { get; set; }
        [Display(Name = "Serie")]
        public string Serie { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Periodo")]
        public string Periodo { get; set; }
        [Display(Name = "Nombre")]
        public string Nombres1 { get; set; }
        [Display(Name = "Nombre")]
        public string Nombres2 { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Sede")]
        public string Sede { get; set; }
        [Display(Name = "Local")]
        public string Local { get; set; }
        [Display(Name = "Aula")]
        public string DesAula { get; set; }
        [Display(Name = "Curso")]
        public string CodCurso { get; set; }
        [Display(Name = "Hora de inicio")]
        public string Inicio { get; set; }
        [Display(Name = "Hora final")]
        public string Final { get; set; }
        [Display(Name = "Descuento")]
        public decimal Dscto { get; set; }
        [Display(Name = "Total")]
        public decimal TotalPago { get; set; }
        [Display(Name = "Caja")]
        public string DesCaja { get; set; }
        [Display(Name = "Cajero")]
        public string Nickname { get; set; }
        [Display(Name = "Condición")]
        public string condicion { get; set; }
        public virtual ICollection<beImpComprobanteDetalle> lisImpComprobanteDetalle { get; set; }
    }
}
