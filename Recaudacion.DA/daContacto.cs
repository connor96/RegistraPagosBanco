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
    public class daContacto
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beContacto> lisContacto;
        beContacto itmContacto;
        beReturn itmReturn;
        public List<beContacto> Lista(string strIdPersona)
        {
            lisContacto = new List<beContacto>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_Contacto_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = strIdPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmContacto = new beContacto();
                    itmContacto.IdTipoContacto = Convert.ToInt16(dr["IdTipoContacto"]);
                    itmContacto.IdPersona = strIdPersona;
                    itmContacto.NumMail = Convert.ToString(dr["NumMail"]);
                    itmContacto.Emergencia = Convert.ToBoolean(dr["Emergencia"]);
                    itmContacto.Obs = Convert.ToString(dr["Obs"]);
                    itmContacto.rowguid = Guid.Parse(Convert.ToString(dr["rowguid"]));
                    itmContacto.itmTipoContacto = new beTipoContacto();
                    itmContacto.itmTipoContacto.IdTipoContacto = Convert.ToInt16(dr["IdTipoContacto"]);
                    itmContacto.itmTipoContacto.DesTipoContacto = Convert.ToString(dr["DesTipoContacto"]);
                    lisContacto.Add(itmContacto);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisContacto;
        }
        public beReturn Insert(beContacto myitmContacto)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("Contacto.usp_Contacto_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdTipoContacto", SqlDbType.SmallInt).Value = myitmContacto.IdTipoContacto;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = (myitmContacto.IdPersona == null) ? "" : myitmContacto.IdPersona;
                cmm.Parameters.Add("@NumMail", SqlDbType.VarChar, 50).Value = (myitmContacto.NumMail == null) ? "" : myitmContacto.NumMail;
                cmm.Parameters.Add("@Emergencia", SqlDbType.Bit).Value = myitmContacto.Emergencia;
                cmm.Parameters.Add("@Obs", SqlDbType.VarChar, 50).Value = (myitmContacto.Obs == null) ? "" : myitmContacto.Obs;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar, 20).Value = (myitmContacto.TerminalRegistro == null) ? Environment.MachineName : myitmContacto.TerminalRegistro;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (myitmContacto.UserRegistro == null) ? "0000000000" : myitmContacto.UserRegistro;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = myitmContacto.IdPersona;
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                else
                {
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Error);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Delete(Guid guiRowguid)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_Contacto_Delete", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@rowguid", SqlDbType.UniqueIdentifier).Value = guiRowguid;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                itmReturn.intIdReturn = cmm.ExecuteNonQuery();
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = guiRowguid.ToString();
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Eliminar_Ok);
                }
                else
                {
                    itmReturn.strReturnValue = "";
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Eliminar_Error);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
    }
}
