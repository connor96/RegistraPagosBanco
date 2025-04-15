using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beProvincia
    {
        public beProvincia()
        {
            this.lisDistrito = new HashSet<beDistrito>();
        }
        public string CodDepartamento { get; set; }
        public string CodProvincia { get; set; }
        public string DesProvincia { get; set; }
        public virtual beDepartamento itmDepartamento { get; set; }
        public virtual ICollection<beDistrito> lisDistrito { get; set; }
    }
}
