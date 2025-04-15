using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blLocal
    {
        beLocal itmLocal;
        List<beLocal> lisLocal;
        daLocal objLocal = new daLocal();
        public beLocal Detalle(byte IdLocal)
        {
            itmLocal = new beLocal();
            itmLocal = objLocal.Detalle(IdLocal);
            return itmLocal;
        }
        public List<beLocal> Lista()
        {
            lisLocal = new List<beLocal>();
            lisLocal = objLocal.Lista();
            return lisLocal;
        }
        public List<beLocal> ListaByCurso(string strCodCurso)
        {
            lisLocal = new List<beLocal>();
            lisLocal = objLocal.ListaByCurso(strCodCurso);
            return lisLocal;
        }
    }
}
