using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Recaudacion.BE
{
    public class beTipoContacto
    {
        public beTipoContacto()
        {
            this.lisContacto = new HashSet<beContacto>();
        }
        public int IdTipoContacto { get; set; }
        public string DesTipoContacto { get; set; }
        public virtual ICollection<beContacto> lisContacto { get; set; }
    }
}
