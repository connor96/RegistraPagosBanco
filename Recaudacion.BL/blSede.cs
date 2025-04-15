using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blSede
    {
        beSede itmSede;
        List<beSede> lisSede;
        daSede objSede = new daSede();
        public List<beSede> ListaSede()
        {
            return objSede.ListaSede();
        }
    }
}
