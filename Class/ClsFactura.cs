using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsFactura : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public int aFACTURA;
        public String aCLIENTE;
        public String aEMPLEADO;
        public DateTime aFECHA;
        public String aESTADO;

        public ClsFactura()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aFACTURA = 0;
            this.aCLIENTE = "";
            this.aEMPLEADO = "";
            this.aFECHA = DateTime.Today;
            this.aESTADO = "";
        }

        public ClsFactura(string pEMPRESA, String pSUCURSAL, int pFACTURA, String pCLIENTE, String pEMPLEADO, DateTime pFECHA, String pESTADO)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aFACTURA = pFACTURA;
            this.aCLIENTE = pCLIENTE;
            this.aEMPLEADO = pEMPLEADO;
            this.aFECHA = pFECHA;
            this.aESTADO = pESTADO;
        }

        public String MaintenanceFactura(ClsFactura factura, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_factura";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = factura.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = factura.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_factura", OracleDbType.Int32)).Value = factura.aFACTURA;
                Cmd.Parameters.Add(new OracleParameter("p_cliente", OracleDbType.Varchar2)).Value = factura.aCLIENTE;
                Cmd.Parameters.Add(new OracleParameter("p_empleado", OracleDbType.Varchar2)).Value = factura.aEMPLEADO;
                Cmd.Parameters.Add(new OracleParameter("p_fecha", OracleDbType.Date)).Value = factura.aFECHA;
                Cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Varchar2)).Value = factura.aESTADO;
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

        public DataSet GetListFactura(ClsFactura factura, String pACCION)
        {
            DataSet DtsFactura = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsFactura.Clear();
                DtsFactura.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_factura";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = factura.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = factura.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_factura", OracleDbType.Int32)).Value = factura.aFACTURA;
                Cmd.Parameters.Add(new OracleParameter("p_cliente", OracleDbType.Varchar2)).Value = factura.aCLIENTE;
                Cmd.Parameters.Add(new OracleParameter("p_empleado", OracleDbType.Varchar2)).Value = factura.aEMPLEADO;
                Cmd.Parameters.Add(new OracleParameter("p_fecha", OracleDbType.Date)).Value = factura.aFECHA;
                Cmd.Parameters.Add(new OracleParameter("p_estado", OracleDbType.Varchar2)).Value = factura.aESTADO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsFactura);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsFactura;
        }
    }
}

