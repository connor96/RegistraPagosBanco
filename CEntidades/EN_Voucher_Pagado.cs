using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Voucher_Pagado
    {
        public string IdTransaccion { get; set; }
        public string IdPersona { get; set; }
        public string DNI { get; set; }
        public string Fullname { get; set; }
        public string IdSede { get; set; }
        public List<EN_Curso> cursosregistrados { get; set; }
        public List<EN_Voucher_Pago> vouchersregistrados { get; set; }
        public List<EN_Conceptos> conceptos { get; set; }
        public int monto { get; set; }
        public string periodo { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public EN_Alumno alumno { get; set; }
        public string terminalRegistro { get; set; }
    }
}
