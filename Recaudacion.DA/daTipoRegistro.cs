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
    public class daTipoRegistro
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beTipoRegistro> lisTipoRegistro;
        beTipoRegistro itmTipoRegistro;
        beReturn itmReturn;
        public List<beTipoRegistro> ListaPorTipoArchivo(int intIdTipoArchivo)
        {
            lisTipoRegistro = new List<beTipoRegistro>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoRegistroByTipoArchivo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = intIdTipoArchivo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoRegistro = new beTipoRegistro();
                    itmTipoRegistro.intIdTipoRegistro = Convert.ToInt32(dr["intIdTipoRegistro"]);
                    itmTipoRegistro.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTipoRegistro.strTipoRegistro = Convert.ToString(dr["strTipoRegistro"]);
                    itmTipoRegistro.strCaracter = Convert.ToString(dr["strCaracter"]);
                    lisTipoRegistro.Add(itmTipoRegistro);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTipoRegistro;
        }
        public beTipoRegistro Detalle(int intIdTipoRegistro)
        {
            itmTipoRegistro = new beTipoRegistro();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoRegistroById", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTipoRegistro", SqlDbType.Int).Value = intIdTipoRegistro;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoRegistro.intIdTipoRegistro = Convert.ToInt32(dr["intIdTipoRegistro"]);
                    itmTipoRegistro.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTipoRegistro.strTipoRegistro = Convert.ToString(dr["strTipoRegistro"]);
                    itmTipoRegistro.strCaracter = Convert.ToString(dr["strCaracter"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmTipoRegistro;
        }
        public beReturn Insert(beTipoRegistro myitmTipoRegistro)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoRegistroInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdTipoArchivo = new SqlParameter();
                intIdTipoArchivo.ParameterName = "@intIdTipoRegistro";
                intIdTipoArchivo.SqlDbType = SqlDbType.Int;
                intIdTipoArchivo.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdTipoArchivo).Value = myitmTipoRegistro.intIdTipoArchivo;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmTipoRegistro.intIdTipoArchivo;
                cmm.Parameters.Add("@strTipoRegistro", SqlDbType.VarChar, 16).Value = (myitmTipoRegistro.strTipoRegistro == null) ? "" : myitmTipoRegistro.strTipoRegistro;
                cmm.Parameters.Add("@strCaracter", SqlDbType.VarChar, 1).Value = (myitmTipoRegistro.strCaracter == null) ? "" : myitmTipoRegistro.strCaracter;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["intIdTipoRegistro"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Update(beTipoRegistro myitmTipoRegistro)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TipoRegistroUpdate", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTipoRegistro", SqlDbType.Int).Value = myitmTipoRegistro.intIdTipoRegistro;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmTipoRegistro.intIdTipoArchivo;
                cmm.Parameters.Add("@strTipoRegistro", SqlDbType.VarChar, 16).Value = (myitmTipoRegistro.strTipoRegistro == null) ? "" : myitmTipoRegistro.strTipoRegistro;
                cmm.Parameters.Add("@strCaracter", SqlDbType.VarChar, 1).Value = (myitmTipoRegistro.strCaracter == null) ? "" : myitmTipoRegistro.strCaracter;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmTipoRegistro.intIdTipoRegistro.ToString();
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
