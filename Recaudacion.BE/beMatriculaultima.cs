using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beMatriculaUltima
    {
        public string IdCliente { get; set; }
        public string IdComprobante { get; set; }
        public int IdConceptoSede { get; set; }
        public int IdConcepto { get; set; }
        public string DesConcepto { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }
        public int MesesPasados { get; set; }
        public int AnioPago { get; set; }
        public int AnioActual { get; set; }
    }
}
