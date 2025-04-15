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
    public class daTipoArchivo
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beTipoArchivo> lisTipoArchivo;
        beTipoArchivo itmTipoArchivo;
        beReturn itmReturn;
        public List<beTipoArchivo> ListaPorBanco(int intIdBanco)
        {
            lisTipoArchivo = new List<beTipoArchivo>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoArchivoByBanco", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = intIdBanco;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoArchivo = new beTipoArchivo();
                    itmTipoArchivo.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTipoArchivo.intIdBanco = Convert.ToInt32(dr["intIdBanco"]);
                    itmTipoArchivo.strTipoArchivo = Convert.ToString(dr["strTipoArchivo"]);
                    itmTipoArchivo.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                    itmTipoArchivo.strCaracter = Convert.ToString(dr["strCaracter"]);
                    lisTipoArchivo.Add(itmTipoArchivo);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTipoArchivo;
        }
        public beTipoArchivo Detalle(int intIdTipoArchivo)
        {
            itmTipoArchivo = new beTipoArchivo();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoArchivoById", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = intIdTipoArchivo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoArchivo.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTipoArchivo.intIdBanco = Convert.ToInt32(dr["intIdBanco"]);
                    itmTipoArchivo.strTipoArchivo = Convert.ToString(dr["strTipoArchivo"]);
                    itmTipoArchivo.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                    itmTipoArchivo.strCaracter = Convert.ToString(dr["strCaracter"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmTipoArchivo;
        }
        public beReturn Insert(beTipoArchivo myitmTipoArchivo)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoArchivoInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdTipoArchivo = new SqlParameter();
                intIdTipoArchivo.ParameterName = "@intIdTipoArchivo";
                intIdTipoArchivo.SqlDbType = SqlDbType.Int;
                intIdTipoArchivo.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdTipoArchivo).Value = myitmTipoArchivo.intIdTipoArchivo;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = myitmTipoArchivo.intIdBanco;
                cmm.Parameters.Add("@strTipoArchivo", SqlDbType.VarChar, 16).Value = (myitmTipoArchivo.strTipoArchivo == null) ? "" : myitmTipoArchivo.strTipoArchivo;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmTipoArchivo.bitActivo;
                cmm.Parameters.Add("@strCaracter", SqlDbType.VarChar, 1).Value = (myitmTipoArchivo.strCaracter == null) ? "" : myitmTipoArchivo.strCaracter;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdTipoArchivo"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Update(beTipoArchivo myitmTipoArchivo)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoArchivoUpdate", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmTipoArchivo.intIdTipoArchivo;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = myitmTipoArchivo.intIdBanco;
                cmm.Parameters.Add("@strTipoArchivo", SqlDbType.VarChar, 16).Value = (myitmTipoArchivo.strTipoArchivo == null) ? "" : myitmTipoArchivo.strTipoArchivo;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmTipoArchivo.bitActivo;
                cmm.Parameters.Add("@strCaracter", SqlDbType.VarChar, 1).Value = (myitmTipoArchivo.strCaracter == null) ? "" : myitmTipoArchivo.strCaracter;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmTipoArchivo.intIdTipoArchivo.ToString();
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
