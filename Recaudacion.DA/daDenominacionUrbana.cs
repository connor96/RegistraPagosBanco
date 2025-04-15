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
    public class daDenominacionUrbana
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beDenominacionUrbana itmDenominacionUrbana;
        List<beDenominacionUrbana> lisDenominacionUrbana;
        public beDenominacionUrbana Detalle(string IdDenominacionUrbana)
        {
            itmDenominacionUrbana = new beDenominacionUrbana();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_DenominacionUrbana_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = 0;
                cmm.Parameters.Add("@Opcion", SqlDbType.Char, 2).Value = "Co";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = (IdDenominacionUrbana == null) ? "" : IdDenominacionUrbana;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmDenominacionUrbana.IdDenominacionUrbana = Convert.ToString(dr["IdDenominacionUrbana"]);
                    itmDenominacionUrbana.DesDenominacionUrbana = Convert.ToString(dr["DesDenominacionUrbana"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmDenominacionUrbana;
        }
        public List<beDenominacionUrbana> Lista(string DesDenominacionUrbana)
        {
            lisDenominacionUrbana = new List<beDenominacionUrbana>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_DenominacionUrbana_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = 0;
                cmm.Parameters.Add("@Opcion", SqlDbType.Char, 2).Value = "De";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = (DesDenominacionUrbana == null) ? "" : DesDenominacionUrbana;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmDenominacionUrbana = new beDenominacionUrbana();
                    itmDenominacionUrbana.IdDenominacionUrbana = Convert.ToString(dr["IdDenominacionUrbana"]);
                    itmDenominacionUrbana.DesDenominacionUrbana = Convert.ToString(dr["DesDenominacionUrbana"]);
                    lisDenominacionUrbana.Add(itmDenominacionUrbana);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisDenominacionUrbana;
        }
    }
}
