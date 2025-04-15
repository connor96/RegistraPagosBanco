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
    public class daLocal
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beLocal itmLocal;
        List<beLocal> lisLocal;
        public beLocal Detalle(byte IdLocal)
        {
            itmLocal = new beLocal();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_LocalById", conec);
                cmm.Parameters.Add("@IdLocal", SqlDbType.TinyInt).Value = IdLocal;
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmLocal.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmLocal.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmLocal.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmLocal.CodLocal = Convert.ToByte(dr["CodLocal"]);
                    itmLocal.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmLocal.Local = Convert.ToString(dr["Local"]);
                    itmLocal.Direccion = Convert.ToString(dr["Direccion"]);
                    //itmLocal.rowguid = Convert.ToByte(dr["rowguid"]);
                    itmLocal.Estado = Convert.ToByte(dr["Estado"]);
                    //itmLocal.FechaRegistro = Convert.ToString(dr["FechaRegistro"]);
                    itmLocal.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmLocal.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmLocal.FechaActualizacion = Convert.ToString(dr["FechaActualizacion"]);
                    itmLocal.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmLocal.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                    //itmLocal._IdLocal = Convert.ToString(dr["_IdLocal"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmLocal;
        }

        public List<beLocal> Lista()
        {
            lisLocal = new List<beLocal>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Local", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmLocal = new beLocal();
                    itmLocal.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmLocal.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmLocal.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmLocal.CodLocal = Convert.ToByte(dr["CodLocal"]);
                    itmLocal.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmLocal.Local = Convert.ToString(dr["Local"]);
                    itmLocal.Direccion = Convert.ToString(dr["Direccion"]);
                    //itmLocal.rowguid = Convert.ToByte(dr["rowguid"]);
                    itmLocal.Estado = Convert.ToByte(dr["Estado"]);
                    //itmLocal.FechaRegistro = Convert.ToString(dr["FechaRegistro"]);
                    itmLocal.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmLocal.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmLocal.FechaActualizacion = Convert.ToString(dr["FechaActualizacion"]);
                    itmLocal.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmLocal.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                    //itmLocal._IdLocal = Convert.ToString(dr["_IdLocal"]);
                    lisLocal.Add(itmLocal);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisLocal;
        }
        public List<beLocal> ListaByCurso(string strCodCurso)
        {
            lisLocal = new List<beLocal>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_LocalByCurso", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@CodCurso", SqlDbType.VarChar, 15).Value = strCodCurso;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmLocal = new beLocal();
                    itmLocal.IdLocal = Convert.ToByte(dr["IdLocal"]);
                    itmLocal.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmLocal.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    //itmLocal.CodLocal = Convert.ToByte(dr["CodLocal"]);
                    //itmLocal.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmLocal.Local = Convert.ToString(dr["Local"]);
                    //itmLocal.Direccion = Convert.ToString(dr["Direccion"]);
                    //itmLocal.Estado = Convert.ToByte(dr["Estado"]);
                    //itmLocal.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    //itmLocal.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmLocal.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    //itmLocal.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                    lisLocal.Add(itmLocal);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisLocal;
        }
    }
}
