using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beInserComprobanteDetalle
    {
        public bool TipoMatricula { get; set; }
        public int IdItem { get; set; }
        public string TipoItem { get; set; }
        public int IdGrupoConcepto { get; set; }
        public int IdDescuentoSede { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Dscto { get; set; }
        public decimal TotalPagar { get; set; }
        public string IdAlumno { get; set; }
        public string IdCiclo { get; set; }
        public int IdSituacionMatricula { get; set; }
        public string Terminal { get; set; }
        public string User { get; set; }
        public string IdComprobante { get; set; }
        public bool Ultimo { get; set; }
        public bool PMatricula { get; set; }
        public int PDeuda { get; set; }
        public string IdMatricula { get; set; }

    }
}
