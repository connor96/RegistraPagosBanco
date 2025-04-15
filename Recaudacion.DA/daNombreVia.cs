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
    public class daNombreVia
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beNombreVia itmNombreVia;
        List<beNombreVia> lisNombreVia;
        public beNombreVia Detalle(string IdNombreVia)
        {
            itmNombreVia = new beNombreVia();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_NombreVia_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = 4;
                cmm.Parameters.Add("@Opcion", SqlDbType.Char, 2).Value = "Co";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = (IdNombreVia == null) ? "" : IdNombreVia;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmNombreVia.IdNombreVia = Convert.ToString(dr["IdNombreVia"]);
                    itmNombreVia.DesNombreVia = Convert.ToString(dr["DesNombreVia"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmNombreVia;
        }
        public List<beNombreVia> Lista(string DesNombreVia)
        {
            lisNombreVia = new List<beNombreVia>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_NombreVia", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@DesNombreVia", SqlDbType.VarChar, 100).Value = (DesNombreVia == null) ? "" : DesNombreVia;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmNombreVia = new beNombreVia();
                    itmNombreVia.IdNombreVia = Convert.ToString(dr["IdNombreVia"]);
                    itmNombreVia.DesNombreVia = Convert.ToString(dr["DesNombreVia"]);
                    lisNombreVia.Add(itmNombreVia);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisNombreVia;
        }
    }
}
