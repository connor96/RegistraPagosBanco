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
    public class DPagoProgramacion
    {

        coneccion con = new coneccion();
        SqlCommand cmm;


        EN_BencoCursoCabecera _BencoCursoCabecera;
        EN_BancoSede _sedesActivasBanco;
        List<EN_BancoSede> _listaSedes;

        public EN_BencoCursoCabecera opcionMatricula(string idPersona)
        {
            _BencoCursoCabecera = new EN_BencoCursoCabecera();
            string resultado = "";
            cmm = new SqlCommand("Intranet.sp_Frecuencias_Matricula_Cabecera", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idAlumno", SqlDbType.VarChar, 11).Value = idPersona;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            if (dr.Read())
            {
                _BencoCursoCabecera.programa = dr["programa"].ToString();
                _BencoCursoCabecera.nivel = dr["nivel"].ToString();
                _BencoCursoCabecera.desCurso = dr["desCurso"].ToString();
                _BencoCursoCabecera.CodCurso = dr["CodCurso"].ToString();
            }
            con.con.Close();
            return _BencoCursoCabecera;
        }

        public List<EN_BancoSede> listaSedesActivas(string curso)
        {
            _listaSedes= new List<EN_BancoSede> ();
            string resultado = "";
            cmm = new SqlCommand("Intranet.sp_Frecuencias_Matricula_Sede", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@cursoSiguiente", SqlDbType.VarChar, 15).Value = curso;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                _sedesActivasBanco = new EN_BancoSede();
                _sedesActivasBanco.IdSede = dr["IdSede"].ToString();
                _sedesActivasBanco.Sede = dr["Sede"].ToString();
                _listaSedes.Add(_sedesActivasBanco);
            }
            con.con.Close();
            return _listaSedes;
        }

        public string registrarPrematricula(int v, string idCiclo, string? idPersona)
        {
            string resultado = "";
            cmm = new SqlCommand("Intranet.sp_registrarPrematriculaTmp", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.Int).Value = v;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 15).Value = idPersona;
            cmm.Parameters.Add("@idCiclo", SqlDbType.VarChar, 20).Value = idCiclo;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            if (dr.Read())
            {
                resultado = dr["resultado"].ToString();
            }
            con.con.Close();
            return resultado;
        }
    }
}
