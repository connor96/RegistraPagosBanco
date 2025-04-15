using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beDetalleComprobante
    {
        public string IdComprobante { get; set; }
        public int IdItem { get; set; }
        public short IdConceptoSede { get; set; }
        public short IdDescuentoSede { get; set; }
        public short IdGrupoConcepto { get; set; }
        public byte IdSede { get; set; }
        public string TipoItem { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Dscto { get; set; }
        public decimal Total { get; set; }
        public string CtaContable { get; set; }
        public bool PagoAnticipado { get; set; }
        public Guid rowguid { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }
        public string Obs { get; set; }

        public bool TipoMatricula { get; set; }
        public string IdAlumno { get; set; }
        public string IdCiclo { get; set; }
        public int IdSituacionMatricula { get; set; }
        public bool Ultimo { get; set; }
        public bool PMatricula { get; set; }
        public int PDeuda { get; set; }
        public string IdMatricula { get; set; }
        public virtual beComprobante itmComprobante { get; set; }
    }
}
