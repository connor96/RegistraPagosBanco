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
    public class daUsuario
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        beUsuario itmUsuario;
        beReturn itmReturn;

        public beUsuario Detalle(string IdUser)
        {
            itmUsuario = new beUsuario();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Usuario_Detalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (IdUser == null) ? "" : IdUser;
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmUsuario.IdUser = Convert.ToString(dr["IdUser"]);
                    itmUsuario.strClave = Convert.ToString(dr["strClave"]);
                    itmUsuario.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmUsuario;
        }
        public beReturn Insert(beUsuario myitmUsuario)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Usuario_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (myitmUsuario.IdUser == null) ? "" : myitmUsuario.IdUser;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmUsuario.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmUsuario.IdUser;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Inactivar(string IdUser)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Usuario_Inactiva", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (IdUser == null) ? "" : IdUser;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = IdUser;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn RestaurarClave(string IdUser)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("wsp_Usuario_RestaurarClave", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (IdUser == null) ? "" : IdUser;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = IdUser;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn CambiarClave(string IdUser, string Clave)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("wsp_Usuario_CambiarClave", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = (IdUser == null) ? "" : IdUser;
                cmm.Parameters.Add("@strClave", SqlDbType.VarChar, 50).Value = (Clave == null) ? "" : Clave;
                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = IdUser;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
    }
}
