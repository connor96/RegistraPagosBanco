using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blCurso
    {
        beCurso itmCurso;
        List<beCurso> lisCurso;
        daCurso objCurso = new daCurso();
        public beCurso CursoByUsuario(string idPersona, int Sede, string PreRequisito, bool PorEdad)
        {
            return objCurso.CursoByUsuario(idPersona, Sede, PreRequisito, PorEdad);
        }
        public List<beCurso> ListaCursoByUsuario(string idPersona, int Sede)
        {
            return objCurso.ListaCursoByUsuario(idPersona, Sede);
        }
        public beCurso Detalle(string IdCurso)
        {
            itmCurso = new beCurso();
            itmCurso = objCurso.Detalle(IdCurso);
            return itmCurso;
        }
        public List<beCurso> ListaPorPersona(string idPersona, string PreRequisito)
        {
            lisCurso = new List<beCurso>();
            lisCurso = objCurso.ListaPorPersona(idPersona, PreRequisito);
            return lisCurso;
        }
    }
}
