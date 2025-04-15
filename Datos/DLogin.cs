using CEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DLogin
    {
        Login login;
        coneccion con = new coneccion();
        SqlCommand cmm;

        public string Ingresar(Login log)
        {
            cmm = new SqlCommand("ExaUbicacion.sp_programacion_costos_login", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@codigo", SqlDbType.Char, 10).Value = log.usuario;
            cmm.Parameters.Add("@password", SqlDbType.Char, 6).Value = log.password;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            string resultado = "";
            if (dr.Read())
            {
                //alumno.nro = dr["Nro"].ToString();
                resultado = dr["IdAlumno"].ToString();
                //alumno.apellidop = dr["ApellidoPaterno"].ToString();
                //alumno.apellidom = dr["ApellidoMaterno"].ToString();

            }

            con.con.Close();
            return resultado;
        }

        public Login RetornaraAP(string idAlumno)
        {
            cmm = new SqlCommand("NetCore.sp_obtener_actualizar_alumno", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtenerap";
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 15).Value = idAlumno;
            cmm.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = DBNull.Value;
            cmm.Parameters.Add("@celular", SqlDbType.VarChar, 30).Value = DBNull.Value;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            Login log = new Login();
            if (dr.Read())
            {
                //alumno.nro = dr["Nro"].ToString();
                log.fullname = dr["fullname"].ToString();
                log.dni = dr["DNI"].ToString();

            }

            con.con.Close();
            return log;
        }
    }
}
