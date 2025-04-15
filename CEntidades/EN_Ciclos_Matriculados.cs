using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Ciclos_Matriculados
    {
        public string IdTransaccion { get; set; }
        public string IdPersona { get; set; }
        public string Periodo { get; set; }
        public List<EN_Curso> IdCiclo { get; set; }
    }
}
