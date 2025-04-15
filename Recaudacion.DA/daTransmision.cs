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
    public class daTransmision
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beTransmision> lisTransmision;
        beTransmision itmTransmision;
        beReturn itmReturn;
        public List<beTransmision> ListaPorFecha(DateTime dtmFecha)
        {
            lisTransmision = new List<beTransmision>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionByFecha", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@dtmFechaRegistro", SqlDbType.DateTime).Value = dtmFecha;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTransmision = new beTransmision();
                    itmTransmision.intIdTransmision = Convert.ToInt32(dr["intIdTransmision"]);
                    itmTransmision.intIdBancoDetalle = Convert.ToInt32(dr["intIdBancoDetalle"]);
                    itmTransmision.IdInstitucion = Convert.ToInt32(dr["IdInstitucion"]);
                    itmTransmision.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTransmision.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmTransmision.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                    itmTransmision.intTotalRegistros = Convert.ToInt32(dr["intTotalRegistros"]);
                    itmTransmision.dblMontoTotal = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmTransmision.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    lisTransmision.Add(itmTransmision);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTransmision;
        }
        public List<beTransmision> ListaPorFechas(DateTime dtmFechaInicio, DateTime dtmFechaFinal)
        {
            lisTransmision = new List<beTransmision>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionBuscarPorFechas", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@dtmFechaInicio", SqlDbType.Date).Value = dtmFechaInicio;
                cmm.Parameters.Add("@dtmFechaFinal", SqlDbType.Date).Value = dtmFechaFinal;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTransmision = new beTransmision();
                    itmTransmision.intIdTransmision = Convert.ToInt32(dr["intIdTransmision"]);
                    itmTransmision.intIdBancoDetalle = Convert.ToInt32(dr["intIdBancoDetalle"]);
                    itmTransmision.IdInstitucion = Convert.ToInt32(dr["IdInstitucion"]);
                    itmTransmision.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTransmision.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmTransmision.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                    itmTransmision.intTotalRegistros = Convert.ToInt32(dr["intTotalRegistros"]);
                    itmTransmision.dblMontoTotal = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmTransmision.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    lisTransmision.Add(itmTransmision);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTransmision;
        }
        public beTransmision Detalle(int intIdTransmision)
        {
            itmTransmision = new beTransmision();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionById", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTransmision", SqlDbType.Int).Value = intIdTransmision;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTransmision.intIdTransmision = Convert.ToInt32(dr["intIdTransmision"]);
                    itmTransmision.intIdBancoDetalle = Convert.ToInt32(dr["intIdBancoDetalle"]);
                    itmTransmision.IdInstitucion = Convert.ToInt32(dr["IdInstitucion"]);
                    itmTransmision.intIdTipoArchivo = Convert.ToInt32(dr["intIdTipoArchivo"]);
                    itmTransmision.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmTransmision.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                    itmTransmision.intTotalRegistros = Convert.ToInt32(dr["intTotalRegistros"]);
                    itmTransmision.dblMontoTotal = Convert.ToDecimal(dr["dblMontoTotal"]);
                    itmTransmision.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmTransmision;
        }
        public beReturn Insert(beTransmision myitmbeTransmision)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdTransmision = new SqlParameter();
                intIdTransmision.ParameterName = "@intIdTransmision";
                intIdTransmision.SqlDbType = SqlDbType.Int;
                intIdTransmision.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdTransmision).Value = myitmbeTransmision.intIdTransmision;
                cmm.Parameters.Add("@intIdBancoDetalle", SqlDbType.Int).Value = myitmbeTransmision.intIdBancoDetalle;
                cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = myitmbeTransmision.IdInstitucion;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmbeTransmision.intIdTipoArchivo;
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 20).Value = (myitmbeTransmision.UserRegistro == null) ? "" : myitmbeTransmision.UserRegistro;
                //cmm.Parameters.Add("@dtmFechaRegistro", SqlDbType.DateTime).Value = (myitmbeTransmision.dtmFechaRegistro == null) ? DateTime.Now : myitmbeTransmision.dtmFechaRegistro;
                cmm.Parameters.Add("@intTotalRegistros", SqlDbType.Int).Value = myitmbeTransmision.intTotalRegistros;
                cmm.Parameters.Add("@dblMontoTotal", SqlDbType.Decimal).Value = myitmbeTransmision.dblMontoTotal;
                cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 6).Value = (myitmbeTransmision.strCodigoServicio == null) ? "" : myitmbeTransmision.strCodigoServicio; ;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdTransmision"].Value.ToString();
                    itmReturn.strReturnValue = cmm.Parameters["@intIdTransmision"].Value.ToString();
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Generar(beTransmision myitmbeTransmision, int intIdTipoRegistro)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionInsert_Generar", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdTransmision = new SqlParameter();
                intIdTransmision.ParameterName = "@intIdTransmision";
                intIdTransmision.SqlDbType = SqlDbType.Int;
                intIdTransmision.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdTransmision).Value = myitmbeTransmision.intIdTransmision;
                cmm.Parameters.Add("@intIdBancoDetalle", SqlDbType.Int).Value = myitmbeTransmision.intIdBancoDetalle;
                cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = myitmbeTransmision.IdInstitucion;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmbeTransmision.intIdTipoArchivo;
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 20).Value = (myitmbeTransmision.UserRegistro == null) ? "" : myitmbeTransmision.UserRegistro;
                cmm.Parameters.Add("@dtmFechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                cmm.Parameters.Add("@intTotalRegistros", SqlDbType.Int).Value = myitmbeTransmision.intTotalRegistros;
                cmm.Parameters.Add("@dblMontoTotal", SqlDbType.Decimal).Value = myitmbeTransmision.dblMontoTotal;
                cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 6).Value = (myitmbeTransmision.strCodigoServicio==null)?"": myitmbeTransmision.strCodigoServicio;
                cmm.Parameters.Add("@intIdTipoRegistro", SqlDbType.Int).Value = intIdTipoRegistro;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = cmm.Parameters["@intIdTransmision"].Value.ToString();
                    //itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn InsertAutogenerago(beTransmision myitmbeTransmision)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionInsert_AutoGenerago", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdTransmision = new SqlParameter();
                intIdTransmision.ParameterName = "@intIdTransmision";
                intIdTransmision.SqlDbType = SqlDbType.Int;
                intIdTransmision.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdTransmision).Value = myitmbeTransmision.intIdTransmision;
                cmm.Parameters.Add("@intIdBancoDetalle", SqlDbType.Int).Value = myitmbeTransmision.intIdBancoDetalle;
                cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = myitmbeTransmision.IdInstitucion;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmbeTransmision.intIdTipoArchivo;
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 20).Value = (myitmbeTransmision.UserRegistro == null) ? "" : myitmbeTransmision.UserRegistro;
                cmm.Parameters.Add("@dtmFechaRegistro", SqlDbType.DateTime).Value = (myitmbeTransmision.dtmFechaRegistro == null) ? DateTime.Now : myitmbeTransmision.dtmFechaRegistro;
                cmm.Parameters.Add("@intTotalRegistros", SqlDbType.Int).Value = myitmbeTransmision.intTotalRegistros;
                cmm.Parameters.Add("@dblMontoTotal", SqlDbType.Decimal).Value = myitmbeTransmision.dblMontoTotal;
                cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 6).Value = myitmbeTransmision.strCodigoServicio;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["intIdTransmision"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Update(beTransmision myitmbeTransmision)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("intIdTransmision", SqlDbType.Int).Value = myitmbeTransmision.intIdTransmision;
                cmm.Parameters.Add("@intIdBancoDetalle", SqlDbType.Int).Value = myitmbeTransmision.intIdBancoDetalle;
                cmm.Parameters.Add("@IdInstitucion", SqlDbType.TinyInt).Value = myitmbeTransmision.IdInstitucion;
                cmm.Parameters.Add("@intIdTipoArchivo", SqlDbType.Int).Value = myitmbeTransmision.intIdTipoArchivo;
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 20).Value = (myitmbeTransmision.UserRegistro == null) ? "" : myitmbeTransmision.UserRegistro;
                cmm.Parameters.Add("@dtmFechaRegistro", SqlDbType.DateTime).Value = (myitmbeTransmision.dtmFechaRegistro == null) ? DateTime.Now : myitmbeTransmision.dtmFechaRegistro;
                cmm.Parameters.Add("@intTotalRegistros", SqlDbType.Int).Value = myitmbeTransmision.intTotalRegistros;
                cmm.Parameters.Add("@dblMontoTotal", SqlDbType.Decimal).Value = myitmbeTransmision.dblMontoTotal;
                cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 6).Value = myitmbeTransmision.strCodigoServicio;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmbeTransmision.intIdTransmision.ToString();
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
