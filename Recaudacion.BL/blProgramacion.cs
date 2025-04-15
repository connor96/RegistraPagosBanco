using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recaudacion.BE;
using Recaudacion.DA;

namespace Recaudacion.BL
{
    public class blProgramacion
    {
        beProgramacion itmProgramacion;
        List<beProgramacion> lisProgramacion;
        daProgramacion objProgramacion = new daProgramacion();
        public List<beProgramacion> ListarProgramacionByUsuario(string IdPersona, int IdSede)
        {
            return objProgramacion.ListarProgramacionByUsuario(IdPersona, IdSede);
        }
        public List<beProgramacion> ListarProgramacionByCurso(string IdPersona, string CodCurso)
        {
            return objProgramacion.ListarProgramacionByCurso(IdPersona, CodCurso);
        }
        public List<beProgramacion> ListarProgramacionPorLocalCurso(int idlocal, string CodCurso)
        {
            lisProgramacion = new List<beProgramacion>();
            lisProgramacion = objProgramacion.ListarProgramacionPorLocalCurso(idlocal, CodCurso);
            return lisProgramacion;
        }
    }
}
