using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LProgramacion
    {
        DProgramacion objProgramacion = new DProgramacion();

        public List<EN_Programacion> RetornarCodProgramacion()
        {
            return objProgramacion.RetornarCodProgramacion();
        }

        public List<EN_Ciclo_Combo> RetornarCiclos()
        {
            return objProgramacion.retornarciclos();
        }

        public EN_Programacion RetornarCodCiclo(string IdCiclo)
        {
            return objProgramacion.RetornarCodCiclo(IdCiclo);

        }
        public EN_Programacion RetornarCodNivel(string Curso)
        {
            return objProgramacion.RetornarCodNivel(Curso);

        }
    }
}
