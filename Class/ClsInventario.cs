using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsInventario : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aPROVEEDOR;
        public int aINVENTARIO;
        public String aARTICULO;
        public int aMAXIMOS;
        public int aMINIMOS;
        public int aEXISTENCIAS;

        public ClsInventario()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aPROVEEDOR = "";
            this.aINVENTARIO = 0;
            this.aARTICULO = "";
            this.aMAXIMOS = 0;
            this.aMINIMOS = 0;
            this.aEXISTENCIAS = 0;
        }

        public ClsInventario(string pEMPRESA, String pSUCURSAL, String pPROVEEDOR, int pINVENTARIO, String pARTICULO, int pMAXIMOS, int pMINIMOS, int pEXISTENCIAS)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aPROVEEDOR = pPROVEEDOR;
            this.aINVENTARIO = pINVENTARIO;
            this.aARTICULO = pARTICULO;
            this.aMAXIMOS = pMAXIMOS;
            this.aMINIMOS = pMINIMOS;
            this.aEXISTENCIAS = pEXISTENCIAS;
        }

        public String MaintenanceInventario(ClsInventario inventario, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_inventario";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = inventario.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = inventario.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_proveedor", OracleDbType.Varchar2)).Value = inventario.aPROVEEDOR;
                Cmd.Parameters.Add(new OracleParameter("p_inventario", OracleDbType.Int32)).Value = inventario.aINVENTARIO;
                Cmd.Parameters.Add(new OracleParameter("p_articulo", OracleDbType.Varchar2)).Value = inventario.aARTICULO;
                Cmd.Parameters.Add(new OracleParameter("p_maximos", OracleDbType.Int32)).Value = inventario.aMAXIMOS;
                Cmd.Parameters.Add(new OracleParameter("p_minimos", OracleDbType.Int32)).Value = inventario.aMINIMOS;
                Cmd.Parameters.Add(new OracleParameter("p_existencias", OracleDbType.Int32)).Value = inventario.aEXISTENCIAS;
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

        public DataSet GetListInventario(ClsInventario inventario, String pACCION)
        {
            DataSet DtsInventario = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsInventario.Clear();
                DtsInventario.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_inventario";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = inventario.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = inventario.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_proveedor", OracleDbType.Varchar2)).Value = inventario.aPROVEEDOR;
                Cmd.Parameters.Add(new OracleParameter("p_inventario", OracleDbType.Int32)).Value = inventario.aINVENTARIO;
                Cmd.Parameters.Add(new OracleParameter("p_articulo", OracleDbType.Varchar2)).Value = inventario.aARTICULO;
                Cmd.Parameters.Add(new OracleParameter("p_maximos", OracleDbType.Int32)).Value = inventario.aMAXIMOS;
                Cmd.Parameters.Add(new OracleParameter("p_minimos", OracleDbType.Int32)).Value = inventario.aMINIMOS;
                Cmd.Parameters.Add(new OracleParameter("p_existencias", OracleDbType.Int32)).Value = inventario.aEXISTENCIAS;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsInventario);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsInventario;
        }
    }
}

