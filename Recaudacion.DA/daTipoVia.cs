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
    public class daTipoVia
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beTipoVia itmTipoVia;
        List<beTipoVia> lisTipoVia;
        public beTipoVia Detalle(string IdTipoVia)
        {
            itmTipoVia = new beTipoVia();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_TipoVia_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = 0;
                cmm.Parameters.Add("@Opcion", SqlDbType.Char,2).Value = "Co";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = (IdTipoVia == null) ? "" : IdTipoVia;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoVia.IdTipoVia = Convert.ToInt16(dr["Codigo"]);
                    itmTipoVia.ResTipoVia = Convert.ToString(dr["Res"]);
                    itmTipoVia.DesTipoVia = Convert.ToString(dr["Descripción"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmTipoVia;
        }
        public List<beTipoVia> Lista()
        {
            lisTipoVia = new List<beTipoVia>();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_TipoVia_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = 0;
                cmm.Parameters.Add("@Opcion", SqlDbType.Char, 2).Value = "Co";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = "";
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoVia = new beTipoVia();
                    itmTipoVia.IdTipoVia = Convert.ToInt16(dr["Codigo"]);
                    itmTipoVia.ResTipoVia = Convert.ToString(dr["Res"]);
                    itmTipoVia.DesTipoVia = Convert.ToString(dr["Descripción"]);
                    lisTipoVia.Add(itmTipoVia);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTipoVia;
        }
    }
}
