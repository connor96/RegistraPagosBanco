using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blCECarrera
    {
        beCECarrera itmCECarrera;
        List<beCECarrera> lisCECarrera;
        daCECarrera objCECarrera = new daCECarrera();
        public List<beCECarrera> ListaPorCE(int IdCE)
        {
            lisCECarrera = new List<beCECarrera>();
            lisCECarrera = objCECarrera.ListaPorCE(IdCE);
            return lisCECarrera;
        }
    }
}
