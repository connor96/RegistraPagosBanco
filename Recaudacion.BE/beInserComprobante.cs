using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beInserComprobante
    {
        public string IdCliente { get; set; }
        public string IdAlumnmo { get; set; }
        public int IdTipoComprobante { get; set; }
        public string DesLocal { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal Importe { get; set; }
        public decimal Dscto { get; set; }
        public decimal TotalPago { get; set; }
        public DateTime Periodo { get; set; }
        public DateTime Fecha { get; set; }
        public string Terminal { get; set; }
        public string User { get; set; }
        public bool Tipo { get; set; }
        public string Local { get; set; }
        public bool Credito { get; set; }
        public string IdComprobante { get; set; }
    }
}
