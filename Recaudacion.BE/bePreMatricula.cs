using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class bePreMatricula
    {
        //public bePreMatricula()
        //{
        //    itmCiclo = new beCiclo();
        //}
        public Guid IdPreMatricula { get; set; }
        public string IdAlumno { get; set; }
        public string IdCiclo { get; set; }
        public string rowguid { get; set; }
        public decimal DeudaMatricula { get; set; }
        public decimal DeudaAnterior { get; set; }
        public decimal DeudaPreinscripcion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaRegistro { get; set; }
        //public DateTimeOffset FechaRegistro { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCaducar { get; set; }
        //public DateTimeOffset FechaCaducar { get; set; }
        public bool EsCaducado { get; set; }
        public bool bitEleiminar { get; set; }
        public string EsMatriculado { get; set; }
        public virtual beCiclo itmCiclo { get; set; }
        public virtual bePersona itmPersona { get; set; }
    }
}
