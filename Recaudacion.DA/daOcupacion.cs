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
    public class daOcupacion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beOcupacion itmOcupacion;
        List<beOcupacion> lisOcupacion;

        public List<beOcupacion> Lista()
        {
            lisOcupacion = new List<beOcupacion>();
            try
            {
                cmm = new SqlCommand("Persona.usp_Ocupacion_Get", conec);
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
                    itmOcupacion = new beOcupacion();
                    itmOcupacion.IdOcupacion = Convert.ToInt16(dr["IdOcupacion"]);
                    itmOcupacion.DesOcupacion = Convert.ToString(dr["DesOcupacion"]);
                    lisOcupacion.Add(itmOcupacion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisOcupacion;
        }
    }
}
