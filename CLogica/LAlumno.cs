using CEntidades;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica
{
    public class LAlumno
    {
        DAlumno obj_alumno = new DAlumno();
        EN_Alumno alumno;
        EN_PHoraria registrado;
        DVoucher obj_voucher = new DVoucher();

        public EN_Alumno ObtenerUltimoCiclo(EN_Alumno alum)
        {
            alumno = new EN_Alumno();
            alumno = obj_alumno.ObtenerUltimoCiclo(alum);
            return alumno;
        }

        public List<EN_PHoraria> ObtenerRegistros(EN_Alumno alum)
        {
            return obj_alumno.ObtenerRegistros(alum);
        }

        public List<EN_Curso> ObtenerCiclosMatriculados(EN_Alumno alum)
        {

            return obj_alumno.ObtenerCiclosMatriculados(alum);
        }

        public EN_Voucher obtenerDatos(string idPersona)
        {
            return obj_voucher.RetornarDatos(idPersona);
        }
    }
}
