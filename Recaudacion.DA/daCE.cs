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
    public class daCE
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beCE itmCE;
        List<beCE> lisCE;
        public List<beCE> ListaPorOcupacion(int IdOcupacion)
        {
            lisCE = new List<beCE>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_CEbyOcupacion", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdOcupacion", SqlDbType.SmallInt).Value = IdOcupacion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmCE = new beCE();
                    itmCE.IdCE = Convert.ToInt16(dr["IdCE"]);
                    itmCE.IdSede = Convert.ToByte(dr["IdSede"]);
                    itmCE.IdOcupacion = Convert.ToInt16(dr["IdOcupacion"]);
                    itmCE.NivelCE = Convert.ToString(dr["NivelCE"]);
                    itmCE.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmCE.NombreCE = Convert.ToString(dr["NombreCE"]);
                    itmCE.Resumen = Convert.ToString(dr["Resumen"]);
                    lisCE.Add(itmCE);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisCE;
        }
    }
}
