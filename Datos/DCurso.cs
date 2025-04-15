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
    public class DCurso
    {
        coneccion con = new coneccion();
        SqlCommand cmm;

        public EN_Curso_Libro RetornarCursoLibro(string IdCiclo)
        {
            cmm = new SqlCommand("NetCore.sp_obtener_curso_libro", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "obtener";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 15).Value = IdCiclo;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Curso_Libro cursolibro = new EN_Curso_Libro();

            if (dr.Read())
            {
                cursolibro.IdCiclo = dr["IdCiclo"].ToString();
                cursolibro.Curso = dr["Curso"].ToString();
                cursolibro.IdCiclo = dr["IdCiclo"].ToString();
                cursolibro.Descripcion = dr["Descripción"].ToString();
                cursolibro.Libro = dr["Libro"].ToString();
                cursolibro.LinkClases = dr["Link"].ToString();
                cursolibro.LinkLibro1 = dr["Link1"].ToString();
                cursolibro.LinkLibro2 = dr["Link2"].ToString();

            }
            con.con.Close();
            return cursolibro;
        }


        public EN_Curso RetornarCursoTabla(string IdCiclo)
        {
            cmm = new SqlCommand("NetCore.sp_manejociclo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "ociclo";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = IdCiclo;
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            EN_Curso curso = new EN_Curso();
            if (dr.Read())
            {
                curso.IdSede = dr["IdSede"].ToString();
                curso.CodCurso = dr["curso"].ToString();
                curso.IdCiclo = dr["IdCiclo"].ToString();
                curso.DesCurso = dr["DesCurso"].ToString();
                curso.CodNivel = dr["codnivel"].ToString();
                curso.Horario = dr["horario"].ToString();
                curso.Docente = dr["docente"].ToString();
                curso.ModalidadEsp = dr["modalidad_esp"].ToString();
                curso.mes = dr["Mes"].ToString();
                curso.anio = dr["anio"].ToString();
            }
            con.con.Close();
            return curso;
        }
    }
}
