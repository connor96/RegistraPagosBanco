using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blProvincia
    {
        beProvincia itmProvincia;
        List<beProvincia> lisProvincia;
        daProvincia objProvincia = new daProvincia();
        public List<beProvincia> ListaPorDepartamento(string CodDepartamento)
        {
            lisProvincia = new List<beProvincia>();
            lisProvincia = objProvincia.ListaPorDepartamento(CodDepartamento);
            return lisProvincia;
        }
    }
}
