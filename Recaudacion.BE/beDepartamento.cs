using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recaudacion.BE
{
    public class beDepartamento
    {
        public beDepartamento()
        {
            this.lisProvincia = new HashSet<beProvincia>();
        }
        public string CodDepartamento { get; set; }
        public string DesDepartamento { get; set; }
        public virtual ICollection<beProvincia> lisProvincia { get; set; }
    }
}
