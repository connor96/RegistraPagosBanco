using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Recaudacion.BE;

namespace Recaudacion.DA
{
    public class daRegistro
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beRegistro itmRegistro;
        public string Registro(beRegistro myitmRegistro)
        {
            string ReturnValue = "";
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_Persona_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdTipoDocumento", SqlDbType.TinyInt).Value = myitmRegistro.IdTipoDocumento;
                cmm.Parameters.Add("@Nombres1", SqlDbType.VarChar, 50).Value = (myitmRegistro.Nombres1 == null)?string.Empty: myitmRegistro.Nombres1;
                cmm.Parameters.Add("@Nombres2", SqlDbType.VarChar, 50).Value = (myitmRegistro.Nombres2 == null)?string.Empty: myitmRegistro.Nombres2;
                cmm.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = (myitmRegistro.ApellidoPaterno == null)?string.Empty: myitmRegistro.ApellidoPaterno;
                cmm.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = (myitmRegistro.ApellidoMaterno == null)?string.Empty: myitmRegistro.ApellidoMaterno;
                cmm.Parameters.Add("@DNI", SqlDbType.VarChar, 50).Value = (myitmRegistro.DNI == null)?string.Empty: myitmRegistro.DNI;
                cmm.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = (myitmRegistro.Email == null)?string.Empty: myitmRegistro.Email;
                cmm.Parameters.Add("@Telefono", SqlDbType.VarChar, 50).Value = (myitmRegistro.Telefono == null)?string.Empty: myitmRegistro.Telefono;
                cmm.Parameters.Add("@TerminalRegistro", SqlDbType.VarChar, 50).Value = (myitmRegistro.TerminalRegistro == null) ? Environment.MachineName : myitmRegistro.TerminalRegistro;
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 50).Value = (myitmRegistro.UserRegistro == null) ? "0000000000" : myitmRegistro.UserRegistro;
                cmm.Parameters.Add("@Clave", SqlDbType.VarChar, 6).Value = (myitmRegistro.Clave == null) ? string.Empty : myitmRegistro.Clave;
                cmm.Parameters.Add("@FNacimiento", SqlDbType.Date).Value = (myitmRegistro.FNacimiento == null) ? DateTime.Now : myitmRegistro.FNacimiento;
                //cmm.Parameters.Add("@FNacimiento", SqlDbType.Date).Value = (myitmRegistro.FNacimiento == null) ? DateTime.Now : Convert.ToDateTime(myitmRegistro.FNacimiento);
                SqlParameter IdPersona = new SqlParameter();
                IdPersona.ParameterName = "@IdPersona";
                IdPersona.SqlDbType = SqlDbType.VarChar;
                IdPersona.Size = 20;
                IdPersona.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(IdPersona).Value = (myitmRegistro.IdPersona == null)?string.Empty: myitmRegistro.IdPersona;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                ReturnValue = cmm.Parameters["@IdPersona"].Value.ToString();
                //if (sqlRows > 0)
                //{
                //    ReturnValue = cmm.Parameters["@IdPersona"].Value.ToString();
                //}
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReturnValue;
        }
        //public beAlumno Buscar(int Tipo, string Opcion, string Busqueda)
        //{
        //    itmAlumno = new beAlumno();
        //    cmm = new SqlCommand("Persona.usp_Persona_Get", conec);
        //    cmm.CommandType = CommandType.StoredProcedure;
        //    cmm.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
        //    cmm.Parameters.Add("@Opcion", SqlDbType.VarChar).Value = Opcion;
        //    cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar).Value = Busqueda;
        //    if (conec.State == ConnectionState.Closed)
        //    {
        //        conec.Open();
        //    }
        //    SqlDataReader dr = cmm.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        itmAlumno.IdOcupacion = Convert.ToInt32(dr["IdOcupacion"]);
        //        itmAlumno.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
        //        itmAlumno.IdTipoVia = Convert.ToInt32(dr["IdTipoVia"]);
        //        itmAlumno.NombreVia = Convert.ToString(dr["NombreVia"]);
        //        itmAlumno.IdDenominacionUrbana = Convert.ToString(dr["DenominacionUrbana"]);
        //        itmAlumno.IdTipoDocumento = Convert.ToInt32(dr[""]);
        //        itmAlumno.Nombres1 = Convert.ToString(dr["Nombres1"]);
        //        itmAlumno.Nombres2 = Convert.ToString(dr["Nombres2"]);
        //        itmAlumno.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
        //        itmAlumno.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
        //        itmAlumno.Completo = Convert.ToString(dr["Completo"]);
        //        itmAlumno.DNI = Convert.ToString(dr["DNI"]);
        //        itmAlumno.FNacimiento = Convert.ToDateTime(dr["FNacimiento"]);
        //        itmAlumno.Sexo = Convert.ToString(dr["Sexo"]);
        //        itmAlumno.TipoDireccion = Convert.ToString(dr[""]);
        //        itmAlumno.Numero = Convert.ToString(dr["Numero"]);
        //        itmAlumno.IdLocal = Convert.ToInt32(dr["IdLocal"]);
        //        itmAlumno.Estado = Convert.ToInt32(dr["Estado"]);
        //        itmAlumno.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
        //        itmAlumno.UserRegistro = Convert.ToString(dr["UserRegistro"]);
        //        itmAlumno.IdPersona = Convert.ToString(dr["IdPersona"]);
        //    }
        //    conec.Close();
        //    return itmAlumno;

        //}
    }
}
