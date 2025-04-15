using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beComprobante
    {
        public beComprobante()
        {
            this.lisDetalleComprobante = new HashSet<beDetalleComprobante>();
            //this.lisAnticipos = new HashSet<beAnticipos>();
            //this.lisEmpresaAlumno = new HashSet<beEmpresaAlumno>();
            //this.lisMatricula = new HashSet<beMatricula>();
            //this.lisPerComprobante = new HashSet<bePerComprobante>();
        }

        public string IdComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public byte IdTipoComprobante { get; set; }
        public byte IdLocal { get; set; }
        public byte IdDescuentoSede { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal TotalCompromiso { get; set; }
        public decimal ImpAnticipos { get; set; }
        public decimal Importe { get; set; }
        public decimal Dscto { get; set; }
        public decimal TotalPago { get; set; }
        public DateTime Periodo { get; set; }
        public string DeudaAnterior { get; set; }
        public string CtaContable { get; set; }
        public string IdDeposito { get; set; }
        public bool Credito { get; set; }
        public string IdPagoCredito { get; set; }
        public Guid rowguid { get; set; }
        public string Obs { get; set; }
        public byte Estado { get; set; }
        public DateTimeOffset FechaRegistro { get; set; }
        public string TerminalRegistro { get; set; }
        public string UserRegistro { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }
        public string TerminalActualizacion { get; set; }
        public string UserActualizacion { get; set; }

        public virtual beLocal itmLocal { get; set; }

        public virtual ICollection<beDetalleComprobante> lisDetalleComprobante { get; set; }
        //public virtual ICollection<beAnticipos> lisAnticipos { get; set; }
        //public virtual beEmpresa itmEmpresa { get; set; }
        //public virtual beTipoComprobante itmTipoComprobante { get; set; }
        //public virtual ICollection<beEmpresaAlumno> lisEmpresaAlumno { get; set; }
        //public virtual ICollection<beMatricula> lisMatricula { get; set; }
        //public virtual ICollection<bePerComprobante> lisPerComprobante { get; set; }
    }
}
