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
    public class daImpComprobante
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        DataSet ds;
        DataTable dt;

        beImpComprobante itmImpComprobante;
        List<beImpComprobante> lisImpComprobante;

        public List<beImpComprobante> ListaPorRecepcion(int intIdRecepcion)
        {
            lisImpComprobante = new List<beImpComprobante>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ImpComprobante_Recepcion", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmImpComprobante = new beImpComprobante();
                    itmImpComprobante.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmImpComprobante.Serie = Convert.ToString(dr["Serie"]);
                    itmImpComprobante.Numero = Convert.ToString(dr["Numero"]);
                    itmImpComprobante.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    itmImpComprobante.Periodo = Convert.ToString(dr["Periodo"]);
                    itmImpComprobante.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmImpComprobante.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmImpComprobante.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmImpComprobante.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmImpComprobante.Sede = Convert.ToString(dr["Sede"]);
                    itmImpComprobante.Local = Convert.ToString(dr["Local"]);
                    itmImpComprobante.DesAula = Convert.ToString(dr["DesAula"]);
                    itmImpComprobante.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmImpComprobante.Inicio = Convert.ToString(dr["Inicio"]);
                    itmImpComprobante.Final = Convert.ToString(dr["Final"]);
                    itmImpComprobante.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmImpComprobante.Dscto = Convert.ToDecimal(dr["Dscto"]);
                    itmImpComprobante.TotalPago = Convert.ToDecimal(dr["TotalPago"]);
                    itmImpComprobante.DesCaja = Convert.ToString(dr["DesCaja"]);
                    itmImpComprobante.Nickname = Convert.ToString(dr["Nickname"]);
                    itmImpComprobante.condicion = Convert.ToString(dr["condicion"]);
                    lisImpComprobante.Add(itmImpComprobante);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisImpComprobante;
        }
        public List<beImpComprobante> ListaPorFechas(DateTime dtmFechaInicio, DateTime dtmFechaFinal)
        {
            lisImpComprobante = new List<beImpComprobante>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ImpComprobanteBuscarPorFechas", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@dtmFechaInicio", SqlDbType.DateTime).Value = dtmFechaInicio;
                cmm.Parameters.Add("@dtmFechaFinal", SqlDbType.DateTime).Value = dtmFechaFinal;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmImpComprobante = new beImpComprobante();
                    itmImpComprobante.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmImpComprobante.Serie = Convert.ToString(dr["Serie"]);
                    itmImpComprobante.Numero = Convert.ToString(dr["Numero"]);
                    itmImpComprobante.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    itmImpComprobante.Periodo = Convert.ToString(dr["Periodo"]);
                    itmImpComprobante.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmImpComprobante.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmImpComprobante.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmImpComprobante.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmImpComprobante.Sede = Convert.ToString(dr["Sede"]);
                    itmImpComprobante.Local = Convert.ToString(dr["Local"]);
                    itmImpComprobante.DesAula = Convert.ToString(dr["DesAula"]);
                    itmImpComprobante.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmImpComprobante.Inicio = Convert.ToString(dr["Inicio"]);
                    itmImpComprobante.Final = Convert.ToString(dr["Final"]);
                    itmImpComprobante.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmImpComprobante.Dscto = Convert.ToDecimal(dr["Dscto"]);
                    itmImpComprobante.TotalPago = Convert.ToDecimal(dr["TotalPago"]);
                    itmImpComprobante.DesCaja = Convert.ToString(dr["DesCaja"]);
                    itmImpComprobante.Nickname = Convert.ToString(dr["Nickname"]);
                    itmImpComprobante.condicion = Convert.ToString(dr["condicion"]);
                    lisImpComprobante.Add(itmImpComprobante);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisImpComprobante;
        }
        public beImpComprobante Detalle(string IdComprobante)
        {
            itmImpComprobante = new beImpComprobante();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ImpComprobante_Detalle", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmImpComprobante.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmImpComprobante.Serie = Convert.ToString(dr["Serie"]);
                    itmImpComprobante.Numero = Convert.ToString(dr["Numero"]);
                    itmImpComprobante.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    itmImpComprobante.Periodo = Convert.ToString(dr["Periodo"]);
                    itmImpComprobante.Nombres1 = Convert.ToString(dr["Nombres1"]);
                    itmImpComprobante.Nombres2 = Convert.ToString(dr["Nombres2"]);
                    itmImpComprobante.ApellidoPaterno = Convert.ToString(dr["ApellidoPaterno"]);
                    itmImpComprobante.ApellidoMaterno = Convert.ToString(dr["ApellidoMaterno"]);
                    itmImpComprobante.Sede = Convert.ToString(dr["Sede"]);
                    itmImpComprobante.Local = Convert.ToString(dr["Local"]);
                    itmImpComprobante.DesAula = Convert.ToString(dr["DesAula"]);
                    itmImpComprobante.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmImpComprobante.Inicio = Convert.ToString(dr["Inicio"]);
                    itmImpComprobante.Final = Convert.ToString(dr["Final"]);
                    itmImpComprobante.CodCurso = Convert.ToString(dr["CodCurso"]);
                    itmImpComprobante.Dscto = Convert.ToDecimal(dr["Dscto"]);
                    itmImpComprobante.TotalPago = Convert.ToDecimal(dr["TotalPago"]);
                    itmImpComprobante.DesCaja = Convert.ToString(dr["DesCaja"]);
                    itmImpComprobante.Nickname = Convert.ToString(dr["Nickname"]);
                    itmImpComprobante.condicion = Convert.ToString(dr["condicion"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmImpComprobante;
        }

        public DataSet DataSetPorRecepcion(int intIdRecepcion)
        {
            ds = new DataSet("DatosComprobante");
            try
            {
                da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobante_Recepcion", conec);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;

                da2 = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobanteDetalle_Recpcion", conec);
                da2.SelectCommand.CommandType = CommandType.StoredProcedure;
                da2.SelectCommand.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                //da.FillSchema(ds, SchemaType.Source, "Comprobante");
                da.Fill(ds, "Comprobante");
                //da2.FillSchema(ds, SchemaType.Source, "ComprobanteDetalle");
                da2.Fill(ds, "DetalleComprobamte");
                conec.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //finally
            //{
            //    da.Dispose();
            //    ds.Dispose();
            //}
        }
        public DataSet DataSetDetalle(string IdComprobante)
        {
            ds = new DataSet("DatosComprobante");
            try
            {
                da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobante_Detalle", conec);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;
                da2 = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobanteDetalle_Comprobante", conec);
                da2.SelectCommand.CommandType = CommandType.StoredProcedure;
                da2.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;

                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                //da.FillSchema(ds,SchemaType.Source, "Comprobante");
                da.Fill(ds, "Comprobante");
                //da2.FillSchema(ds, SchemaType.Source, "ComprobanteDetalle");
                da2.Fill(ds, "DetalleComprobamte");
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //finally
            //{
            //    da.Dispose();
            //    ds.Dispose();
            //}
            return ds;
        }
        public DataTable DataTablePorRecepcion(int intIdRecepcion)
        {
            dt = new DataTable("Comprobante");
            try
            {
                da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobante_Recepcion", conec);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                da.Fill(dt);
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //finally
            //{
            //    da.Dispose();
            //    dt.Dispose();
            //}
            return dt;
        }
        public DataTable DataTableDetalle(string IdComprobante)
        {
            dt = new DataTable("Comprobante");
            try
            {
                da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobante_Detalle", conec);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                da.Fill(dt);
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //finally
            //{
            //    da.Dispose();
            //    dt.Dispose();
            //}
            return dt;
        }

    }
}
