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
    public class daActivacion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        List<beActivacion> LisActivacion;
        beActivacion itmActivacion;
        beReturn itmReturn;
        public beActivacion Detalle(int id)
        {
            itmActivacion = new beActivacion();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Activacion_Detalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdActivacion", SqlDbType.Int).Value = id;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmActivacion.intIdActivacion = Convert.ToInt16(dr["intIdActivacion"]);
                    itmActivacion.dtmInicio = Convert.ToDateTime(dr["dtmInicio"]);
                    itmActivacion.dtmFinal = Convert.ToDateTime(dr["dtmFinal"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmActivacion;
        }
        public List<beActivacion> Activos()
        {
            LisActivacion = new List<beActivacion>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ActivacionLista", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmActivacion = new beActivacion();
                    itmActivacion.intIdActivacion = Convert.ToInt16(dr["intIdActivacion"]);
                    itmActivacion.dtmInicio = Convert.ToDateTime(dr["dtmInicio"]);
                    itmActivacion.dtmFinal = Convert.ToDateTime(dr["dtmFinal"]);
                    LisActivacion.Add(itmActivacion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return LisActivacion;
        }
        public int ActivosInt()
        {
            int ReturnValue = 0;
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Activacion", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    ReturnValue += 1;
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ReturnValue;
        }
        public beReturn Insert(beActivacion myitmActivacion)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Activacion_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdActivacion = new SqlParameter();
                intIdActivacion.ParameterName = "@intIdActivacion";
                intIdActivacion.SqlDbType = SqlDbType.Int;
                intIdActivacion.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdActivacion).Value = myitmActivacion.intIdActivacion;
                cmm.Parameters.Add("@dtmInicio", SqlDbType.DateTime).Value = myitmActivacion.dtmInicio;
                cmm.Parameters.Add("@dtmFinal", SqlDbType.DateTime).Value = myitmActivacion.dtmFinal;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                itmReturn.intIdReturn = cmm.ExecuteNonQuery();
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = cmm.Parameters["@intIdActivacion"].Value.ToString();
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Guardar_Ok);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
        public beReturn Delete(int intIdActivacion)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Activacion_Delete", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdActivacion", SqlDbType.Int).Value = intIdActivacion;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                itmReturn.intIdReturn = cmm.ExecuteNonQuery();
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturnValue = intIdActivacion.ToString();
                    itmReturn.strMensaje = beMensajes.Mensajes(enmListaErrores.Eliminar_Ok);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                itmReturn.intIdReturn = 0;
                itmReturn.strMensaje = ex.Message;
                //throw new Exception(ex.Message);
            }
            return itmReturn;
        }
    }
}
