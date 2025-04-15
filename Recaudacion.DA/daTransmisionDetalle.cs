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
    public class daTransmisionDetalle
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beTransmisionDetalle> lisTransmisionDetalle;
        beTransmisionDetalle itmTransmisionDetalle;
        beReturn itmReturn;
        public List<beTransmisionDetalle> ListaPorTransmision(int intIdTransmision)
        {
            lisTransmisionDetalle = new List<beTransmisionDetalle>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionDetalleByTransmision", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTransmision", SqlDbType.Int).Value = intIdTransmision;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTransmisionDetalle = new beTransmisionDetalle();
                    itmTransmisionDetalle.intIdTransmisionDetalle = Convert.ToInt32(dr["intIdTransmisionDetalle"]);
                    itmTransmisionDetalle.intIdTransmision = Convert.ToInt32(dr["intIdTransmision"]);
                    itmTransmisionDetalle.IdPreMatricula = Guid.Parse(Convert.ToString(dr["IdPreMatricula"]));
                    itmTransmisionDetalle.dtmFechaEmision = Convert.ToDateTime(dr["dtmFechaEmision"]);
                    itmTransmisionDetalle.dtmFechaVencimiento = Convert.ToDateTime(dr["dtmFechaVencimiento"]);
                    itmTransmisionDetalle.dblMonto = Convert.ToDecimal(dr["dblMonto"]);
                    itmTransmisionDetalle.dblMora = Convert.ToDecimal(dr["dblMora"]);
                    itmTransmisionDetalle.dblMinimo = Convert.ToDecimal(dr["dblMinimo"]);
                    itmTransmisionDetalle.intTipoRegistro = Convert.ToInt32(dr["intTipoRegistro"]);
                    lisTransmisionDetalle.Add(itmTransmisionDetalle);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisTransmisionDetalle;
        }
        public beTransmisionDetalle Detalle(int intIdTransmisionDetalle)
        {
            itmTransmisionDetalle = new beTransmisionDetalle();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionDetalleById", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTransmisionDetalle", SqlDbType.Int).Value = intIdTransmisionDetalle;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmTransmisionDetalle.intIdTransmisionDetalle = Convert.ToInt32(dr["intIdBanco"]);
                    itmTransmisionDetalle.intIdTransmision = Convert.ToInt32(dr["strNombre"]);
                    itmTransmisionDetalle.IdPreMatricula = Guid.Parse(Convert.ToString(dr["strNombreCorto"]));
                    itmTransmisionDetalle.dtmFechaEmision = Convert.ToDateTime(dr["bitActivo"]);
                    itmTransmisionDetalle.dtmFechaVencimiento = Convert.ToDateTime(dr["intIdBanco"]);
                    itmTransmisionDetalle.dblMonto = Convert.ToDecimal(dr["strNombre"]);
                    itmTransmisionDetalle.dblMora = Convert.ToDecimal(dr["strNombreCorto"]);
                    itmTransmisionDetalle.dblMinimo = Convert.ToDecimal(dr["bitActivo"]);
                    itmTransmisionDetalle.intTipoRegistro = Convert.ToInt32(dr["intIdBanco"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmTransmisionDetalle;
        }
        public beReturn Insert(beTransmisionDetalle myitmTransmisionDetalle)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_TransmisionDetalleInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdTransmisionDetalle = new SqlParameter();
                intIdTransmisionDetalle.ParameterName = "@intIdTransmisionDetalle";
                intIdTransmisionDetalle.SqlDbType = SqlDbType.Int;
                intIdTransmisionDetalle.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdTransmisionDetalle).Value = myitmTransmisionDetalle.intIdTransmisionDetalle;
                cmm.Parameters.Add("@intIdTransmision", SqlDbType.Int).Value = myitmTransmisionDetalle.intIdTransmision;
                cmm.Parameters.Add("@IdPreMatricula", SqlDbType.UniqueIdentifier).Value = (myitmTransmisionDetalle.IdPreMatricula == null) ? Guid.NewGuid() : myitmTransmisionDetalle.IdPreMatricula;
                cmm.Parameters.Add("@dtmFechaEmision", SqlDbType.Date).Value = (myitmTransmisionDetalle.dtmFechaEmision == null) ? DateTime.Now : myitmTransmisionDetalle.dtmFechaEmision; ;
                cmm.Parameters.Add("@dtmFechaVencimiento", SqlDbType.Date).Value = (myitmTransmisionDetalle.dtmFechaVencimiento == null) ? DateTime.Now : myitmTransmisionDetalle.dtmFechaVencimiento;
                cmm.Parameters.Add("@dblMonto", SqlDbType.Decimal).Value = myitmTransmisionDetalle.dblMonto;
                cmm.Parameters.Add("@dblMora", SqlDbType.Decimal).Value = myitmTransmisionDetalle.dblMora;
                cmm.Parameters.Add("@dblMinimo", SqlDbType.Decimal).Value = myitmTransmisionDetalle.dblMinimo;
                cmm.Parameters.Add("@intTipoRegistro", SqlDbType.Int).Value = myitmTransmisionDetalle.intTipoRegistro;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdTransmisionDetalle"].Value.ToString();
                    itmReturn.strReturnValue = cmm.Parameters["@intIdTransmisionDetalle"].Value.ToString();
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
        public beReturn InsertUpdate(beTransmisionDetalle myitmTransmisionDetalle)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoUpdate", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdTransmisionDetalle", SqlDbType.Int).Value = myitmTransmisionDetalle.intIdTransmisionDetalle;
                cmm.Parameters.Add("@intIdTransmision", SqlDbType.Int).Value = myitmTransmisionDetalle.intIdTransmision;
                cmm.Parameters.Add("@IdPreMatricula", SqlDbType.UniqueIdentifier).Value = (myitmTransmisionDetalle.IdPreMatricula == null) ? Guid.NewGuid() : myitmTransmisionDetalle.IdPreMatricula;
                cmm.Parameters.Add("@dtmFechaEmision", SqlDbType.Date).Value = (myitmTransmisionDetalle.dtmFechaEmision == null) ? DateTime.Now : myitmTransmisionDetalle.dtmFechaEmision; ;
                cmm.Parameters.Add("@dtmFechaVencimiento", SqlDbType.Date).Value = (myitmTransmisionDetalle.dtmFechaVencimiento == null) ? DateTime.Now : myitmTransmisionDetalle.dtmFechaVencimiento;
                cmm.Parameters.Add("@dblMonto", SqlDbType.Decimal).Value = myitmTransmisionDetalle.dblMonto;
                cmm.Parameters.Add("@dblMora", SqlDbType.Decimal).Value = myitmTransmisionDetalle.dblMora;
                cmm.Parameters.Add("@dblMinimo", SqlDbType.Decimal).Value = myitmTransmisionDetalle.dblMinimo;
                cmm.Parameters.Add("@intTipoRegistro", SqlDbType.Int).Value = myitmTransmisionDetalle.intTipoRegistro;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = myitmTransmisionDetalle.intIdTransmisionDetalle.ToString();
                    itmReturn.strReturnValue = myitmTransmisionDetalle.intIdTransmisionDetalle.ToString();
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
    }
}
