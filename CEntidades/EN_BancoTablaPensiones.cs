using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_BancoTablaPensiones
    {
        public string? idConcepto { get; set; }
        public string? idDescuento { get; set; }
        public string? idMatricula { get; set; }
        public string? descripcion { get; set; }
        public decimal monto { get; set; }
    }
}
