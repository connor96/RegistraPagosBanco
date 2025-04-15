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
    public class daCECarrera
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beCECarrera itmCECarrera;
        List<beCECarrera> lisCECarrera;
        public List<beCECarrera> ListaPorCE(int IdCE)
        {
            lisCECarrera = new List<beCECarrera>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_CECarrerabyCE", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdCE", SqlDbType.NVarChar, 2).Value = IdCE;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCECarrera = new beCECarrera();
                    itmCECarrera.IdCE = Convert.ToInt16(dr["IdCE"]);
                    itmCECarrera.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCECarrera.IdCarrera = Convert.ToInt16(dr["IdCarrera"]);
                    itmCECarrera.DesCarrera = Convert.ToString(dr["DesCarrera"]);
                    lisCECarrera.Add(itmCECarrera);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCECarrera;
        }
    }
}
