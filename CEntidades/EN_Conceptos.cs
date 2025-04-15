using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Conceptos
    {
        public int IdConcepto { get; set; }
        public int IdProducto { get; set; }
        public string DesConcepto { get; set; }
        public string Monto { get; set; }
        public bool Activo { get; set; }
        public string IdCicloString { get; set; }
        public string IdCiclo { get; set; }
        public string cursoActual { get; set; }
    }
}
