using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beDistrito
    {
        public string CodUbigeo { get; set; }
        public string CodDepartamento { get; set; }
        public string CodProvincia { get; set; }
        public string CodDistrito { get; set; }
        public string DesDistrito { get; set; }
        public virtual beProvincia itmProvincia { get; set; }
    }
}
