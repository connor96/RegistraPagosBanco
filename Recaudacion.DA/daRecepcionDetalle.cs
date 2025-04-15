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
    public class daRecepcionDetalle
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beRecepcionDetalle> lisRecepcionDetalle;
        beRecepcionDetalle itmRecepcionDetalle;
        beReturn itmReturn;

        public List<beRecepcionDetalle> ListaPorRegistro(int intIdRecepcion)
        {
            lisRecepcionDetalle = new List<beRecepcionDetalle>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionDetalleByRecepcion", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmRecepcionDetalle = new beRecepcionDetalle();
                    itmRecepcionDetalle.intIdRecepcionDetalle = Convert.ToInt32(dr["intIdRecepcionDetalle"]);
                    itmRecepcionDetalle.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcionDetalle.strCodigoDeposotante = Convert.ToString(dr["strCodigoDeposotante"]);
                    itmRecepcionDetalle.strDatoAdicional = Convert.ToString(dr["strDatoAdicional"]);
                    itmRecepcionDetalle.dtmFechaPago = Convert.ToDateTime(dr["dtmFechaPago"]);
                    itmRecepcionDetalle.dtmFechaVencimiento = Convert.ToDateTime(dr["dtmFechaVencimiento"]);
                    itmRecepcionDetalle.dblMonto = Convert.ToDecimal(dr["dblMonto"]);
                    itmRecepcionDetalle.dblMora = Convert.ToDecimal(dr["dblMora"]);
                    itmRecepcionDetalle.dblMontoTotal = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmRecepcionDetalle.strSucursal = Convert.ToString(dr["strSucursal"]);
                    itmRecepcionDetalle.strAgencia = Convert.ToString(dr["strAgencia"]);
                    itmRecepcionDetalle.strNroOperacion = Convert.ToString(dr["strNroOperacion"]);
                    itmRecepcionDetalle.strTerminal = Convert.ToString(dr["strTerminal"]);
                    itmRecepcionDetalle.strMedioAtencion = Convert.ToString(dr["strMedioAtencion"]);
                    itmRecepcionDetalle.strNroCheque = Convert.ToString(dr["strNroCheque"]);
                    itmRecepcionDetalle.strCodigoBanco = Convert.ToString(dr["strCodigoBanco"]);
                    itmRecepcionDetalle.strCargoFijo = Convert.ToString(dr["strCargoFijo"]);
                    itmRecepcionDetalle.strFlagExtorno = Convert.ToString(dr["strFlagExtorno"]);
                    itmRecepcionDetalle.strNroDocPago = Convert.ToString(dr["strNroDocPago"]);
                    itmRecepcionDetalle.strNroOperacionBD = Convert.ToString(dr["strNroOperacionBD"]);
                    itmRecepcionDetalle.strReferencia = Convert.ToString(dr["strReferencia"]);
                    itmRecepcionDetalle.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmRecepcionDetalle.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmRecepcionDetalle.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    lisRecepcionDetalle.Add(itmRecepcionDetalle);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisRecepcionDetalle;
        }
        public List<beRecepcionDetalle> ListaNulosPorRegistro(int intIdRecepcion)
        {
            lisRecepcionDetalle = new List<beRecepcionDetalle>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionDetalleNullByRecepcion", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmRecepcionDetalle = new beRecepcionDetalle();
                    itmRecepcionDetalle.intIdRecepcionDetalle = Convert.ToInt32(dr["intIdRecepcionDetalle"]);
                    itmRecepcionDetalle.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcionDetalle.strCodigoDeposotante = Convert.ToString(dr["strCodigoDeposotante"]);
                    itmRecepcionDetalle.strDatoAdicional = Convert.ToString(dr["strDatoAdicional"]);
                    itmRecepcionDetalle.dtmFechaPago = Convert.ToDateTime(dr["dtmFechaPago"]);
                    itmRecepcionDetalle.dtmFechaVencimiento = Convert.ToDateTime(dr["dtmFechaVencimiento"]);
                    itmRecepcionDetalle.dblMonto = Convert.ToDecimal(dr["dblMonto"]);
                    itmRecepcionDetalle.dblMora = Convert.ToDecimal(dr["dblMora"]);
                    itmRecepcionDetalle.dblMontoTotal = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmRecepcionDetalle.strSucursal = Convert.ToString(dr["strSucursal"]);
                    itmRecepcionDetalle.strAgencia = Convert.ToString(dr["strAgencia"]);
                    itmRecepcionDetalle.strNroOperacion = Convert.ToString(dr["strNroOperacion"]);
                    itmRecepcionDetalle.strTerminal = Convert.ToString(dr["strTerminal"]);
                    itmRecepcionDetalle.strMedioAtencion = Convert.ToString(dr["strMedioAtencion"]);
                    itmRecepcionDetalle.strNroCheque = Convert.ToString(dr["strNroCheque"]);
                    itmRecepcionDetalle.strCodigoBanco = Convert.ToString(dr["strCodigoBanco"]);
                    itmRecepcionDetalle.strCargoFijo = Convert.ToString(dr["strCargoFijo"]);
                    itmRecepcionDetalle.strFlagExtorno = Convert.ToString(dr["strFlagExtorno"]);
                    itmRecepcionDetalle.strNroDocPago = Convert.ToString(dr["strNroDocPago"]);
                    itmRecepcionDetalle.strNroOperacionBD = Convert.ToString(dr["strNroOperacionBD"]);
                    itmRecepcionDetalle.strReferencia = Convert.ToString(dr["strReferencia"]);
                    itmRecepcionDetalle.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmRecepcionDetalle.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmRecepcionDetalle.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    lisRecepcionDetalle.Add(itmRecepcionDetalle);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisRecepcionDetalle;
        }
        public beRecepcionDetalle Detalle(int intIdRecepcionDetalle)
        {
            itmRecepcionDetalle = new beRecepcionDetalle();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionByID", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcionDetalle", SqlDbType.Int).Value = intIdRecepcionDetalle;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmRecepcionDetalle.intIdRecepcionDetalle = Convert.ToInt32(dr["intIdRecepcionDetalle"]);
                    itmRecepcionDetalle.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcionDetalle.strCodigoDeposotante = Convert.ToString(dr["strCodigoDeposotante"]);
                    itmRecepcionDetalle.strDatoAdicional = Convert.ToString(dr["strDatoAdicional"]);
                    itmRecepcionDetalle.dtmFechaPago = Convert.ToDateTime(dr["dtmFechaPago"]);
                    itmRecepcionDetalle.dtmFechaVencimiento = Convert.ToDateTime(dr["dtmFechaVencimiento"]);
                    itmRecepcionDetalle.dblMonto = Convert.ToDecimal(dr["dblMonto"]);
                    itmRecepcionDetalle.dblMora = Convert.ToDecimal(dr["dblMora"]);
                    itmRecepcionDetalle.dblMontoTotal = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmRecepcionDetalle.strSucursal = Convert.ToString(dr["strSucursal"]);
                    itmRecepcionDetalle.strAgencia = Convert.ToString(dr["strAgencia"]);
                    itmRecepcionDetalle.strNroOperacion = Convert.ToString(dr["strNroOperacion"]);
                    itmRecepcionDetalle.strTerminal = Convert.ToString(dr["strTerminal"]);
                    itmRecepcionDetalle.strMedioAtencion = Convert.ToString(dr["strMedioAtencion"]);
                    itmRecepcionDetalle.strNroCheque = Convert.ToString(dr["strNroCheque"]);
                    itmRecepcionDetalle.strCodigoBanco = Convert.ToString(dr["strCodigoBanco"]);
                    itmRecepcionDetalle.strCargoFijo = Convert.ToString(dr["strCargoFijo"]);
                    itmRecepcionDetalle.strFlagExtorno = Convert.ToString(dr["strFlagExtorno"]);
                    itmRecepcionDetalle.strNroDocPago = Convert.ToString(dr["strNroDocPago"]);
                    itmRecepcionDetalle.strNroOperacionBD = Convert.ToString(dr["strNroOperacionBD"]);
                    itmRecepcionDetalle.strReferencia = Convert.ToString(dr["strReferencia"]);
                    itmRecepcionDetalle.IdCiclo = Convert.ToString(dr["IdCiclo"]);
                    itmRecepcionDetalle.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmRecepcionDetalle;
        }
        public beReturn Insert(beRecepcionDetalle myitmRecepcionDetalle)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionDetalle_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdRecepcionDetalle = new SqlParameter();
                intIdRecepcionDetalle.ParameterName = "@intIdRecepcionDetalle";
                intIdRecepcionDetalle.SqlDbType = SqlDbType.Int;
                intIdRecepcionDetalle.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdRecepcionDetalle).Value = myitmRecepcionDetalle.intIdRecepcion;
                cmm.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = myitmRecepcionDetalle.intIdRecepcion;
                cmm.Parameters.Add("@strCodigoDeposotante", SqlDbType.VarChar, 20).Value = (myitmRecepcionDetalle.strCodigoDeposotante == null) ? "" : myitmRecepcionDetalle.strCodigoDeposotante;
                cmm.Parameters.Add("@strDatoAdicional", SqlDbType.VarChar, 30).Value = (myitmRecepcionDetalle.strDatoAdicional == null) ? "" : myitmRecepcionDetalle.strDatoAdicional;
                cmm.Parameters.Add("@dtmFechaPago", SqlDbType.Date).Value = myitmRecepcionDetalle.dtmFechaPago;
                cmm.Parameters.Add("@dtmFechaVencimiento", SqlDbType.Date).Value = myitmRecepcionDetalle.dtmFechaVencimiento;
                cmm.Parameters.Add("@dblMonto", SqlDbType.Decimal).Value = myitmRecepcionDetalle.dblMonto;
                cmm.Parameters.Add("@dblMora", SqlDbType.Decimal).Value = myitmRecepcionDetalle.dblMora;
                cmm.Parameters.Add("@dblMontoTotal", SqlDbType.Decimal).Value = myitmRecepcionDetalle.dblMontoTotal;
                cmm.Parameters.Add("@strSucursal", SqlDbType.VarChar, 10).Value = (myitmRecepcionDetalle.strSucursal == null) ? "" : myitmRecepcionDetalle.strSucursal;
                cmm.Parameters.Add("@strAgencia", SqlDbType.VarChar, 10).Value = (myitmRecepcionDetalle.strAgencia == null) ? "" : myitmRecepcionDetalle.strAgencia;
                cmm.Parameters.Add("@strNroOperacion", SqlDbType.VarChar, 30).Value = (myitmRecepcionDetalle.strNroOperacion == null) ? "" : myitmRecepcionDetalle.strNroOperacion;
                cmm.Parameters.Add("@strTerminal", SqlDbType.VarChar, 10).Value = (myitmRecepcionDetalle.strTerminal == null) ? "" : myitmRecepcionDetalle.strTerminal;
                cmm.Parameters.Add("@strMedioAtencion", SqlDbType.VarChar, 10).Value = (myitmRecepcionDetalle.strMedioAtencion == null) ? "" : myitmRecepcionDetalle.strMedioAtencion;
                cmm.Parameters.Add("@strNroCheque", SqlDbType.VarChar, 30).Value = (myitmRecepcionDetalle.strNroCheque == null) ? "" : myitmRecepcionDetalle.strNroCheque;
                cmm.Parameters.Add("@strCodigoBanco", SqlDbType.VarChar, 10).Value = (myitmRecepcionDetalle.strCodigoBanco == null) ? "" : myitmRecepcionDetalle.strCodigoBanco;
                cmm.Parameters.Add("@strCargoFijo", SqlDbType.VarChar, 20).Value = (myitmRecepcionDetalle.strCargoFijo == null) ? "" : myitmRecepcionDetalle.strCargoFijo;
                cmm.Parameters.Add("@strFlagExtorno", SqlDbType.VarChar, 20).Value = (myitmRecepcionDetalle.strFlagExtorno == null) ? "" : myitmRecepcionDetalle.strFlagExtorno;
                cmm.Parameters.Add("@strNroDocPago", SqlDbType.VarChar, 50).Value = (myitmRecepcionDetalle.strNroDocPago == null) ? "" : myitmRecepcionDetalle.strNroDocPago;
                cmm.Parameters.Add("@strNroOperacionBD", SqlDbType.VarChar, 20).Value = (myitmRecepcionDetalle.strNroOperacionBD == null) ? "" : myitmRecepcionDetalle.strNroOperacionBD;
                cmm.Parameters.Add("@strReferencia", SqlDbType.VarChar, 20).Value = (myitmRecepcionDetalle.strReferencia == null) ? "" : myitmRecepcionDetalle.strReferencia;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdRecepcionDetalle"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn UpdateComprobante(int intIdRecepcionDetalle, string IdComprobante)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionDetalle_Update_Comprobante", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcionDetalle", SqlDbType.Int).Value = intIdRecepcionDetalle;
                cmm.Parameters.Add("@IdComprobante", SqlDbType.Char, 11).Value = (IdComprobante == null) ? "" : IdComprobante;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = intIdRecepcionDetalle.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
    }
}
