using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Recaudacion.BE;



namespace Recaudacion.DA
{
    public class daRecepcion
    {
        SqlConnection conec = new SqlConnection(daHelper.conexion());
        SqlCommand cmm;

        List<beRecepcion> lisRecepcion;
        beRecepcion itmRecepcion;
        beReturn itmReturn;

        public List<beRecepcion> ListaPorFechas(DateTime dtmFechaInicio, DateTime dtmFechaFinal)
        {
            lisRecepcion = new List<beRecepcion>();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionBuscarPorFechas", conec);
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
                    itmRecepcion = new beRecepcion();
                    itmRecepcion.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcion.strCuenta = Convert.ToString(dr["strCuenta"]);
                    itmRecepcion.dtmFechaProceso = Convert.ToDateTime(dr["dtmFechaProceso"]);
                    itmRecepcion.intRegistros = Convert.ToInt32(dr["intRegistros"]);
                    itmRecepcion.dblMontoTotal = Convert.ToInt32(dr["dblMontoTotal"]);
                    itmRecepcion.strCodigoInterno = Convert.ToString(dr["strCodigoInterno"]);
                    itmRecepcion.strCodigoTeletransfer = Convert.ToString(dr["strCodigoTeletransfer"]);
                    itmRecepcion.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    itmRecepcion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmRecepcion.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                    lisRecepcion.Add(itmRecepcion);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lisRecepcion;
        }
        public beRecepcion Detalle(int intIdRecepcion)
        {
            itmRecepcion = new beRecepcion();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionByID", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@intIdRecepcion", SqlDbType.Int).Value = intIdRecepcion;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmRecepcion.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcion.strCuenta = Convert.ToString(dr["strCuenta"]);
                    itmRecepcion.dtmFechaProceso = Convert.ToDateTime(dr["dtmFechaProceso"]);
                    itmRecepcion.intRegistros = Convert.ToInt32(dr["intRegistros"]);
                    itmRecepcion.dblMontoTotal = Convert.ToInt32(dr["dblMontoTotal"]);
                    itmRecepcion.strCodigoInterno = Convert.ToString(dr["strCodigoInterno"]);
                    itmRecepcion.strCodigoTeletransfer = Convert.ToString(dr["strCodigoTeletransfer"]);
                    itmRecepcion.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    itmRecepcion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmRecepcion.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmRecepcion;
        }
        public beRecepcion DetalleCodigoInterno(string strCodigoInterno)
        {
            itmRecepcion = new beRecepcion();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionByCodigoInterno", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@strCodigoInterno", SqlDbType.VarChar, 10).Value = strCodigoInterno;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmRecepcion.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcion.strCuenta = Convert.ToString(dr["strCuenta"]);
                    itmRecepcion.dtmFechaProceso = Convert.ToDateTime(dr["dtmFechaProceso"]);
                    itmRecepcion.intRegistros = Convert.ToInt32(dr["intRegistros"]);
                    itmRecepcion.dblMontoTotal = Convert.ToInt32(dr["dblMontoTotal"]);
                    itmRecepcion.strCodigoInterno = Convert.ToString(dr["strCodigoInterno"]);
                    itmRecepcion.strCodigoTeletransfer = Convert.ToString(dr["strCodigoTeletransfer"]);
                    itmRecepcion.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    itmRecepcion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmRecepcion.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmRecepcion;
        }
        public beRecepcion DetalleFechaProceso(DateTime dtmFechaProceso)
        {
            itmRecepcion = new beRecepcion();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_RecepcionByFechaProceso", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                cmm.Parameters.Add("@dtmFechaProceso", SqlDbType.DateTime).Value = dtmFechaProceso;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    itmRecepcion.intIdRecepcion = Convert.ToInt32(dr["intIdRecepcion"]);
                    itmRecepcion.strCuenta = Convert.ToString(dr["strCuenta"]);
                    itmRecepcion.dtmFechaProceso = Convert.ToDateTime(dr["dtmFechaProceso"]);
                    itmRecepcion.intRegistros = Convert.ToInt32(dr["intRegistros"]);
                    itmRecepcion.dblMontoTotal = Convert.ToInt32(dr["dblMontoTotal"]);
                    itmRecepcion.strCodigoInterno = Convert.ToString(dr["strCodigoInterno"]);
                    itmRecepcion.strCodigoTeletransfer = Convert.ToString(dr["strCodigoTeletransfer"]);
                    itmRecepcion.strCodigoServicio = Convert.ToString(dr["strCodigoServicio"]);
                    itmRecepcion.UserRegistro = Convert.ToString(dr["UserRegistro"]);
                    itmRecepcion.dtmFechaRegistro = Convert.ToDateTime(dr["dtmFechaRegistro"]);
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmRecepcion;
        }

        public beReturn Insert(beRecepcion myitmRecepcion)
        {
            itmReturn = new beReturn();
            try
            {
                cmm = new SqlCommand("CobranzaWeb.wsp_Recepcion_Insert", conec);
                cmm.CommandType = CommandType.StoredProcedure;
                SqlParameter intIdRecepcion = new SqlParameter();
                intIdRecepcion.ParameterName = "@intIdRecepcion";
                intIdRecepcion.SqlDbType = SqlDbType.Int;
                intIdRecepcion.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(intIdRecepcion).Value = myitmRecepcion.intIdRecepcion;
                cmm.Parameters.Add("@strCuenta", SqlDbType.VarChar, 16).Value = (myitmRecepcion.strCuenta == null) ? "" : myitmRecepcion.strCuenta;
                cmm.Parameters.Add("@dtmFechaProceso", SqlDbType.DateTime).Value = myitmRecepcion.dtmFechaProceso;
                cmm.Parameters.Add("@intRegistros", SqlDbType.Int).Value = myitmRecepcion.intRegistros;
                cmm.Parameters.Add("@dblMontoTotal", SqlDbType.Decimal).Value = myitmRecepcion.dblMontoTotal;
                cmm.Parameters.Add("@strCodigoInterno", SqlDbType.VarChar, 10).Value = (myitmRecepcion.strCodigoInterno == null) ? "" : myitmRecepcion.strCodigoInterno;
                cmm.Parameters.Add("@strCodigoTeletransfer", SqlDbType.VarChar, 20).Value = (myitmRecepcion.strCodigoTeletransfer == null) ? "" : myitmRecepcion.strCodigoTeletransfer;
                cmm.Parameters.Add("@strCodigoServicio", SqlDbType.VarChar, 20).Value = (myitmRecepcion.strCodigoServicio == null) ? "" : myitmRecepcion.strCodigoServicio;
                cmm.Parameters.Add("@UserRegistro", SqlDbType.VarChar, 20).Value = (myitmRecepcion.UserRegistro == null) ? "0000000000" : myitmRecepcion.UserRegistro;
                cmm.Parameters.Add("@dtmFechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;

                int sqlRows;
                if (conec.State == ConnectionState.Closed)
                {
                    conec.Open();
                }
                sqlRows = cmm.ExecuteNonQuery();
                itmReturn.intIdReturn = sqlRows;
                if (itmReturn.intIdReturn > 0)
                {
                    itmReturn.strReturn = cmm.Parameters["@intIdRecepcion"].Value.ToString();
                }
                conec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return itmReturn;
        }

        public beRecepcion DetalleTXT(string strArchivoTXT)
        {
            itmRecepcion = new beRecepcion();
            string line;
            beRecepcionDetalle itmRecepcionDetalle;
            System.IO.StreamReader file = new System.IO.StreamReader(strArchivoTXT);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0,2) == "CC")
                {
                    itmRecepcion.strCuenta = Convert.ToString(line.Substring(2,3) + "-" + line.Substring(6, 7) + "-" + line.Substring(5, 1));
                    //string[] lito = { line.Substring(14, 4), line.Substring(18, 2), line.Substring(20, 2), line.Substring(56, 2), line.Substring(58, 2), line.Substring(60, 2) };
                    itmRecepcion.dtmFechaProceso = new DateTime(Convert.ToInt16(line.Substring(14, 4)), Convert.ToInt16(line.Substring(18, 2)), Convert.ToInt16(line.Substring(20, 2)), Convert.ToInt16(line.Substring(56, 2)), Convert.ToInt16(line.Substring(58, 2)), Convert.ToInt16(line.Substring(60, 2)));
                    itmRecepcion.intRegistros = Convert.ToInt16(line.Substring(22, 9));
                    itmRecepcion.dblMontoTotal = Convert.ToDecimal(line.Substring(31, 13)+"."+line.Substring(44, 2));
                    itmRecepcion.strCodigoInterno = Convert.ToString(line.Substring(46, 4));
                    itmRecepcion.strCodigoTeletransfer = Convert.ToString(line.Substring(50, 6));
                    itmRecepcion.strCodigoServicio = Convert.ToString(line.Substring(62, 6));
                }
                if (line.Substring(0, 2) == "DD")
                {
                    itmRecepcionDetalle = new beRecepcionDetalle();
                    itmRecepcionDetalle.strCodigoDeposotante = ParseTxtToIdAlumno(Convert.ToString(line.Substring(13, 14).Trim()));
                    itmRecepcionDetalle.strDatoAdicional = Convert.ToString(line.Substring(27, 30).Trim());
                    itmRecepcionDetalle.dtmFechaPago = new DateTime(Convert.ToInt16(line.Substring(57, 4)), Convert.ToInt16(line.Substring(61, 2)), Convert.ToInt16(line.Substring(63, 2)), Convert.ToInt16(line.Substring(168, 2)), Convert.ToInt16(line.Substring(170, 2)), Convert.ToInt16(line.Substring(172, 2)));
                    itmRecepcionDetalle.dtmFechaVencimiento = new DateTime(Convert.ToInt16(line.Substring(65, 4)), Convert.ToInt16(line.Substring(69, 2)), Convert.ToInt16(line.Substring(71, 2)));
                    itmRecepcionDetalle.dblMonto = Convert.ToDecimal(line.Substring(73, 13)+"."+line.Substring(86, 2));
                    itmRecepcionDetalle.dblMora = Convert.ToDecimal(line.Substring(88, 13) + "." + line.Substring(101, 2));
                    itmRecepcionDetalle.dblMontoTotal = Convert.ToDecimal(line.Substring(103, 13) + "." + line.Substring(116, 2));
                    itmRecepcionDetalle.strSucursal = Convert.ToString(line.Substring(118, 3).Trim());
                    itmRecepcionDetalle.strAgencia = Convert.ToString(line.Substring(121, 3).Trim());
                    itmRecepcionDetalle.strNroOperacion = Convert.ToString(line.Substring(124, 6).Trim());
                    itmRecepcionDetalle.strTerminal = Convert.ToString(line.Substring(152, 4).Trim());
                    itmRecepcionDetalle.strMedioAtencion = Convert.ToString(line.Substring(156, 2).Trim());
                    itmRecepcionDetalle.strNroCheque = Convert.ToString(line.Substring(174, 10).Trim());
                    itmRecepcionDetalle.strCodigoBanco = Convert.ToString(line.Substring(184, 2).Trim());
                    itmRecepcionDetalle.strCargoFijo = Convert.ToString(line.Substring(186, 10).Trim());
                    itmRecepcionDetalle.strFlagExtorno = Convert.ToString(line.Substring(196,1).Trim());
                    itmRecepcionDetalle.strNroDocPago = Convert.ToString(line.Substring(197, 20).Trim());
                    itmRecepcionDetalle.strNroOperacionBD = Convert.ToString(line.Substring(217, 8).Trim());
                    itmRecepcionDetalle.strReferencia = Convert.ToString(line.Substring(130, 22).Trim());
                    itmRecepcion.lisRecepcionDetalle.Add(itmRecepcionDetalle);
                }
            }
            file.Close();
            return itmRecepcion;
        }

        private string ParseTxtToIdAlumno(string Texto)
        {
            string TextoRetorno = "";
            TextoRetorno = Convert.ToString(Convert.ToInt32(Texto)).Trim();
            if (TextoRetorno.Length > 8)
            {
                TextoRetorno = TextoRetorno.PadLeft(10, '0');
            }
            else
            {
                TextoRetorno = TextoRetorno.PadLeft(8, '0');
            }
            //TextoRetorno = Texto.PadLeft(Longitud, '0').Substring(0, Longitud)
            return TextoRetorno;
        }

        //public beRecepcion DetalleXLS(string strArchivoXLS)
        //{
        //    itmRecepcion = new beRecepcion();
        //    System.Data.OleDb.OleDbConnection connXLS = new System.Data.OleDb.OleDbConnection();
        //    //connXLS.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strArchivoXLS + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //    //connXLS.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strArchivoXLS + ";Mode = ReadWrite;Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //    connXLS.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strArchivoXLS + ";Extended Properties="+'"'+"Excel 8.0;HDR=Yes;IMEX=2" +'"';

        //    if (connXLS.State == ConnectionState.Closed)
        //    {
        //        connXLS.Open();
        //    }

        //    //try
        //    //{
        //    DataSet dset = new DataSet();
        //    OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [VisualizarArchivodeResultado$]", connXLS);
        //    dadp.TableMappings.Add("tbl", "Table");
        //    dadp.Fill(dset);
        //    DataTable table = dset.Tables[0];

        //    //for (int i = 0; i < table.Rows.Count; i++)
        //    //{
        //    //    Console.Write(table.Rows[i][0] + "\t" + table.Rows[i][1] + "\n");
        //    //}
        //    connXLS.Close();
        //    itmRecepcion.strCuenta = Convert.ToString(table.Rows[1][1]);
        //    itmRecepcion.dtmFechaProceso = Convert.ToDateTime(Convert.ToString(table.Rows[2][1])+" "+ Convert.ToString(table.Rows[7][1]));
        //    itmRecepcion.intRegistros = Convert.ToInt16(table.Rows[3][1]);
        //    itmRecepcion.dblMontoTotal = Convert.ToDecimal(table.Rows[4][1]);
        //    itmRecepcion.strCodigoInterno = Convert.ToString(table.Rows[5][1]);
        //    itmRecepcion.strCodigoTeletransfer = Convert.ToString(table.Rows[6][1]);
        //    itmRecepcion.strCodigoServicio = Convert.ToString(table.Rows[8][1]);

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw new Exception(ex.Message);
        //    //}
        //    return itmRecepcion;
        //}

    }
}
