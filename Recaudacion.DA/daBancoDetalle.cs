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
    public class daBancoDetalle
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beBancoDetalle> lisBancoDetalle;
        beBancoDetalle itmBancoDetalle;
        beReturn itmReturn;
        public List<beBancoDetalle> ListaPorBanco(int intIdBanco)
        {
            lisBancoDetalle = new List<beBancoDetalle>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoDetalleByBanco", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = intIdBanco;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmBancoDetalle = new beBancoDetalle();
                    itmBancoDetalle.intIdBancoDetalle = Convert.ToInt32(dr["intIdBancoDetalle"]);
                    itmBancoDetalle.intIdBanco = Convert.ToInt32(dr["intIdBanco"]);
                    itmBancoDetalle.strCuenta = Convert.ToString(dr["strCuenta"]);
                    //itmBancoDetalle.strNombreEmpresa = Convert.ToString(dr["strNombreEmpresa"]);
                    //itmBancoDetalle.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    //itmBancoDetalle.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    itmBancoDetalle.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                    lisBancoDetalle.Add(itmBancoDetalle);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisBancoDetalle;
        }
        public beBancoDetalle Detalle(int intIdBancoDetalle)
        {
            itmBancoDetalle = new beBancoDetalle();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoDetalleByid", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdBancoDetalle", SqlDbType.Int).Value = intIdBancoDetalle;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmBancoDetalle.intIdBancoDetalle = Convert.ToInt32(dr["intIdBancoDetalle"]);
                    itmBancoDetalle.intIdBanco = Convert.ToInt32(dr["intIdBanco"]);
                    itmBancoDetalle.strCuenta = Convert.ToString(dr["strCuenta"]);
                    //itmBancoDetalle.strNombreEmpresa = Convert.ToString(dr["strNombreEmpresa"]);
                    //itmBancoDetalle.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    //itmBancoDetalle.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    itmBancoDetalle.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmBancoDetalle;
        }
        public beReturn Insert(beBancoDetalle myitmbeBancoDetalle)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoDetalleInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdBanco = new SqlParameter();
                intIdBanco.ParameterName = "@intIdBancoDetalle";
                intIdBanco.SqlDbType = SqlDbType.Int;
                intIdBanco.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdBanco).Value = myitmbeBancoDetalle.intIdBancoDetalle;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = myitmbeBancoDetalle.intIdBanco;
                cmm.Parameters.Add("@strCuenta", SqlDbType.VarChar,16).Value = (myitmbeBancoDetalle.strCuenta == null) ? "" : myitmbeBancoDetalle.strCuenta;
                //cmm.Parameters.Add("@strNombreEmpresa", SqlDbType.VarChar, 50).Value = (myitmbeBancoDetalle.strNombreEmpresa == null) ? "" : myitmbeBancoDetalle.strNombreEmpresa;
                //cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmbeBancoDetalle.intIdTipoArchivo;
                //cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 6).Value = (myitmbeBancoDetalle.strCodigoServicio == null) ? "" : myitmbeBancoDetalle.strCodigoServicio;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmbeBancoDetalle.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdBancoDetalle"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Update(beBancoDetalle myitmbeBancoDetalle)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoDetalleUpdate", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdBancoDetalle", SqlDbType.Int).Value = myitmbeBancoDetalle.intIdBancoDetalle;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = myitmbeBancoDetalle.intIdBanco;
                cmm.Parameters.Add("@strCuenta", SqlDbType.VarChar, 16).Value = (myitmbeBancoDetalle.strCuenta == null) ? "" : myitmbeBancoDetalle.strCuenta;
                //cmm.Parameters.Add("@strNombreEmpresa", SqlDbType.VarChar, 50).Value = (myitmbeBancoDetalle.strNombreEmpresa == null) ? "" : myitmbeBancoDetalle.strNombreEmpresa;
                //cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmbeBancoDetalle.intIdTipoArchivo;
                //cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 6).Value = (myitmbeBancoDetalle.strCodigoServicio == null) ? "" : myitmbeBancoDetalle.strCodigoServicio;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmbeBancoDetalle.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmbeBancoDetalle.intIdBancoDetalle.ToString();
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
