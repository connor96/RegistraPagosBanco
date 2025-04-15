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
    public class daTipoDireccion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beTipoDireccion itmTipoDireccion;
        List<beTipoDireccion> lisTipoDireccion;
        public beTipoDireccion Detalle(string IdTipoDireccion)
        {
            itmTipoDireccion = new beTipoDireccion();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_TipoDireccion_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = 0;
                cmm.Parameters.Add("@Opcion", SqlDbType.Char, 2).Value = "Co";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = (IdTipoDireccion == null) ? "" : IdTipoDireccion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoDireccion.IdTipoDireccion = Convert.ToInt16(dr["IdTipoDireccion"]);
                    itmTipoDireccion.DesTipoDireccion = Convert.ToString(dr["DesTipoDireccion"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmTipoDireccion;
        }
        public List<beTipoDireccion> Lista()
        {
            lisTipoDireccion = new List<beTipoDireccion>();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_TipoDireccion_Get", conec);
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
                    itmTipoDireccion = new beTipoDireccion();
                    itmTipoDireccion.IdTipoDireccion = Convert.ToInt16(dr["IdTipoDireccion"]);
                    itmTipoDireccion.DesTipoDireccion = Convert.ToString(dr["DesTipoDireccion"]);
                    lisTipoDireccion.Add(itmTipoDireccion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTipoDireccion;
        }
    }
}
