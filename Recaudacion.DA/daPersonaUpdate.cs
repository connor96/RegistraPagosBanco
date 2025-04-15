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
    public class daPersonaUpdate
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        bePersonaUpdate itmPersonaUp;
        beReturn itmReturn;
        public bePersonaUpdate Detalle(string IdPersona)
        {
            itmPersonaUp = new bePersonaUpdate();
            cmm = new SqlCommand("CobranzaWeb.wsp_Persona_ByID", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = IdPersona;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmPersonaUp.IdPersona = Convert.ToString(dr["IdPersona"]);
                itmPersonaUp.IdOcupacion = Convert.ToInt16(dr["IdOcupacion"]);
                itmPersonaUp.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                itmPersonaUp.IdTipoVia = Convert.ToByte(dr["IdTipoVia"]);
                itmPersonaUp.NombreVia = Convert.ToString(dr["NombreVia"]);
                itmPersonaUp.DenominacionUrbana = Convert.ToString(dr["DenominacionUrbana"]);
                itmPersonaUp.IdTipoDocumento = Convert.ToByte(dr["IdTipoDocumento"]);
                itmPersonaUp.Nombres1 = Convert.ToString(dr["Nombres1"]);
                itmPersonaUp.Nombres2 = Convert.ToString(dr["Nombres2"]);
                itmPersonaUp.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                itmPersonaUp.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                //itmPersona.NombreCompleto = itmPersona.ApellidoPaterno.Trim() + " " + itmPersona.ApellidoMaterno.Trim() + ", " + itmPersona.Nombres1.Trim() + " " + itmPersona.Nombres2.Trim();
                itmPersonaUp.DNI = Convert.ToString(dr["DNI"]);
                itmPersonaUp.FNacimiento = Convert.ToDateTime(dr["FNacimiento"]);
                //itmPersona.EdadDetallada = Convert.ToString(dr["EdadDetallada"]);
                itmPersonaUp.Sexo = Convert.ToString(dr["Sexo"]);
                itmPersonaUp.TipoDireccion = Convert.ToString(dr["TipoDireccion"]);
                itmPersonaUp.Numero = Convert.ToString(dr["Numero"]);
                //itmPersona.Picture = Convert.ToString(dr["Picture"]);
                itmPersonaUp.IdLocal = Convert.ToInt16(dr["IdLocal"]);
                itmPersonaUp.Estado = Convert.ToByte(dr["Estado"]);
                itmPersonaUp.Terminal = Convert.ToString(dr["Terminal"]);
                itmPersonaUp.User = Convert.ToString(dr["User"]);
                //itmPersona.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                //itmPersona.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                //itmPersona.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                //itmPersona.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                //itmPersona.C_Codigo = Convert.ToString(dr["C_Codigo"]);
                itmPersonaUp.Email = Convert.ToString(dr["Email"]);
            }
            conec.Close();
            return itmPersonaUp;
        }
        public beReturn Update(bePersonaUpdate myitmPersonaUpdate)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_Persona_Update", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = (myitmPersonaUpdate.IdPersona == null) ? "" : myitmPersonaUpdate.IdPersona;
                //cmm.Parameters.Add("@IdOcupacion", SqlDbType.SmallInt).Value = myitmPersonaUpdate.IdOcupacion;
                cmm.Parameters.Add("@CodUbigeo", SqlDbType.Char, 6).Value = (myitmPersonaUpdate.CodUbigeo == null) ? "" : myitmPersonaUpdate.CodUbigeo;
                cmm.Parameters.Add("@IdTipoVia", SqlDbType.TinyInt).Value = myitmPersonaUpdate.IdTipoVia;
                cmm.Parameters.Add("@NombreVia", SqlDbType.VarChar, 50).Value = (myitmPersonaUpdate.NombreVia == null) ? "" : myitmPersonaUpdate.NombreVia;
                cmm.Parameters.Add("@DenominacionUrbana", SqlDbType.VarChar, 50).Value = (myitmPersonaUpdate.DenominacionUrbana == null) ? "" : myitmPersonaUpdate.DenominacionUrbana;
                //cmm.Parameters.Add("@IdTipoDocumento", SqlDbType.TinyInt).Value = myitmPersonaUpdate.IdTipoDocumento;
                //cmm.Parameters.Add("@Nombres1", SqlDbType.VarChar, 100).Value = (myitmPersonaUpdate.Nombres1 == null) ? "" : myitmPersonaUpdate.Nombres1;
                //cmm.Parameters.Add("@Nombres2", SqlDbType.VarChar, 100).Value = (myitmPersonaUpdate.Nombres2 == null) ? "" : myitmPersonaUpdate.Nombres2;
                //cmm.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = (myitmPersonaUpdate.ApellidoPaterno == null) ? "" : myitmPersonaUpdate.ApellidoPaterno;
                //cmm.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = (myitmPersonaUpdate.ApellidoMaterno == null) ? "" : myitmPersonaUpdate.ApellidoMaterno;
                //cmm.Parameters.Add("@DNI", SqlDbType.VarChar,20).Value = (myitmPersonaUpdate.DNI == null) ? "" : myitmPersonaUpdate.DNI;
                cmm.Parameters.Add("@FNacimiento", SqlDbType.Date).Value = (myitmPersonaUpdate.FNacimiento == null) ? DateTime.Now : myitmPersonaUpdate.FNacimiento;
                cmm.Parameters.Add("@Sexo", SqlDbType.Char,1).Value = (myitmPersonaUpdate.Sexo == null) ? "" : myitmPersonaUpdate.Sexo;
                cmm.Parameters.Add("@TipoDireccion", SqlDbType.VarChar,30).Value = (myitmPersonaUpdate.TipoDireccion == null) ? "" : myitmPersonaUpdate.TipoDireccion;
                cmm.Parameters.Add("@Numero", SqlDbType.VarChar,30).Value = (myitmPersonaUpdate.Numero == null) ? "" : myitmPersonaUpdate.Numero;
                cmm.Parameters.Add("@IdLocal", SqlDbType.TinyInt).Value = myitmPersonaUpdate.IdLocal;
                //cmm.Parameters.Add("@Estado", SqlDbType.TinyInt).Value = myitmPersonaUpdate.Estado;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar,20).Value = (myitmPersonaUpdate.Terminal == null) ? Environment.MachineName : myitmPersonaUpdate.Terminal;
                cmm.Parameters.Add("@User", SqlDbType.VarChar,50).Value = (myitmPersonaUpdate.User == null) ? "0000000000" : myitmPersonaUpdate.User;
                cmm.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = (myitmPersonaUpdate.Email == null) ? "" : myitmPersonaUpdate.Email;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = myitmPersonaUpdate.IdPersona;
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                else
                {
                    itmReturn.strReturnValue = myitmPersonaUpdate.IdPersona;
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Error);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = -1;
                itmReturn.strReturnValue = "0";
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
    }
}
