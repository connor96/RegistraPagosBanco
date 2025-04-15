using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blError
    {
        beError itmError;
        beCicloUltimo itmCicloUltimo;
        beCurso itmCurso;
        blCicloUltimo objCicloUltimo = new blCicloUltimo();
        daCredencial objCredencial = new daCredencial();
        blCurso objCurso = new blCurso();
        List<beDeuda> lisDeuda;
        List<bePreMatricula> lisPrematricula;
        blPreMatricula objPreMatricula = new blPreMatricula();
        blDeuda objDeuda = new blDeuda();

        public beError Error(string strIdPersona)
        {
            itmCicloUltimo = new beCicloUltimo();
            itmCurso = new beCurso();
            itmError = new beError();
            itmCicloUltimo = objCicloUltimo.ListaCicloUltimoByUsuario(strIdPersona);
            //Verificamos si existen matricula

            //Verificar deudas anteriores
            lisDeuda = new List<beDeuda>();
            lisDeuda = objDeuda.CalculaDeuda(strIdPersona);
            if (lisDeuda.Count > 0)
            {
                itmError.intIdError = 0;
                itmError.strError = "Estimado alumno, usted cuenta con una deuda de S/ "+ lisDeuda.Sum(x => x.Deuda)+ " Soles. Por lo que debe acercarse a caja de nuestra institución para cancelar su deuda. <br /> Recuerda que para el uso de esta plataforma no debe acumular deudas. Agradecemos su comprensión.";
                return itmError;
            }
            lisPrematricula = new List<bePreMatricula>();
            lisPrematricula = objPreMatricula.ListarPorUsuario(strIdPersona);
            if (lisPrematricula.Where(x => x.EsCaducado == false).Count() > 0)//&& itmCicloUltimo.NotaFinal > 91)
            {
                itmError.intIdError = 0;
                itmError.strError = "Estimado alumno, en estos momentos se encuentra una prematrícula pendiente de atención.";
                return itmError;
            }

            if (itmCicloUltimo.IdMatricula != null && itmCicloUltimo.IdMatricula != "")
            {
                //Verificamos Cursos actuales
                if (itmCicloUltimo.FechaActual > itmCicloUltimo.Inicio && itmCicloUltimo.FechaActual < itmCicloUltimo.Final)
                {
                    itmError.intIdError = 0;
                    itmError.strError = "Estimado alumno, acabamos de verificar que está cursando un ciclo. Por favor inténtelo en la nueva apertura de ciclo, agradecemos su comprensión.";
                    return itmError;
                }
                //Verificamos los tres meses maximos de interrupción
                if (itmCicloUltimo.Meses > 4)
                {
                    itmError.intIdError = 0;
                    itmError.strError = "Estimado alumno, ya pasaron los cuatro meses de interrupción. Por lo que deberá rendir el examen de ubicación, para ello deberá realizar el pago en caja de nuestra institución.";
                    return itmError;
                }
                if (itmCicloUltimo.NotaFinal > 79)
                {
                    itmCurso = objCurso.CursoByUsuario(strIdPersona, itmCicloUltimo.IdSede, itmCicloUltimo.CodCurso, false);
                }
                else
                {
                    itmCurso = objCurso.CursoByUsuario(strIdPersona, itmCicloUltimo.IdSede, itmCicloUltimo.PreRequisito, false);
                }
                if (itmCurso.CodCurso == null || itmCurso.CodCurso == "")
                {
                    itmError.intIdError = 0;
                    itmError.strError = "Estimado alumno, en estos momentos no se programaron ciclos para el curso que le correspo Por favor contáctese con un personal de la institución.";
                    return itmError;
                }
                else
                {
                    itmError.intIdError = 1;
                    itmError.strError = itmCurso.CodCurso;
                    return itmError;
                }
            }
            else
            {
                itmCurso = objCurso.CursoByUsuario(strIdPersona, itmCicloUltimo.IdSede, itmCicloUltimo.PreRequisito, true);
                itmError.intIdError = 2;
                itmError.strError = itmCurso.CodCurso;
                if (itmCurso.CodCurso == null || itmCurso.CodCurso == "")
                {
                    itmError.intIdError = 0;
                    itmError.strError = "Estimado alumno, en estos momentos no se programaron ciclos para el curso que le correspo Por favor contáctese con un personal de la institución.";
                    return itmError;
                }
            }

            return itmError;
        }
    }
}
