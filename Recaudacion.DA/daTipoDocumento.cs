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
    public class daTipoDocumento
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beTipoDocumento itmTipoDocumento;
        List<beTipoDocumento> lisTipoDocumento;

        public List<beTipoDocumento> ListaTipoDocumento()
        {
            lisTipoDocumento = new List<beTipoDocumento>();
            try
            {
                cmm = new SqlCommand("Persona.usp_TipoDocumento_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = 1;
                cmm.Parameters.Add("@Opcion", SqlDbType.VarChar, 2).Value = "";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = "";
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTipoDocumento = new beTipoDocumento();
                    itmTipoDocumento.IdTipoDocumento = Convert.ToByte(dr["IdTipoDocumento"]);
                    itmTipoDocumento.DesTipoDocumento = Convert.ToString(dr["DesTipoDocumento"]);
                    //itmTipoDocumento.Estado = Convert.ToByte(dr["Estado"]);
                    lisTipoDocumento.Add(itmTipoDocumento);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTipoDocumento;
        }
    }
}
