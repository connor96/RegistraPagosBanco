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
    public class daTipoContacto
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beTipoContacto> lisTipoContacto;
        beTipoContacto itmTipoContacto;
        beReturn itmReturn;
        public List<beTipoContacto> Lista()
        {
            lisTipoContacto = new List<beTipoContacto>();
            try
            {
                cmm = new SqlCommand("Contacto.usp_TipoContacto_Get", conec);
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
                    itmTipoContacto = new beTipoContacto();
                    itmTipoContacto.IdTipoContacto = Convert.ToInt16(dr["IdTipoContacto"]);
                    itmTipoContacto.DesTipoContacto = Convert.ToString(dr["DesTipoContacto"]);
                    lisTipoContacto.Add(itmTipoContacto);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTipoContacto;
        }
    }
}
