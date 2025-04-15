using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blCE
    {
        beCE itmCE;
        List<beCE> lisCE;

        daCE objCE = new daCE();
        public List<beCE> ListaPorOcupacion(int IdOcupacion)
        {
            lisCE = new List<beCE>();
            lisCE = objCE.ListaPorOcupacion(IdOcupacion);
            return lisCE;
        }
    }
}
