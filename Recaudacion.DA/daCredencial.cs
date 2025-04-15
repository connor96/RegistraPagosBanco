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
    public class daCredencial
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beCredencial itmCredencial;
        beUsuario itmUsuario;
        public beCredencial Credencial(string strIdPersona, string strClave)
        {
            cmm = new SqlCommand("CobranzaWeb.usp_Credencial_Get", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar).Value = strIdPersona;
            cmm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = strClave;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmCredencial = new beCredencial();
                itmCredencial.IdPersona = Convert.ToString(dr["IdPersona"]);
                itmCredencial.DNI = Convert.ToString(dr["DNI"]);
                itmCredencial.Nombres = Convert.ToString(dr["Nombres1"]) + " " + Convert.ToString(dr["Nombres2"]);
                itmCredencial.Apellidos = Convert.ToString(dr["ApellidoPaterno"]) + " " + Convert.ToString(dr["ApellidoMaterno"]);
                itmCredencial.NombreCompleto = itmCredencial.Apellidos.Trim() + ", " + itmCredencial.Nombres.Trim();
                itmCredencial.Clave = Convert.ToString(dr["Clave"]);
                itmCredencial.intEdad = Convert.ToInt16(dr["intEdad"]);
                itmCredencial.EdaDetallada = Convert.ToString(dr["EdadDetallada"]);
            }
            conec.Close();
            return itmCredencial;
        }
        public beUsuario CredencialAdministrativo(string IdUser, string strClave)
        {
            cmm = new SqlCommand("CobranzaWeb.wsp_Usuario_Acceso", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdUser", SqlDbType.VarChar).Value = IdUser;
            cmm.Parameters.Add("@strClave", SqlDbType.VarChar).Value = @strClave;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                itmUsuario = new beUsuario();
                itmUsuario.IdUser = Convert.ToString(dr["IdUser"]);
                itmUsuario.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
            }
            conec.Close();
            return itmUsuario;
        }
    }
}
