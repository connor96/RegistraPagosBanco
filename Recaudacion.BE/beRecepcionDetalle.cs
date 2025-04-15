using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beRecepcionDetalle
    {
        public int intIdRecepcionDetalle { get; set; }
        public int intIdRecepcion { get; set; }
        public string strCodigoDeposotante { get; set; }
        public string strDatoAdicional { get; set; }
        public DateTime dtmFechaPago { get; set; }
        public DateTime dtmFechaVencimiento { get; set; }
        public decimal dblMonto { get; set; }
        public decimal dblMora { get; set; }
        public decimal dblMontoTotal { get; set; }
        public string strSucursal { get; set; }
        public string strAgencia { get; set; }
        public string strNroOperacion { get; set; }
        public string strTerminal { get; set; }
        public string strMedioAtencion { get; set; }
        public string strNroCheque { get; set; }
        public string strCodigoBanco { get; set; }
        public string strCargoFijo { get; set; }
        public string strFlagExtorno { get; set; }
        public string strNroDocPago { get; set; }
        public string strNroOperacionBD { get; set; }
        public string strReferencia { get; set; }
        public string IdCiclo { get; set; }
        public string IdComprobante { get; set; }
        public Guid IdPreMatricula { get; set; }
        public virtual beRecepcion itmRecepcion { get; set; }
    }
}
