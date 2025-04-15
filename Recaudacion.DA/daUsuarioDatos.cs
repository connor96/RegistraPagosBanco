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
    public class daUsuarioDatos
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        beUsuarioDatos itmUsuarioDatos;
        List<beUsuarioDatos> lisUsuarioDatos;
        public beUsuarioDatos Detalle(string IdUser)
        {
            itmUsuarioDatos = new beUsuarioDatos();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_UsuarioDetalle_Detalle", conec);
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (IdUser == null) ? "" : IdUser;
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmUsuarioDatos.IdUser = Convert.ToString(dr["IdUser"]);
                    itmUsuarioDatos.DNI = Convert.ToString(dr["DNI"]);
                    itmUsuarioDatos.Nickname = Convert.ToString(dr["Nickname"]);
                    itmUsuarioDatos.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmUsuarioDatos.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmUsuarioDatos.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmUsuarioDatos.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmUsuarioDatos.DesCaja = Convert.ToString(dr["DesCaja"]);
                    itmUsuarioDatos.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmUsuarioDatos;
        }
        public List<beUsuarioDatos> BuscaExistentes()
        {
            lisUsuarioDatos = new List<beUsuarioDatos>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_UsuarioDetalle_BuscaExistente", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmUsuarioDatos = new beUsuarioDatos();
                    itmUsuarioDatos.IdUser  = Convert.ToString(dr["IdUser"]);
                    itmUsuarioDatos.DNI = Convert.ToString(dr["DNI"]);
                    itmUsuarioDatos.Nickname = Convert.ToString(dr["Nickname"]);
                    itmUsuarioDatos.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmUsuarioDatos.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmUsuarioDatos.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmUsuarioDatos.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmUsuarioDatos.DesCaja = Convert.ToString(dr["DesCaja"]);
                    itmUsuarioDatos.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                    lisUsuarioDatos.Add(itmUsuarioDatos);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisUsuarioDatos;
        }
        public List<beUsuarioDatos> BuscaNuevos(string IdUser = "")
        {
            lisUsuarioDatos = new List<beUsuarioDatos>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_UsuarioDetalle_BuscaNuevo", conec);
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (IdUser == null) ? "" : IdUser;
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmUsuarioDatos = new beUsuarioDatos();
                    itmUsuarioDatos.IdUser = Convert.ToString(dr["IdUser"]);
                    itmUsuarioDatos.DNI = Convert.ToString(dr["DNI"]);
                    itmUsuarioDatos.Nickname = Convert.ToString(dr["Nickname"]);
                    itmUsuarioDatos.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmUsuarioDatos.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmUsuarioDatos.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmUsuarioDatos.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmUsuarioDatos.DesCaja = Convert.ToString(dr["DesCaja"]);
                    itmUsuarioDatos.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                    lisUsuarioDatos.Add(itmUsuarioDatos);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisUsuarioDatos;
        }
    }
}
