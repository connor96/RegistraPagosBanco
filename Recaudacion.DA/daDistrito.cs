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
    public class daDistrito
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beDistrito itmDistrito;
        List<beDistrito> lisDistrito;

        public beDistrito Detalle(string CodUbigeo)
        {
            itmDistrito = new beDistrito();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Ubigeo_Detalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@CodUbigeo", SqlDbType.Char,6).Value = (CodUbigeo == null) ? "" : CodUbigeo;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmDistrito.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmDistrito.CodDepartamento = Convert.ToString(dr["CodDepartamento"]);
                    itmDistrito.CodProvincia = Convert.ToString(dr["CodProvincia"]);
                    itmDistrito.CodDistrito = Convert.ToString(dr["CodDistrito"]);
                    itmDistrito.DesDistrito = Convert.ToString(dr["DesDistrito"]);
                    itmDistrito.itmProvincia = new beProvincia();
                    itmDistrito.itmProvincia.CodDepartamento = Convert.ToString(dr["CodDepartamento"]);
                    itmDistrito.itmProvincia.CodProvincia = Convert.ToString(dr["CodProvincia"]);
                    itmDistrito.itmProvincia.DesProvincia = Convert.ToString(dr["DesProvincia"]);
                    itmDistrito.itmProvincia.itmDepartamento = new beDepartamento();
                    itmDistrito.itmProvincia.itmDepartamento.CodDepartamento = Convert.ToString(dr["CodDepartamento"]);
                    itmDistrito.itmProvincia.itmDepartamento.DesDepartamento = Convert.ToString(dr["DesDepartamento"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmDistrito;
        }
        public List<beDistrito> ListaPorProvincia(string CodDepartamento, string CodProvincia)
        {
            lisDistrito = new List<beDistrito>();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_Distrito_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@CodDepartamento", SqlDbType.NVarChar, 2).Value = (CodDepartamento == null) ? "" : CodDepartamento;
                cmm.Parameters.Add("@CodProvincia", SqlDbType.NVarChar, 2).Value = (CodProvincia == null) ? "" : CodProvincia; ;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmDistrito = new beDistrito();
                    itmDistrito.CodUbigeo = Convert.ToString(dr["CodUbigeo"]);
                    itmDistrito.DesDistrito = Convert.ToString(dr["DesDistrito"]);
                    lisDistrito.Add(itmDistrito);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisDistrito;
        }
    }
}
