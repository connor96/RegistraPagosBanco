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
    public class daProvincia
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beProvincia itmProvincia;
        List<beProvincia> lisProvincia;

        public List<beProvincia> ListaPorDepartamento(string CodDepartamento)
        {
            lisProvincia = new List<beProvincia>();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_Provincia_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@CodDepartamento", SqlDbType.NVarChar, 2).Value = (CodDepartamento == null) ? "" : CodDepartamento;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmProvincia = new beProvincia();
                    itmProvincia.CodProvincia = Convert.ToString(dr["CodProvincia"]);
                    itmProvincia.DesProvincia = Convert.ToString(dr["DesProvincia"]);
                    lisProvincia.Add(itmProvincia);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisProvincia;
        }
    }
}
