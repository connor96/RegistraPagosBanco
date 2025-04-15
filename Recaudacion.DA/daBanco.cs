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
    public class daBanco
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beBanco> lisBanco;
        beBanco itmBanco;
        beReturn itmReturn;
        public List<beBanco> Lista()
        {
            lisBanco = new List<beBanco>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoLista", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmBanco = new beBanco();
                    itmBanco.intIdBanco = Convert.ToInt32(dr["intIdBanco"]);
                    itmBanco.strNombre = Convert.ToString(dr["strNombre"]);
                    itmBanco.strNombreCorto = Convert.ToString(dr["strNombreCorto"]);
                    itmBanco.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                    lisBanco.Add(itmBanco);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisBanco;
        }
        public beBanco Detalle(int intIdBanco)
        {
            itmBanco = new beBanco();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoById", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = intIdBanco;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmBanco.intIdBanco = Convert.ToInt32(dr["intIdBanco"]);
                    itmBanco.strNombre = Convert.ToString(dr["strNombre"]);
                    itmBanco.strNombreCorto = Convert.ToString(dr["strNombreCorto"]);
                    itmBanco.bitActivo = Convert.ToBoolean(dr["bitActivo"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmBanco;
        }
        public beReturn Insert(beBanco myitmBanco)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdBanco = new SqlParameter();
                intIdBanco.ParameterName = "@intIdBanco";
                intIdBanco.SqlDbType = SqlDbType.Int;
                intIdBanco.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdBanco).Value = myitmBanco.intIdBanco;
                cmm.Parameters.Add("@strNombre", SqlDbType.VarChar, 50).Value = (myitmBanco.strNombre == null) ? "" : myitmBanco.strNombre;
                cmm.Parameters.Add("@strNombreCorto", SqlDbType.VarChar, 50).Value = (myitmBanco.strNombreCorto == null) ? "" : myitmBanco.strNombreCorto;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmBanco.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdBanco"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Update(beBanco myitmBanco)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoUpdate", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdBanco", SqlDbType.Int).Value = myitmBanco.intIdBanco;
                cmm.Parameters.Add("@strNombre", SqlDbType.VarChar, 50).Value = (myitmBanco.strNombre == null) ? "" : myitmBanco.strNombre;
                cmm.Parameters.Add("@strNombreCorto", SqlDbType.VarChar, 50).Value = (myitmBanco.strNombreCorto == null) ? "" : myitmBanco.strNombreCorto;
                cmm.Parameters.Add("@bitActivo", SqlDbType.Bit).Value = myitmBanco.bitActivo;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmBanco.intIdBanco.ToString();
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
