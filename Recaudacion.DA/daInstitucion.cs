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
    public class daInstitucion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beInstitucion itmInstitucion;
        List<beInstitucion> lisInstitucion;
        public beInstitucion Detalle(int IdInstitucion)
        {
            itmInstitucion = new beInstitucion();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_institucionByID", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = IdInstitucion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmInstitucion.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmInstitucion.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmInstitucion.RazonSocial = Convert.ToString(dr["RazonSocial"]);
                    itmInstitucion.RazonSocialRes = Convert.ToString(dr["RazonSocialRes"]);
                    itmInstitucion.RUC = Convert.ToString(dr["RUC"]);
                    itmInstitucion.Direccion = Convert.ToString(dr["Direccion"]);
                    itmInstitucion.Email = Convert.ToString(dr["Email"]);
                    //itmInstitucion.LogoPequeno = Convert.ToSByte(dr["dblMontoTotal"]);
                    //itmInstitucion.Logo = Convert.ToByte(dr["strCodigoServicio"]);
                    //itmInstitucion.rowguid = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmInstitucion.Estado = Convert.ToByte(dr["Estado"]);
                    //itmInstitucion.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmInstitucion.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmInstitucion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmInstitucion.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                    itmInstitucion.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmInstitucion.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmInstitucion;
        }
        public List<beInstitucion> Lista()
        {
            lisInstitucion = new List<beInstitucion>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_institucionLista", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmInstitucion = new beInstitucion();
                    itmInstitucion.IdInstitucion = Convert.ToByte(dr["IdInstitucion"]);
                    itmInstitucion.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmInstitucion.RazonSocial = Convert.ToString(dr["RazonSocial"]);
                    itmInstitucion.RazonSocialRes = Convert.ToString(dr["RazonSocialRes"]);
                    itmInstitucion.RUC = Convert.ToString(dr["RUC"]);
                    itmInstitucion.Direccion = Convert.ToString(dr["Direccion"]);
                    itmInstitucion.Email = Convert.ToString(dr["Email"]);
                    //itmInstitucion.LogoPequeno = Convert.ToSByte(dr["dblMontoTotal"]);
                    //itmInstitucion.Logo = Convert.ToByte(dr["strCodigoServicio"]);
                    //itmInstitucion.rowguid = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmInstitucion.Estado = Convert.ToByte(dr["Estado"]);
                    //itmInstitucion.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    itmInstitucion.TerminalRegistro = Convert.ToString(dr["TerminalRegistro"]);
                    itmInstitucion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    //itmInstitucion.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                    itmInstitucion.TerminalActualizacion = Convert.ToString(dr["TerminalActualizacion"]);
                    itmInstitucion.UserActualizacion = Convert.ToString(dr["UserActualizacion"]);
                    lisInstitucion.Add(itmInstitucion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisInstitucion;
        }

    }
}
