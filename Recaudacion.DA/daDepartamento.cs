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
    public class daDepartamento
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beDepartamento itmDepartamento;
        List<beDepartamento> lisDepartamento;

        public List<beDepartamento> Lista()
        {
            lisDepartamento = new List<beDepartamento>();
            try
            {
                cmm = new SqlCommand("Ubigeo.usp_Departamento_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = 0;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmDepartamento = new beDepartamento();
                    itmDepartamento.CodDepartamento = Convert.ToString(dr["CodDepartamento"]);
                    itmDepartamento.DesDepartamento = Convert.ToString(dr["DesDepartamento"]);
                    lisDepartamento.Add(itmDepartamento);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisDepartamento;
        }
    }
}
