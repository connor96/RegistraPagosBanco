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
    public class daImpComprobanteDetalle
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        beImpComprobanteDetalle itmImpComprobanteDetalle;
        List<beImpComprobanteDetalle> lisImpComprobanteDetalle;

        public List<beImpComprobanteDetalle> ListaPorComprobante(string IdComprobante)
        {
            lisImpComprobanteDetalle = new List<beImpComprobanteDetalle>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_ImpComprobanteDetalle_Comprobante", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmImpComprobanteDetalle = new beImpComprobanteDetalle();
                    itmImpComprobanteDetalle.IdComprobante = Convert.ToString(dr["IdComprobante"]);
                    itmImpComprobanteDetalle.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    itmImpComprobanteDetalle.DesConcepto = Convert.ToString(dr["DesConcepto"]);
                    itmImpComprobanteDetalle.DesGrupoConcepto = Convert.ToString(dr["DesGrupoConcepto"]);
                    itmImpComprobanteDetalle.DesNivelCurso = Convert.ToString(dr["DesNivelCurso"]);
                    itmImpComprobanteDetalle.Importe = Convert.ToDecimal(dr["Importe"]);
                    itmImpComprobanteDetalle.TipoItem = Convert.ToString(dr["TipoItem"]);
                    lisImpComprobanteDetalle.Add(itmImpComprobanteDetalle);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisImpComprobanteDetalle;
        }
        public DataTable DataTableListaPorComprobante(string IdComprobante)
        {
            dt = new DataTable("ComprobanteDetalle");
            try
            {
                da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobanteDetalle_Comprobante", conec);
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
        public DataTable DataTableListaPorRecepcion(int intIdRecepcion)
        {
            dt = new DataTable("ComprobanteDetalle");
            try
            {
                da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobanteDetalle_Recpcion", conec);
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
        //public DataSet DataSetListaPorComprobante(string IdComprobante)
        //{
        //    try
        //    {
        //        ds = new DataSet();
        //        da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobanteDetalle_Comprobante", conec);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = IdComprobante;
        //        if (conec.State == ConnectionState.Closed)
        //        {
        //            conec.Open();
        //        }
        //        da.Fill(ds, "DetalleComprobamte");
        //        conec.Close();
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        da.Dispose();
        //        ds.Dispose();
        //    }
        //}
        //public DataSet DataSetListaPorRecepcion(int intIdRecepcion)
        //{
        //    try
        //    {
        //        ds = new DataSet();
        //        da = new SqlDataAdapter("CobranzaWeb.wsp_ImpComprobanteDetalle_Recpcion", conec);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;
        //        if (conec.State == ConnectionState.Closed)
        //        {
        //            conec.Open();
        //        }
        //        da.Fill(ds, "DetalleComprobamte");
        //        conec.Close();
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        da.Dispose();
        //        ds.Dispose();
        //    }
        //}
    }
}
