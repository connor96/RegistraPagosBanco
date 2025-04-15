using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class Banco
    {
        public string codalumno { get; set; }
        public string fullname { get; set; }
        public string dni { get; set; }
        public string codcurso_actual { get; set; }
        public string nota_final { get; set; }
        public string codcurso_siguiente { get; set; }
        public string costo_matricula { get; set; }
        public string costo_pension { get; set; }
        public string costo_deuda { get; set; }
        public string costo_mora { get; set; }
        public int total_pagar { get; set; }
        public string exa_ubicacion { get; set; }
        public string periodostring { get; set; }
        public string periodo { get; set; }
        public string estado { get; set; }
        public string estado_ninios { get; set; }
        public DateTime fechainscripcion { get; set; }
    }
}
