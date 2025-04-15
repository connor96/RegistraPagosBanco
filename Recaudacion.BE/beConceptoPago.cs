using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beConceptoPago
    {
        public int intIdConceptoPago { get; set; }
        public int idGrupoConcepto { get; set; }
        public string CodCurso { get; set; }
        public int idConceptoSede { get; set; }
        public string Tipo { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public int IdSede { get; set; }
        public string Stock { get; set; }
        public string idPrematricula { get; set; }
        public decimal Pagar { get; set; }
        public decimal Dscto { get; set; }
        public bool TipoMatricula { get; set; }
        public int IdSituacionMatricula { get; set; }
        public bool PMatricula { get; set; }
        public string IdMatricula { get; set; }
    }
}
