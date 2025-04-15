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
    public class DHorarios
    {
        coneccion con = new coneccion();
        SqlCommand cmph;
        List<EN_PHoraria> Lista_PHoraria;
        List<EN_Frecuencia> Lista_Frecuencia;
        List<EN_Contacto> L_Contacto;
        List<EN_Inicio> L_Inicio;


        public List<EN_PHoraria> ListaSedes(string curso)
        {
            Lista_PHoraria = new List<EN_PHoraria>();
            cmph = new SqlCommand("[Intranet].[sp_Frecuencias_Matricula_Sede]", con.con);
            cmph.CommandType = CommandType.StoredProcedure;

            cmph.Parameters.Add("@cursoSiguiente", SqlDbType.VarChar, 15).Value = curso;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmph.ExecuteReader();
            while (dr.Read())
            {

                EN_PHoraria progh = new EN_PHoraria();
                progh.idsede = dr["IdSede"].ToString();
                progh.sede = dr["Sede"].ToString();
                //progh.desmallacurricular = dr["DesMallaCurricular"].ToString();
                //progh.idmodalidad = dr["idmodalidad"].ToString();
                //progh.modalidad = dr["modalidad"].ToString();
                //progh.codnivel = dr["codnivel"].ToString();
                //progh.orden = dr["orden"].ToString();
                //progh.nivel = dr["nivel"].ToString();
                //progh.curso = dr["curso"].ToString();
                //progh.frecuencia = dr["frecuencia"].ToString();
                //progh.inicio = dr["Inicio"].ToString();
                //progh.final = dr["Final"].ToString();
                //progh.aula = dr["aula"].ToString();
                //progh.mes = dr["Mes"].ToString();
                //progh.anio = dr["anio"].ToString();
                //progh.codturno = dr["codturno"].ToString();

                
                Lista_PHoraria.Add(progh);


            }
            con.con.Close();

            return Lista_PHoraria;

        }



        public List<EN_PHoraria> ListaFrecuencias(string sede,string curso)
        {
            Lista_PHoraria = new List<EN_PHoraria>();
            cmph = new SqlCommand("[Intranet].[sp_Frecuencias_Matricula_Frecuencia]", con.con);
            cmph.CommandType = CommandType.StoredProcedure;

            cmph.Parameters.Add("@sedeSeleccionada", SqlDbType.VarChar, 15).Value = sede;
            cmph.Parameters.Add("@cursoSiguiente", SqlDbType.VarChar, 15).Value = curso;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmph.ExecuteReader();
            while (dr.Read())
            {

                EN_PHoraria progh = new EN_PHoraria();

                progh.idmodalidad = dr["concatenado"].ToString();
                progh.modalidad_eng = dr["frecuencia"].ToString();
                progh.modalidad_esp = dr["frecuencia"].ToString();


                Lista_PHoraria.Add(progh);


            }
            con.con.Close();

            return Lista_PHoraria;

        }


        public List<EN_PHoraria> Listas_PH(string opcion, string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia)
        {
            Lista_PHoraria = new List<EN_PHoraria>();

            cmph = new SqlCommand("[ExaUbicacion].[sp_programacion_horaria]", con.con);
            cmph.CommandType = CommandType.StoredProcedure;

            if (opcion == "sede")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = DBNull.Value;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = DBNull.Value;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = DBNull.Value;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = DBNull.Value;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {

                    EN_PHoraria progh = new EN_PHoraria();
                    progh.idsede = dr["idsede"].ToString();
                    progh.sede = dr["sedes"].ToString();
                    //progh.desmallacurricular = dr["DesMallaCurricular"].ToString();
                    //progh.idmodalidad = dr["idmodalidad"].ToString();
                    //progh.modalidad = dr["modalidad"].ToString();
                    //progh.codnivel = dr["codnivel"].ToString();
                    //progh.orden = dr["orden"].ToString();
                    //progh.nivel = dr["nivel"].ToString();
                    //progh.curso = dr["curso"].ToString();
                    //progh.frecuencia = dr["frecuencia"].ToString();
                    //progh.inicio = dr["Inicio"].ToString();
                    //progh.final = dr["Final"].ToString();
                    //progh.aula = dr["aula"].ToString();
                    //progh.mes = dr["Mes"].ToString();
                    //progh.anio = dr["anio"].ToString();
                    //progh.codturno = dr["codturno"].ToString();

                    if (progh.sede == "HUANCAYO")
                    {
                        progh.sede = "HUANCAYO";
                    }

                    if (progh.sede != "HUANCAVELICA")
                    {
                        Lista_PHoraria.Add(progh);
                    }

                }
                con.con.Close();
            }

            if (opcion == "nivel")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = DBNull.Value;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.codnivel = dr["codnivel"].ToString();
                    progh.orden = dr["orden"].ToString();
                    progh.nivel = dr["nivel"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "modalidad")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.idmodalidad = dr["idmodalidad"].ToString();
                    progh.modalidad_eng = dr["modalidad_eng"].ToString();
                    progh.modalidad_esp = dr["modalidad_esp"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "cursos")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.curso = dr["curso"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "frecuencia")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    //progh.frecuencia = dr["frecuencia"].ToString();
                    //progh.turno= dr["turno"].ToString();
                    progh.idturno = dr["idturno"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "programacion")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = frecuencia;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.frecuencia = dr["frecuencia"].ToString();
                    progh.idsede = dr["IdSede"].ToString();
                    //progh.inicio= dr["Inicio"].ToString();
                    //progh.final = dr["Final"].ToString();
                    progh.fullhora = dr["fullhora"].ToString();
                    progh.aula = dr["aula"].ToString();
                    progh.idturno = dr["idturno"].ToString();
                    progh.Apellidos = dr["Apellidos"].ToString();
                    progh.idCiclo = dr["IdCiclo"].ToString();
                    string codigo = dr["IdCiclo"].ToString();
                    progh.mes = dr["Mes"].ToString();
                    progh.anio = dr["anio"].ToString();
                    progh.presencial = _evaluarPresencialidad(dr["modalidad"].ToString());
                    progh.Contacto = Listar_Contacto(codigo);
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "programacion2")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = frecuencia;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.frecuencia = dr["frecuencia"].ToString();
                    progh.idsede = dr["IdSede"].ToString();
                    //progh.inicio= dr["Inicio"].ToString();
                    //progh.final = dr["Final"].ToString();
                    progh.fullhora = dr["fullhora"].ToString();
                    progh.aula = dr["aula"].ToString();
                    progh.idturno = dr["idturno"].ToString();
                    progh.Apellidos = dr["Apellidos"].ToString();
                    progh.idCiclo = dr["IdCiclo"].ToString();
                    string codigo = dr["IdCiclo"].ToString();
                    progh.mes = dr["Mes"].ToString();
                    progh.anio = dr["anio"].ToString();
                    progh.presencial = _evaluarPresencialidad(dr["modalidad"].ToString());
                    progh.Contacto = Listar_Contacto(codigo);
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }


            if (opcion == "detalles")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.curso = dr["curso"].ToString();
                    progh.modalidad_esp = dr["modalidad_esp"].ToString();
                    Lista_PHoraria.Add(progh);

                }
                con.con.Close();
            }

            if (opcion == "detalles2")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.curso = dr["curso"].ToString();
                    progh.modalidad_esp = dr["modalidad_esp"].ToString();
                    Lista_PHoraria.Add(progh);

                }
                con.con.Close();
            }


            return Lista_PHoraria;
        }

        private bool _evaluarPresencialidad(string v)
        {
            if (v == "VIRTUAL")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<EN_PHoraria> Listas_PH_ninios(string opcion, string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia)
        {
            Lista_PHoraria = new List<EN_PHoraria>();

            cmph = new SqlCommand("[ExaUbicacion].[sp_programacion_horaria_ninios]", con.con);
            cmph.CommandType = CommandType.StoredProcedure;

            if (opcion == "sede")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = DBNull.Value;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = DBNull.Value;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = DBNull.Value;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = DBNull.Value;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {

                    EN_PHoraria progh = new EN_PHoraria();
                    progh.idsede = dr["idsede"].ToString();
                    progh.sede = dr["sedes"].ToString();
                    //progh.desmallacurricular = dr["DesMallaCurricular"].ToString();
                    //progh.idmodalidad = dr["idmodalidad"].ToString();
                    //progh.modalidad = dr["modalidad"].ToString();
                    //progh.codnivel = dr["codnivel"].ToString();
                    //progh.orden = dr["orden"].ToString();
                    //progh.nivel = dr["nivel"].ToString();
                    //progh.curso = dr["curso"].ToString();
                    //progh.frecuencia = dr["frecuencia"].ToString();
                    //progh.inicio = dr["Inicio"].ToString();
                    //progh.final = dr["Final"].ToString();
                    //progh.aula = dr["aula"].ToString();
                    //progh.mes = dr["Mes"].ToString();
                    //progh.anio = dr["anio"].ToString();
                    //progh.codturno = dr["codturno"].ToString();

                    if (progh.sede == "HUANCAYO")
                    {
                        progh.sede = "HUANCAYO";
                    }

                    if (progh.sede != "HUANCAVELICA")
                    {
                        Lista_PHoraria.Add(progh);
                    }

                }
                con.con.Close();
            }

            if (opcion == "nivel")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = DBNull.Value;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.codnivel = dr["codnivel"].ToString();
                    progh.orden = dr["orden"].ToString();
                    progh.nivel = dr["nivel"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "modalidad")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = DBNull.Value;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.idmodalidad = dr["idmodalidad"].ToString();
                    progh.modalidad_eng = dr["modalidad_eng"].ToString();
                    progh.modalidad_esp = dr["modalidad_esp"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "cursos")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = DBNull.Value;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.curso = dr["curso"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "frecuencia")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    //progh.frecuencia = dr["frecuencia"].ToString();
                    //progh.turno= dr["turno"].ToString();
                    progh.idturno = dr["idturno"].ToString();
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "programacion")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = frecuencia;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.frecuencia = dr["frecuencia"].ToString();
                    progh.idsede = dr["IdSede"].ToString();
                    //progh.inicio= dr["Inicio"].ToString();
                    //progh.final = dr["Final"].ToString();
                    progh.fullhora = dr["fullhora"].ToString();
                    progh.aula = dr["aula"].ToString();
                    progh.idturno = dr["idturno"].ToString();
                    progh.Apellidos = dr["Apellidos"].ToString();
                    progh.idCiclo = dr["IdCiclo"].ToString();
                    string codigo = dr["IdCiclo"].ToString();
                    progh.mes = dr["Mes"].ToString();
                    progh.anio = dr["anio"].ToString();
                    progh.Contacto = Listar_Contacto(codigo);
                    Lista_PHoraria.Add(progh);
                }
                con.con.Close();
            }

            if (opcion == "detalles")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr;
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                dr = cmph.ExecuteReader();
                while (dr.Read())
                {
                    EN_PHoraria progh = new EN_PHoraria();
                    progh.curso = dr["curso"].ToString();
                    progh.modalidad_esp = dr["modalidad_esp"].ToString();
                    Lista_PHoraria.Add(progh);

                }
                con.con.Close();
            }

            return Lista_PHoraria;
        }

        public List<EN_Frecuencia> ListarFrecuencias(string opcion, string idsede, string anio, string mes, string codnivel, string modalidad, string curso, string frecuencia)
        {
            coneccion con2 = new coneccion();
            Lista_Frecuencia = new List<EN_Frecuencia>();

            cmph = new SqlCommand("[ExaUbicacion].[sp_programacion_horaria]", con2.con);
            cmph.CommandType = CommandType.StoredProcedure;

            if (opcion == "frecuencia")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr2;
                if (ConnectionState.Closed == con2.con.State)
                {
                    con2.con.Open();
                }
                dr2 = cmph.ExecuteReader();
                while (dr2.Read())
                {
                    EN_Frecuencia progh = new EN_Frecuencia();
                    //progh.frecuencia = dr["frecuencia"].ToString();
                    //progh.turno= dr["turno"].ToString();
                    progh.idTurno = dr2["idturno"].ToString();
                    progh.Programacion = Listas_PH("programacion", idsede, anio, mes, codnivel, modalidad, curso, progh.idTurno);
                    Lista_Frecuencia.Add(progh);
                }
                con2.con.Close();
            }


            if (opcion == "frecuencia2")
            {
                cmph.Parameters.Add("@opcion", SqlDbType.VarChar, 15).Value = opcion;
                cmph.Parameters.Add("@idsede", SqlDbType.VarChar, 1).Value = idsede;
                cmph.Parameters.Add("@anio", SqlDbType.VarChar, 4).Value = anio;
                cmph.Parameters.Add("@mes", SqlDbType.VarChar, 2).Value = mes;
                cmph.Parameters.Add("@codnivel", SqlDbType.VarChar, 5).Value = codnivel;
                cmph.Parameters.Add("@modalidad", SqlDbType.VarChar, 30).Value = modalidad;
                cmph.Parameters.Add("@curso", SqlDbType.VarChar, 10).Value = curso;
                cmph.Parameters.Add("@frec", SqlDbType.VarChar, 10).Value = DBNull.Value;
                SqlDataReader dr2;
                if (ConnectionState.Closed == con2.con.State)
                {
                    con2.con.Open();
                }
                dr2 = cmph.ExecuteReader();
                while (dr2.Read())
                {
                    EN_Frecuencia progh = new EN_Frecuencia();
                    //progh.frecuencia = dr["frecuencia"].ToString();
                    //progh.turno= dr["turno"].ToString();
                    progh.idTurno = dr2["idturno"].ToString();
                    progh.Programacion = Listas_PH("programacion2", idsede, anio, mes, codnivel, modalidad, curso, progh.idTurno);
                    Lista_Frecuencia.Add(progh);
                }
                con2.con.Close();
            }

            Lista_Frecuencia = _validarAlumnos(Lista_Frecuencia);
            //Lista_Frecuencia = _validarModalidad(Lista_Frecuencia);

            return Lista_Frecuencia;
        }

        private List<EN_Frecuencia> _validarAlumnos(List<EN_Frecuencia> lista_Frecuencia)
        {
            foreach (var item in lista_Frecuencia)
            {
                foreach (var programacion in item.Programacion)
                {
                    programacion.Vacantes = _contarRegistros(programacion);
                    if (programacion.Vacantes < 1)
                    {
                        programacion.Visible = false;
                    }
                    else
                    {
                        programacion.Visible = true;
                    }
                    //programacion.Vacantes = 25;
                }
            }
            return lista_Frecuencia;
        }

        private int _contarRegistros(EN_PHoraria programacion)
        {
            con = new coneccion();
            SqlCommand comand = new SqlCommand("[NetCore].[sp_ValidarCantidadCurso]", con.con);
            comand.CommandType = CommandType.StoredProcedure;

            comand.Parameters.Add("@IdCiclo", SqlDbType.VarChar, 20).Value = programacion.idCiclo;
            SqlDataReader dataReader;

            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dataReader = comand.ExecuteReader();
            string resultado = "";
            while (dataReader.Read())
            {
                resultado = dataReader["cantidadVacantes"].ToString();
            }
            con.con.Close();

            return int.Parse(resultado);
        }

        //private List<EN_Frecuencia> _validarModalidad(List<EN_Frecuencia> lista_Frecuencia)
        //{

        //    foreach (var item in lista_Frecuencia)
        //    {
        //        foreach (var programacion in item.Programacion)
        //        {
        //            programacion.presencial = _validarPresencialidad(programacion);
        //        }
        //    }
        //    return lista_Frecuencia;
        //}

        //private bool _validarPresencialidad(EN_PHoraria programacion)
        //{

        //    bool estado=false;

        //    con = new coneccion();
        //    SqlCommand comand = new SqlCommand("[NetCore].[sp_ValidarCursoPresencial2]", con.con);
        //    comand.CommandType = CommandType.StoredProcedure;

        //    comand.Parameters.Add("@IdCiclo", SqlDbType.VarChar,20).Value = programacion.idCiclo;
        //    SqlDataReader dataReader;

        //    if (ConnectionState.Closed == con.con.State)
        //    {
        //        con.con.Open();
        //    }
        //    dataReader = comand.ExecuteReader();
        //    string resultado = "";
        //    while (dataReader.Read())
        //    {
        //        resultado = dataReader["IdModalidad"].ToString();
        //    }
        //    con.con.Close();

        //    if (resultado=="1")
        //    {
        //        estado = true;
        //    }

        //    return estado;
        //}

        public List<EN_Contacto> Listar_Contacto(string codigo)
        {

            coneccion con3 = new coneccion();
            L_Contacto = new List<EN_Contacto>();
            SqlCommand comand = new SqlCommand("[ExaUbicacion].[sp_programacion_horaria_datos]", con3.con);
            comand.CommandType = CommandType.StoredProcedure;

            comand.Parameters.Add("@codigo", SqlDbType.Char, 11).Value = codigo;
            SqlDataReader dataReader;

            if (ConnectionState.Closed == con3.con.State)
            {
                con3.con.Open();
            }
            dataReader = comand.ExecuteReader();
            while (dataReader.Read())
            {
                EN_Contacto contact = new EN_Contacto();
                contact.IdTipoContacto = int.Parse(dataReader["IdTipoContacto"].ToString());
                contact.NumMail = dataReader["NumMail"].ToString();
                L_Contacto.Add(contact);

            }
            con3.con.Close();

            return L_Contacto;

        }

        public List<EN_Inicio> Listar_Inicio(string mes, string year)
        {

            con = new coneccion();
            L_Inicio = new List<EN_Inicio>();
            SqlCommand comand = new SqlCommand("[ExaUbicacion].[sp_programacion_horaria_inicio]", con.con);
            comand.CommandType = CommandType.StoredProcedure;

            comand.Parameters.Add("@mes", SqlDbType.Char, 2).Value = mes;
            comand.Parameters.Add("@year", SqlDbType.Char, 4).Value = year;
            SqlDataReader dataReader;

            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dataReader = comand.ExecuteReader();
            while (dataReader.Read())
            {
                EN_Inicio inicio = new EN_Inicio();
                inicio.modalidad = dataReader["modalidad"].ToString();
                inicio.sede = dataReader["Sede"].ToString();
                inicio.inicio = DateTime.Parse(dataReader["inicio"].ToString());
                inicio.final = DateTime.Parse(dataReader["final"].ToString());
                L_Inicio.Add(inicio);

            }
            con.con.Close();

            return L_Inicio;
        }
    }
}
