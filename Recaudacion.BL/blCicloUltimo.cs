using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;


namespace Recaudacion.BL
{
    public class blCicloUltimo
    {
        beCicloUltimo itmCicloUltimo;
        beGradeCard itmGradeCard;
        daCicloUltimo objCicloUltimo = new daCicloUltimo();
        blCurso objCurso = new blCurso();
        public beCicloUltimo ListaCicloUltimoByUsuario(string idPersona)
        {
            itmCicloUltimo = new beCicloUltimo();
            itmCicloUltimo = objCicloUltimo.ListaCicloUltimoByUsuario(idPersona);
            if (itmCicloUltimo.CodCurso != null)
            {
                itmCicloUltimo.itmCurso = objCurso.Detalle(itmCicloUltimo.CodCurso);
            }
            return itmCicloUltimo;
        }
        public beGradeCard GradeCard(string idPersona)
        {
            itmGradeCard = new beGradeCard();
            itmGradeCard = objCicloUltimo.GradeCard(idPersona);
            itmGradeCard.PrerequisitoSiguienteCurso = (itmGradeCard.NotaFinal > 79) ? itmGradeCard.CodCurso : itmGradeCard.PreRequisito;
            return itmGradeCard;
        }
    }
}
