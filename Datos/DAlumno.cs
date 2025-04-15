using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidades;

namespace Datos
{
    public class DAlumno
    {
        coneccion con = new coneccion();
        coneccion con2 = new coneccion();
        SqlCommand cmm;
        SqlCommand cmm2;

        List<EN_PHoraria> lphoraria;
        List<EN_Curso> ciclos_matriculados;


        public EN_Alumno ObtenerUltimoCiclo(EN_Alumno alumno)
        {
            cmm = new SqlCommand("NetCore.sp_manejociclo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "uciclo";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = alumno.IdAlumno;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Alumno al = new EN_Alumno();

            if (dr.Read())
            {
                al.UltimoCiclo = dr["ultimociclo"].ToString();
            }
            con.con.Close();
            return al;
        }

        public List<EN_PHoraria> ObtenerRegistros(EN_Alumno alumno)
        {
            lphoraria = new List<EN_PHoraria>();

            DHorarios contacto = new DHorarios();
            cmm = new SqlCommand("NetCore.sp_manejociclo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "vciclo";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = alumno.IdAlumno;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            while (dr.Read())
            {
                EN_PHoraria al = new EN_PHoraria();
                al.curso = dr["DesCurso"].ToString();
                al.modalidad_esp = dr["modalidad_esp"].ToString();
                al.Apellidos = dr["docente"].ToString();
                al.CodDocente = dr["CodDocente"].ToString();
                al.fullhora = dr["horario"].ToString();
                if (al.CodDocente != "")
                {
                    al.Contacto = contacto.Listar_Contacto(al.CodDocente);
                }

                lphoraria.Add(al);

            }
            con.con.Close();
            return lphoraria;
        }


        public EN_Alumno ObtenerDireccion(EN_Alumno alumno)
        {

            DHorarios contacto = new DHorarios();
            cmm = new SqlCommand("NetCore.sp_obtenerdireccion", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "odireccion";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = alumno.IdAlumno;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Alumno al = new EN_Alumno();

            if (dr.Read())
            {
                al.IdAlumno = dr["IdPersona"].ToString();
                al.Direccion = dr["Direccion"].ToString();
                al.Direccion = validardireccion(al.Direccion);
            }
            con.con.Close();
            return al;
        }

        public List<EN_Curso> ObtenerCiclosMatriculados(EN_Alumno alumno)
        {
            ciclos_matriculados = new List<EN_Curso>();

            cmm = new SqlCommand("NetCore.sp_validar_registro_pago_periodo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "ociclos";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = alumno.IdAlumno;
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 15).Value = DBNull.Value;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                EN_Curso curso = new EN_Curso();
                curso.IdCiclo = dr["IdCiclo"].ToString();
                curso.CodCurso = dr["curso"].ToString();
                curso.Horario = dr["horario"].ToString();
                curso.DesCurso = dr["DesCurso"].ToString();
                curso.Docente = dr["docente"].ToString();
                curso.ModalidadEsp = dr["modalidad_eng"].ToString();
                curso.Frecuencia = dr["frecuencia"].ToString();
                curso.aula = dr["aula"].ToString();
                curso.Enlace = _validarEnlace(curso.IdCiclo);

                ciclos_matriculados.Add(curso);
            }
            con.con.Close();
            return ciclos_matriculados;
        }

        private string _validarEnlace(string idCiclo)
        {

            cmm2 = new SqlCommand("NetCore.sp_obtenerEnlace", con2.con);
            cmm2.CommandType = CommandType.StoredProcedure;
            cmm2.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 15).Value = idCiclo;

            string enlace = "";

            SqlDataReader dr2;
            if (ConnectionState.Closed == con2.con.State)
            {
                con2.con.Open();
            }
            dr2 = cmm2.ExecuteReader();
            while (dr2.Read())
            {
                enlace = dr2["URL"].ToString();
            }
            con2.con.Close();
            return enlace;
        }

        public string validardireccion(string direccion)
        {
            if (direccion == "")
            {
                return "NO SE HA REGISTRADO NINGUNA DIRECCION";
            }
            else
            {
                return direccion;
            }
        }
    }
}
