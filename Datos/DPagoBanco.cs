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
    
    public class DPagoBanco
    {
        coneccion con = new coneccion();
        SqlCommand cmm;

        List<EN_BancoTablaPensiones> _listaPensiones;
        List<string> _listaIdCiclos;

        public string opcionMatricula(string idPersona)
        {
            string resultado = "";
            cmm = new SqlCommand("Intranet.sp_Opciones_Matricula", con.con);
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
                resultado = dr["resultado"].ToString();
            }
            con.con.Close();
            return resultado;
        }

        public List<EN_BancoTablaPensiones> tablaPensiones(string idPersona)
        {
            _listaPensiones = new List<EN_BancoTablaPensiones>();
            cmm = new SqlCommand("Intranet.sp_Cargar_Pagos_Transaccionestmp", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idAlumno", SqlDbType.VarChar, 12).Value = idPersona;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                EN_BancoTablaPensiones _pension= new EN_BancoTablaPensiones();
                _pension.idConcepto= dr["IdConceptoMatricula"].ToString();
                _pension.idDescuento = dr["IdDescuento"].ToString();
                _pension.idMatricula = dr["IdMatricula"].ToString();
                _pension.descripcion = dr["Descripcion"].ToString();
                _pension.monto = decimal.Parse(dr["Monto"].ToString());
                _listaPensiones.Add(_pension);
            }
            con.con.Close();
            return _listaPensiones;
        }

        public List<string> listaIdCiclos(string idPersona)
        {
            _listaIdCiclos= new List<string>();

            cmm = new SqlCommand("Intranet.sp_obtenerCiclosRegistrados", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idAlumno", SqlDbType.VarChar, 12).Value = idPersona;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            while (dr.Read())
            {
               
                string idCiclo = dr["IdCiclo"].ToString();

                _listaIdCiclos.Add(idCiclo);
            }
            con.con.Close();
            return _listaIdCiclos;

        }


        public string CalcularTransaccionesTmp(string idPersona,string idCiclo)
        {
 
            cmm = new SqlCommand("Intranet.sp_calcularTransaccionesTmp", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idCiclo", SqlDbType.VarChar, 15).Value = idCiclo;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 10).Value = idPersona;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            string descripcion="";

            while (dr.Read())
            {

                descripcion = dr["descripcion"].ToString();
                
            }
            con.con.Close();
            return descripcion;

        }

        public string RegistrarPago(string? idPersona, string correo, string telefono)
        {
            string resultado = "";

            cmm = new SqlCommand("Intranet.sp_RegistrarPago", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 15).Value = idPersona;
            cmm.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = correo;
            cmm.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = telefono;

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

       

        public List<EN_PagoMatriculaA> MatriculaPagoA(string? idPersona)
        {
            string resultado = "";

            cmm = new SqlCommand("Intranet.sp_obtenerResumenMatricula", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 12).Value = idPersona;

            List<EN_PagoMatriculaA> _matriculaALista = new List<EN_PagoMatriculaA>();


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            while (dr.Read())
            {
                EN_PagoMatriculaA matriculaA = new EN_PagoMatriculaA();
                matriculaA.Descripcion= dr["Descripcion"].ToString();
                matriculaA.Monto = decimal.Parse(dr["Monto"].ToString());
                matriculaA.Estado = bool.Parse(dr["Estado"].ToString());
                matriculaA.CajaProcesado = bool.Parse(dr["procesado"].ToString());
                _matriculaALista.Add(matriculaA);

            }
            con.con.Close();
            return _matriculaALista;
        }

        public EN_PagoMatriculaB MatriculaPagoB(string? idPersona)
        {
            string resultado = "";

            cmm = new SqlCommand("Intranet.sp_obtenerResumenMatricula", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 12).Value = idPersona;

 
            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();

            EN_PagoMatriculaB _matriculaB = new EN_PagoMatriculaB();

            while (dr.Read())
            {

                _matriculaB.frecuencia = dr["frecuencia"].ToString();
                _matriculaB.DesMallaCurricular = dr["DesMallaCurricular"].ToString();
                _matriculaB.modalidad = dr["modalidad"].ToString();
                _matriculaB.nivel = dr["nivel"].ToString();
                _matriculaB.DesCurso = dr["DesCurso"].ToString();
                _matriculaB.aula = dr["aula"].ToString();
                _matriculaB.horario = dr["horario"].ToString();
                _matriculaB.docente = dr["docente"].ToString();

            }
            con.con.Close();
            return _matriculaB;
        }


        public List<EN_PagoMatriculaA> PagoDeuda(string? idPersona)
        {
            string resultado = "";

            cmm = new SqlCommand("Intranet.sp_obtenerResumenDeuda", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 12).Value = idPersona;

            List<EN_PagoMatriculaA> _matriculaALista = new List<EN_PagoMatriculaA>();


            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();


            while (dr.Read())
            {
                EN_PagoMatriculaA matriculaA = new EN_PagoMatriculaA();
                matriculaA.Descripcion = dr["Descripcion"].ToString();
                matriculaA.Monto = decimal.Parse(dr["Monto"].ToString());
                matriculaA.Estado = bool.Parse(dr["Estado"].ToString());
                _matriculaALista.Add(matriculaA);

            }
            con.con.Close();
            return _matriculaALista;
        }

        public void actualizarDatos(string? idPersona, string correo, string telefono)
        {
            string resultado = "";
            cmm = new SqlCommand("Intranet.sp_ActualizarDatos", con.con);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@idPersona", SqlDbType.VarChar, 12).Value = idPersona;
            cmm.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = correo;
            cmm.Parameters.Add("@telefono", SqlDbType.VarChar, 30).Value = telefono;

            SqlDataReader dr;
            if (ConnectionState.Closed == con.con.State)
            {
                con.con.Open();
            }
            dr = cmm.ExecuteReader();
            con.con.Close();
          
        }



    }
}
