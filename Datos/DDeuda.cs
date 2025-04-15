using CEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DDeuda
    {
        coneccion con = new coneccion();
        SqlCommand cmm;
        EN_ObtenerDeudaCabecera cabecera;
        List<EN_ObtenerDeudaDeuda> _listaDeudas;

        public EN_ObtenerDeudaCabecera ObtenerDeudaCabecera(string idPersona)
        {
            cabecera= new EN_ObtenerDeudaCabecera();
            cmm = new SqlCommand("Intranet.sp_Obtener_Deuda", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 12).Value = idPersona;
            cmm.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            if (dr.Read())
            {
                cabecera.deuda= dr["deuda"].ToString();
                cabecera.monto = decimal.Parse(dr["monto"].ToString());
                cabecera.sede = dr["sede"].ToString();

            }
            con.con.Close();
            return cabecera;
        }


        public List<EN_ObtenerDeudaDeuda> ObtenerDeudaContenido(string idPersona)
        {
            _listaDeudas = new List<EN_ObtenerDeudaDeuda>();

            cmm = new SqlCommand("Intranet.sp_Obtener_Deuda", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 12).Value = idPersona;
            cmm.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            while (dr.Read())
            {
                EN_ObtenerDeudaDeuda deuda = new EN_ObtenerDeudaDeuda();
                deuda.id = int.Parse(dr["id"].ToString());
                deuda.descripcion = dr["descripcion"].ToString();
                deuda.monto = decimal.Parse(dr["monto"].ToString());
                _listaDeudas.Add(deuda);

            }
            con.con.Close();
            return _listaDeudas;
        }


        public string RegistrarDeudaTmp(string idPersona)
        {
            cabecera = new EN_ObtenerDeudaCabecera();
            cmm = new SqlCommand("Intranet.sp_registrarDeudaTmp", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 15).Value = idPersona;
           
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            string resultado="";

            if (dr.Read())
            {
                resultado = dr["resultado"].ToString();

            }
            con.con.Close();
            return resultado;
        }

        public string RegistrarDeudaTransacciones(string idPersona)
        {
            cabecera = new EN_ObtenerDeudaCabecera();
            cmm = new SqlCommand("Intranet.sp_registrarDeudaTransaccion", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 15).Value = idPersona;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            string resultado = "";

            if (dr.Read())
            {
                resultado = dr["resultado"].ToString();

            }
            con.con.Close();
            return resultado;
        }


    }
}
