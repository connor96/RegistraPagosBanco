using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_PagoMatriculaA
    {
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public bool Estado { get; set; }
        public bool CajaProcesado { get; set; }
    }
}
