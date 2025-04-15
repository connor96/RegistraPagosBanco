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
    public class daPersonaInstitucion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        bePersonaInstitucion itmPersonaInstitucion;
        beReturn itmReturn;

        public bePersonaInstitucion Detalle(string IdPersona)
        {
            itmPersonaInstitucion = new bePersonaInstitucion();
            cmm = new SqlCommand("CobranzaWeb.usp_Institucion_Get", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = IdPersona;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmPersonaInstitucion.IdPersona = Convert.ToString(dr["IdPersona"]);
                itmPersonaInstitucion.IdSede = Convert.ToInt16(dr["IdSede"]);
                itmPersonaInstitucion.IdCE = Convert.ToInt16(dr["IdCE"]);
                itmPersonaInstitucion.IdCarrera = Convert.ToInt16(dr["IdCarrera"]);
                itmPersonaInstitucion.NCarnet = Convert.ToString(dr["NCarnet"]);
                int x = dr.GetOrdinal("FVencimiento");
                itmPersonaInstitucion.FVencimiento = dr.IsDBNull(x) ? (DateTime?)null : Convert.ToDateTime(dr["FVencimiento"]);
                itmPersonaInstitucion.rowguid = Guid.Parse(Convert.ToString(dr["rowguid"]));
                itmPersonaInstitucion.Estado = Convert.ToBoolean(dr["Estado"]);
                itmPersonaInstitucion.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                itmPersonaInstitucion.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                itmPersonaInstitucion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                itmPersonaInstitucion.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                itmPersonaInstitucion.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                itmPersonaInstitucion.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                itmPersonaInstitucion.IdOcupacion = Convert.ToInt16(dr["IdOcupacion"]);
            }
            conec.Close();
            return itmPersonaInstitucion;
        }

        public beReturn Update(bePersonaInstitucion myitmPersonaInstitucion)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_Institucion_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = (myitmPersonaInstitucion.IdPersona == null) ? "" : myitmPersonaInstitucion.IdPersona;
                cmm.Parameters.Add("@IdOcupacion", SqlDbType.SmallInt).Value = myitmPersonaInstitucion.IdOcupacion;
                cmm.Parameters.Add("@IdCE", SqlDbType.Int).Value = myitmPersonaInstitucion.IdCE;
                cmm.Parameters.Add("@IdSede", SqlDbType.Int).Value = myitmPersonaInstitucion.IdSede;
                cmm.Parameters.Add("@IdCarrera", SqlDbType.SmallInt).Value = myitmPersonaInstitucion.IdCarrera;
                cmm.Parameters.Add("@NCarnet", SqlDbType.VarChar, 20).Value = (myitmPersonaInstitucion.NCarnet == null) ? "" : myitmPersonaInstitucion.NCarnet;
                cmm.Parameters.Add("@FVencimiento", SqlDbType.DateTime).Value = myitmPersonaInstitucion.FVencimiento;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar, 20).Value = (myitmPersonaInstitucion.TerminalRegistro == null) ? Environment.MachineName : myitmPersonaInstitucion.TerminalRegistro;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (myitmPersonaInstitucion.UserRegistro == null) ? "0000000000" : myitmPersonaInstitucion.UserRegistro;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = myitmPersonaInstitucion.IdPersona;
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                else
                {
                    itmReturn.strReturnValue = myitmPersonaInstitucion.IdPersona;
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
