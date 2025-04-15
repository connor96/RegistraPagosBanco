using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades
{
    public class EN_Voucher_Pago
    {
        public string banco { get; set; }
        public string nrooperacion { get; set; }
        public DateTime fecha { get; set; }
        public string url { get; set; }
    }
}
