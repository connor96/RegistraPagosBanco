using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LCurso
    {
        DCurso obj_Curso = new DCurso();
        DProgramacion obj_Programacion = new DProgramacion();

        public EN_Curso_Libro RetornarCursoLibro(string IdCiclo)
        {
            return obj_Curso.RetornarCursoLibro(IdCiclo);
        }

        public EN_Curso RetornarCursoTabla(string IdCiclo)
        {
            return obj_Curso.RetornarCursoTabla(IdCiclo);
        }

        public EN_Curso RetornarDetalleCurso(string CodCurso)
        {
            return obj_Programacion.RetornarDetalleCurso(CodCurso);
        }
    }
}
