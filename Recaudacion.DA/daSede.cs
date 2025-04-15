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
    public class daSede
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beSede itmSede;
        List<beSede> lisSede;
        public List<beSede> ListaSede()
        {
            lisSede = new List<beSede>();
            try
            {
                cmm = new SqlCommand("[Instituciones].[usp_Sede_Get]", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = 1;
                cmm.Parameters.Add("@Opcion", SqlDbType.VarChar, 2).Value = "";
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = "";
                cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = 1;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmSede = new beSede();
                    itmSede.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmSede.Sede = Convert.ToString(dr["Sede"]);
                    //itmTipoDocumento.Estado = Convert.ToByte(dr["Estado"]);
                    lisSede.Add(itmSede);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisSede;
        }
    }
}
