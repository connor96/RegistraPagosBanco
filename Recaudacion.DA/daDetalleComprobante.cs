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
    public class daDetalleComprobante
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beDetalleComprobante> lisDetalleComprobante;
        beDetalleComprobante itmDetalleComprobante;
        beReturn itmReturn;

        public beReturn Insert(beDetalleComprobante myitmDetalleComprobante)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_BancoInsert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@TipoMatricula", SqlDbType.Bit).Value = myitmDetalleComprobante.TipoMatricula;
                cmm.Parameters.Add("@IdItem", SqlDbType.Int).Value = myitmDetalleComprobante.IdItem;
                cmm.Parameters.Add("@TipoItem", SqlDbType.Char, 1).Value = (myitmDetalleComprobante.TipoItem == null) ? "" : myitmDetalleComprobante.TipoItem;
                cmm.Parameters.Add("@IdGrupoConcepto", SqlDbType.SmallInt).Value = myitmDetalleComprobante.IdGrupoConcepto;
                cmm.Parameters.Add("@IdDescuentoSede", SqlDbType.SmallInt).Value = myitmDetalleComprobante.IdDescuentoSede;
                cmm.Parameters.Add("@Cantidad", SqlDbType.SmallInt).Value = myitmDetalleComprobante.Cantidad;
                cmm.Parameters.Add("@Importe", SqlDbType.Decimal).Value = myitmDetalleComprobante.Importe;
                cmm.Parameters.Add("@Dscto", SqlDbType.Decimal).Value = myitmDetalleComprobante.Dscto;
                cmm.Parameters.Add("@TotalPagar", SqlDbType.Decimal).Value = myitmDetalleComprobante.Total;
                cmm.Parameters.Add("@IdAlumno", SqlDbType.VarChar, 20).Value = (myitmDetalleComprobante.IdAlumno == null) ? "" : myitmDetalleComprobante.IdAlumno;
                cmm.Parameters.Add("@IdCiclo", SqlDbType.Char, 11).Value = (myitmDetalleComprobante.IdCiclo == null) ? "" : myitmDetalleComprobante.IdCiclo;
                cmm.Parameters.Add("@IdSituacionMatricula", SqlDbType.TinyInt).Value = myitmDetalleComprobante.IdSituacionMatricula;
                cmm.Parameters.Add("@Terminal", SqlDbType.VarChar, 20).Value = (myitmDetalleComprobante.TerminalRegistro == null) ? Environment.MachineName : myitmDetalleComprobante.TerminalRegistro;
                cmm.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = (myitmDetalleComprobante.UserRegistro == null) ? "0000000000" : myitmDetalleComprobante.UserRegistro;
                cmm.Parameters.Add("@IdComprobante", SqlDbType.Char, 10).Value = (myitmDetalleComprobante.IdComprobante == null) ? "" : myitmDetalleComprobante.IdComprobante;
                cmm.Parameters.Add("@Ultimo", SqlDbType.Bit).Value = myitmDetalleComprobante.Ultimo;
                cmm.Parameters.Add("@PMatricula", SqlDbType.Bit).Value = myitmDetalleComprobante.PMatricula;
                cmm.Parameters.Add("@PDeuda", SqlDbType.TinyInt).Value = myitmDetalleComprobante.PDeuda;
                cmm.Parameters.Add("@IdMatricula", SqlDbType.Char, 12).Value = (myitmDetalleComprobante.IdMatricula == null) ? "" : myitmDetalleComprobante.IdMatricula;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@IdMatricula"].Value.ToString();
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
