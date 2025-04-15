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
    public class daMatriculaUltima
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        beMatriculaUltima itmMatriculaUltima;
        public beMatriculaUltima PagoMaricula(string idPersona)
        {
            itmMatriculaUltima = new beMatriculaUltima();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.usp_MatriculaUltimo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdPersona", SqlDbType.VarChar, 20).Value = idPersona;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmMatriculaUltima.IdCliente = Convert.ToString(dr["IdCliente"]);
                    itmMatriculaUltima.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmMatriculaUltima.IdConceptoSede = Convert.ToInt16(dr["IdConceptoSede"]);
                    itmMatriculaUltima.IdConcepto = Convert.ToInt16(dr["IdConcepto"]);
                    itmMatriculaUltima.DesConcepto = Convert.ToString(dr["DesConcepto"]);
                    itmMatriculaUltima.Cantidad = Convert.ToInt16(dr["Cantidad"]);
                    itmMatriculaUltima.Importe = Convert.ToDecimal(dr["Importe"]);
                    itmMatriculaUltima.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    itmMatriculaUltima.MesesPasados = Convert.ToInt16(dr["MesesPasados"]);
                    itmMatriculaUltima.AnioPago = Convert.ToInt16(dr["AnioPago"]);
                    itmMatriculaUltima.AnioActual = Convert.ToInt16(dr["AnioActual"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmMatriculaUltima;
        }
    }
}
