using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beImpComprobanteDetalle
    {
        public string IdComprobante { get; set; }
        public int Cantidad { get; set; }
        public string DesConcepto { get; set; }
        public string DesGrupoConcepto { get; set; }
        public string DesNivelCurso { get; set; }
        public decimal Importe { get; set; }
        public string TipoItem { get; set; }

        public virtual beImpComprobante itmImpComprobante { get; set; }
    }
}
