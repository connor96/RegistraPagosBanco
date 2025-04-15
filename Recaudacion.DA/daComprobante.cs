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
    public class daComprobante
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        beComprobante itmComprobante;
        beReturn itmReturn;
        List<beComprobante> lisComprobante;
        public beReturn Insert(beComprobante myitmComprobante)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdCliente", SqlDbType.VarChar, 20).Value = (myitmComprobante.IdCliente == null) ? "" : myitmComprobante.IdCliente;
                cmm.Parameters.Add("@IdAlumnmo", SqlDbType.VarChar, 20).Value = (myitmComprobante.IdCliente == null) ? "" : myitmComprobante.IdCliente;
                cmm.Parameters.Add("@IdTipoComprobante", SqlDbType.TinyInt).Value = myitmComprobante.IdTipoComprobante;
                cmm.Parameters.Add("@DesLocal", SqlDbType.VarChar, 20).Value = (myitmComprobante.itmLocal.Local == null) ? "" : myitmComprobante.itmLocal.Local;
                cmm.Parameters.Add("@Serie", SqlDbType.VarChar, 5).Value = (myitmComprobante.Serie == null) ? "" : myitmComprobante.Serie;
                cmm.Parameters.Add("@Numero", SqlDbType.VarChar, 50).Value = (myitmComprobante.Numero == null) ? "" : myitmComprobante.Numero;
                cmm.Parameters.Add("@Importe", SqlDbType.Decimal).Value = myitmComprobante.Importe;
                cmm.Parameters.Add("@Dscto", SqlDbType.Decimal).Value = myitmComprobante.Dscto;
                cmm.Parameters.Add("@TotalPago", SqlDbType.Decimal).Value = myitmComprobante.TotalPago;
                cmm.Parameters.Add("@Periodo", SqlDbType.Date).Value = myitmComprobante.Periodo;
                cmm.Parameters.Add("@Fecha", SqlDbType.Date).Value = myitmComprobante.Fecha;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar, 20).Value = (myitmComprobante.TerminalRegistro == null) ? "" : myitmComprobante.TerminalRegistro;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (myitmComprobante.UserRegistro == null) ? "" : myitmComprobante.UserRegistro;
                cmm.Parameters.Add("@Tipo", SqlDbType.Bit).Value = myitmComprobante.IdTipoComprobante;
                cmm.Parameters.Add("@Local", SqlDbType.VarChar, 2).Value = (myitmComprobante.IdLocal.ToString() == null) ? "" : myitmComprobante.IdLocal.ToString();
                cmm.Parameters.Add("@Credito", SqlDbType.Bit).Value = myitmComprobante.Credito;
                SqlParameter IdComprobante = new SqlParameter();
                IdComprobante.ParameterName = "@IdComprobante";
                IdComprobante.SqlDbType = SqlDbType.Char;
                IdComprobante.Size = 10;
                IdComprobante.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(IdComprobante).Value = myitmComprobante.IdComprobante;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@IdComprobante"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }

        public int BuscarNroRecibo(int IdTipoComprobante, string Serie, string Numero)
        {
            int intReturn = 0;
            cmm = new SqlCommand("CobranzaWeb.wsp_Comprobante_Buscar", conec);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.Add("@IdTipoComprobante", SqlDbType.Int).Value = IdTipoComprobante;
            cmm.Parameters.Add("@Serie", SqlDbType.VarChar, 5).Value = Serie;
            cmm.Parameters.Add("@Numero", SqlDbType.VarChar, 50).Value = Numero;
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                intReturn = intReturn + 1;
            }
            conec.Close();
            return intReturn;
        }
    }
}
