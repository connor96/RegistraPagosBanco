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
    public class daInserComprobante
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        beInserComprobante itmInserComprobante;
        beReturn itmReturn;
        beNroComprobante itmNroComprobante;
        public beInserComprobante SearchByInsert(int intIdRecepcionDetalle, int IdTipoComprobante, string User, string terminal)
        {
            itmInserComprobante = new beInserComprobante();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Comprobante_ParaNuevo", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcionDetalle", SqlDbType.Int).Value = intIdRecepcionDetalle;
                cmm.Parameters.Add("@IdTipoComprobante", SqlDbType.TinyInt).Value = IdTipoComprobante;
                cmm.Parameters.Add("@User", SqlDbType.VarChar,50).Value = User;
                cmm.Parameters.Add("@terminal", SqlDbType.VarChar,20).Value = terminal;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmInserComprobante.IdCliente = Convert.ToString(dr["IdCliente"]);
                    itmInserComprobante.IdAlumnmo = Convert.ToString(dr["IdAlumnmo"]);
                    itmInserComprobante.IdTipoComprobante = Convert.ToInt32(dr["IdTipoComprobante"]);
                    itmInserComprobante.DesLocal = Convert.ToString(dr["DesLocal"]);
                    itmInserComprobante.Serie = Convert.ToString(dr["Serie"]);
                    itmInserComprobante.Numero = Convert.ToString(dr["Numero"]);
                    itmInserComprobante.Importe = Convert.ToDecimal(dr["Importe"]);
                    itmInserComprobante.Dscto = Convert.ToDecimal(dr["Dscto"]);
                    itmInserComprobante.TotalPago = Convert.ToDecimal(dr["TotalPago"]);
                    itmInserComprobante.Periodo = Convert.ToDateTime(dr["Periodo"]);
                    itmInserComprobante.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    itmInserComprobante.Terminal = Convert.ToString(dr["Terminal"]);
                    itmInserComprobante.User = Convert.ToString(dr["User"]);
                    itmInserComprobante.Tipo = Convert.ToBoolean(dr["Tipo"]);
                    itmInserComprobante.Local = Convert.ToString(dr["Local"]);
                    itmInserComprobante.Credito = Convert.ToBoolean(dr["Credito"]);
                    itmInserComprobante.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmInserComprobante;
        }
        public beReturn Insert(beInserComprobante myitmInserComprobante)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("Caja.usp_Comprobante_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter IdComprobante = new SqlParameter();
                IdComprobante.ParameterName = "@IdComprobante";
                IdComprobante.SqlDbType = SqlDbType.Char;
                IdComprobante.Size = 10;
                IdComprobante.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(IdComprobante).Value = myitmInserComprobante.IdComprobante;
                cmm.Parameters.Add("@IdCliente", SqlDbType.VarChar, 20).Value = (myitmInserComprobante.IdCliente == null) ? "" : myitmInserComprobante.IdCliente;
                cmm.Parameters.Add("@IdAlumnmo", SqlDbType.VarChar, 20).Value = (myitmInserComprobante.IdAlumnmo == null) ? "" : myitmInserComprobante.IdAlumnmo;
                cmm.Parameters.Add("@IdTipoComprobante", SqlDbType.Int).Value = myitmInserComprobante.IdTipoComprobante;
                cmm.Parameters.Add("@DesLocal", SqlDbType.VarChar, 20).Value = (myitmInserComprobante.DesLocal == null) ? "" : myitmInserComprobante.DesLocal;
                cmm.Parameters.Add("@Serie", SqlDbType.VarChar, 5).Value = (myitmInserComprobante.Serie == null) ? "" : myitmInserComprobante.Serie;
                cmm.Parameters.Add("@Numero", SqlDbType.VarChar, 50).Value = (myitmInserComprobante.Numero == null) ? "" : myitmInserComprobante.Numero;
                cmm.Parameters.Add("@Importe", SqlDbType.Decimal).Value = myitmInserComprobante.Importe;
                cmm.Parameters.Add("@Dscto", SqlDbType.Decimal).Value = myitmInserComprobante.Dscto;
                cmm.Parameters.Add("@TotalPago", SqlDbType.Decimal).Value = myitmInserComprobante.TotalPago;
                cmm.Parameters.Add("@Periodo", SqlDbType.Date).Value = myitmInserComprobante.Periodo;
                cmm.Parameters.Add("@Fecha", SqlDbType.Date).Value = myitmInserComprobante.Fecha;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar, 20).Value = (myitmInserComprobante.Terminal == null) ? Environment.MachineName : myitmInserComprobante.Terminal;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (myitmInserComprobante.User == null) ? "0000000000" : myitmInserComprobante.User;
                cmm.Parameters.Add("@Local", SqlDbType.VarChar, 2).Value = (myitmInserComprobante.Local == null) ? "" : myitmInserComprobante.Local;
                cmm.Parameters.Add("@Tipo", SqlDbType.Bit).Value = myitmInserComprobante.Tipo;
                cmm.Parameters.Add("@Credito", SqlDbType.Bit).Value = myitmInserComprobante.Credito;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = cmm.Parameters["@IdComprobante"].Value.ToString();
                    itmReturn.strMensaje = "Felicitaciones, los datos se guardaron satisfactoriamente.";
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beNroComprobante ActualizaNumeracion(int Tipo, string Busqueda, string IdUser)
        {
            itmNroComprobante = new beNroComprobante();
            try
            {
                cmm = new SqlCommand("Caja.usp_Numeracion_Get", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = Tipo;
                cmm.Parameters.Add("@Busqueda", SqlDbType.VarChar, 100).Value = Busqueda;
                cmm.Parameters.Add("@IdUser", SqlDbType.VarChar, 20).Value = IdUser;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmNroComprobante.Serie = Convert.ToString(dr["Serie"]);
                    itmNroComprobante.Inicio = Convert.ToString(dr["Inicio"]);
                    itmNroComprobante.Final = Convert.ToString(dr["Final"]);
                    itmNroComprobante.LengtSerie = Convert.ToInt16(dr["LengtSerie"]);
                    itmNroComprobante.LengtNumero = Convert.ToInt16(dr["LengtNumero"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmNroComprobante;
        }
    }
}
