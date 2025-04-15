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
    public class DProgramacion
    {
        coneccion con = new coneccion();
        SqlCommand cmm;
        List<EN_Programacion> lprogramacion;

        List<EN_Ciclo_Combo> lciclos;

        public List<EN_Programacion> RetornarCodProgramacion()
        {

            lprogramacion = new List<EN_Programacion>();

            cmm = new SqlCommand("NetCore.sp_manejociclo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "aciclo";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = DBNull.Value;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Alumno al = new EN_Alumno();

            while (dr.Read())
            {
                EN_Programacion programacion = new EN_Programacion();
                programacion.codProgramacion = dr["codprogramacion"].ToString();
                programacion.Descripcion = obtenerdescripcion(programacion.codProgramacion);
                lprogramacion.Add(programacion);
            }
            con.con.Close();
            return lprogramacion;
        }


        public EN_Programacion RetornarCodCiclo(string IdCiclo)
        {

            EN_Programacion prog = new EN_Programacion();

            cmm = new SqlCommand("NetCore.sp_conceptos_pagos", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "ccurso";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = IdCiclo;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = DBNull.Value;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Alumno al = new EN_Alumno();

            if (dr.Read())
            {
                prog.codnivel = dr["codnivel"].ToString();
                prog.curso = dr["curso"].ToString();
            }
            con.con.Close();
            return prog;
        }

        public EN_Programacion RetornarCodNivel(string Curso)
        {

            EN_Programacion prog = new EN_Programacion();

            cmm = new SqlCommand("NetCore.sp_conceptos_pagos", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "cccurso";
            cmm.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 11).Value = Curso;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = DBNull.Value;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_Alumno al = new EN_Alumno();

            if (dr.Read())
            {
                prog.codnivel = dr["codnivel"].ToString();
                prog.curso = dr["curso"].ToString();
            }
            con.con.Close();
            return prog;
        }

        public EN_Curso RetornarDetalleCurso(string Curso)
        {

            EN_Curso prog = new EN_Curso();

            cmm = new SqlCommand("NetCore.sp_manejociclo", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = "lciclo";
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 15).Value = Curso;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            if (dr.Read())
            {
                prog.CodCurso = dr["CodCurso"].ToString();
                prog.DesCurso = dr["DesCurso"].ToString();
                prog.CondNivelCurso = dr["CodNivelCurso"].ToString();
                prog.DesNivelCurso = dr["DesNivelCurso"].ToString();

            }
            con.con.Close();
            return prog;
        }

        public string obtenerdescripcion(string codProgramacion)
        {
            string mesDescripcion;
            switch (codProgramacion.Substring(2, 2))
            {
                case "01":
                    mesDescripcion = "Enero";
                    break;
                case "02":
                    mesDescripcion = "Febrero";
                    break;
                case "03":
                    mesDescripcion = "Marzo";
                    break;
                case "04":
                    mesDescripcion = "Abril";
                    break;
                case "05":
                    mesDescripcion = "Mayo";
                    break;
                case "06":
                    mesDescripcion = "Junio";
                    break;
                case "07":
                    mesDescripcion = "Julio";
                    break;
                case "08":
                    mesDescripcion = "Agosto";
                    break;
                case "09":
                    mesDescripcion = "Setiembre";
                    break;
                case "10":
                    mesDescripcion = "Octubre";
                    break;
                case "11":
                    mesDescripcion = "Noviembre";
                    break;
                case "12":
                    mesDescripcion = "Diciembre";
                    break;
                default:
                    mesDescripcion = "No Encontrado";
                    break;
            }

            string anio = DateTime.Now.Year.ToString();

            string periodoAnio = codProgramacion.Substring(0, 2);
            anio = "20" + periodoAnio;

            //switch (codProgramacion.Substring(0, 2))
            //{
            //    case "20":
            //        anio = "2020";
            //        break;
            //    case "21":
            //        anio = "2021";
            //        break;
            //    default:
            //        anio = "No Encontrado";
            //        break;
            //}

            return mesDescripcion + "-" + anio;

        }

        public List<EN_Ciclo_Combo> retornarciclos()
        {

            lciclos = new List<EN_Ciclo_Combo>();

            //agregar basico
            for (int i = 1; i < 13; i++)
            {
                EN_Ciclo_Combo ciclobasico = new EN_Ciclo_Combo();
                if (i < 10)
                {
                    ciclobasico.CodCiclo = "B0" + i;
                    ciclobasico.DesCiclo = "Básico " + i;
                }
                else
                {
                    ciclobasico.CodCiclo = "B" + i;
                    ciclobasico.DesCiclo = "Básico " + i;
                }
                lciclos.Add(ciclobasico);
            }

            //agregar intermedio
            for (int i = 1; i < 13; i++)
            {
                EN_Ciclo_Combo ciclointermedio = new EN_Ciclo_Combo();
                if (i < 10)
                {
                    ciclointermedio.CodCiclo = "I0" + i;
                    ciclointermedio.DesCiclo = "Intermedio " + i;
                }
                else
                {
                    ciclointermedio.CodCiclo = "I" + i;
                    ciclointermedio.DesCiclo = "Intermedio " + i;
                }
                lciclos.Add(ciclointermedio);
            }

            //agregar avanzado
            for (int i = 1; i < 13; i++)
            {
                EN_Ciclo_Combo cicloavanzado = new EN_Ciclo_Combo();
                if (i < 10)
                {
                    cicloavanzado.CodCiclo = "A0" + i;
                    cicloavanzado.DesCiclo = "Avanzado " + i;
                }
                else
                {
                    cicloavanzado.CodCiclo = "A" + i;
                    cicloavanzado.DesCiclo = "Avanzado " + i;
                }
                lciclos.Add(cicloavanzado);
            }
            //agregar met
            for (int i = 1; i < 7; i++)
            {
                EN_Ciclo_Combo ciclomet = new EN_Ciclo_Combo();
                ciclomet.CodCiclo = "MET" + i;
                ciclomet.DesCiclo = "MET " + i;
                lciclos.Add(ciclomet);
            }
            return lciclos;

        }
    }
}
