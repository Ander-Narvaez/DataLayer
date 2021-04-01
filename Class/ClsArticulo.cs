using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsArticulo : ClsConexion
    {
        public String aARTICULO;
        public String aCATEGORIA;
        public Decimal aPRECIO;

        public ClsArticulo()
        {
            this.aARTICULO = "";
            this.aCATEGORIA = "";
            this.aPRECIO = 0 ;
        }

        public ClsArticulo(string pARTICULO, String pCATEGORIA, Decimal pPRECIO)
        {
            this.aARTICULO = pARTICULO;
            this.aCATEGORIA = pCATEGORIA;
            this.aPRECIO = pPRECIO;
        }

        public String MaintenanceArticulo(ClsArticulo articulo, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_articulo";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_articulo", OracleDbType.Varchar2)).Value = articulo.aARTICULO;
                Cmd.Parameters.Add(new OracleParameter("p_categoria", OracleDbType.Varchar2)).Value = articulo.aCATEGORIA;
                Cmd.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Decimal)).Value = articulo.aPRECIO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                Cmd.ExecuteNonQuery();
                Menssage = "Ejecutado con exito";

                cerrar_base();
            }
            catch (Exception Ex)
            {
                Menssage = Ex.Message;
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return Menssage;
        }

        public DataSet GetListArticulo(ClsArticulo articulo, String pACCION)
        {
            DataSet DtsArticulo = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsArticulo.Clear();
                DtsArticulo.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_articulo";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_articulo", OracleDbType.Varchar2)).Value = articulo.aARTICULO;
                Cmd.Parameters.Add(new OracleParameter("p_categoria", OracleDbType.Varchar2)).Value = articulo.aCATEGORIA;
                Cmd.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Decimal)).Value = articulo.aPRECIO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsArticulo);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsArticulo;
        }
    }
}
