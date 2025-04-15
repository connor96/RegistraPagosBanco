using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blCiclo
    {
        beCiclo itmCiclo;
        List<beCiclo> lisCiclo;
        daCiclo objCiclo = new daCiclo();
        blCurso objCurso = new blCurso();
        public List<beCiclo> ListaCicloByLocalCursoCiclo(int IdLocal, string codCurso, string idPeriodo)
        {
            lisCiclo = new List<beCiclo>();
            lisCiclo = objCiclo.ListaCicloByLocalCursoCiclo(IdLocal, codCurso, idPeriodo);
            return lisCiclo;
        }
        public List<beCiclo> ListaCicloByCurso(string idPersona, string codCurso, string idPeriodo)
        {
            return objCiclo.ListaCicloByCurso(idPersona, codCurso, idPeriodo); ;
        }
        public List<beCiclo> ListaCicloByUsuario(string idPersona, int idSede, string codCurso, string idPeriodo)
        {
            return objCiclo.ListaCicloByUsuario(idPersona, idSede, codCurso, idPeriodo);
        }
        public beCiclo detalle(string IdCiclo)
        {
            itmCiclo = new beCiclo();
            itmCiclo = objCiclo.detalle(IdCiclo);
            itmCiclo.itmCurso = objCurso.Detalle(itmCiclo.CodCurso);
            return itmCiclo;
        }
    }
}
