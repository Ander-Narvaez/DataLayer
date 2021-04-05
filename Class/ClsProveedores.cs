using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsProveedores : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aCEDULA_JURIDICA;
        public String aRAZON_SOCIAL;
        public String aUBICACION;
        public String aEMAIL;
        public String aTELEFONO;

        public ClsProveedores()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aCEDULA_JURIDICA = "";
            this.aRAZON_SOCIAL = "";
            this.aUBICACION = "";
            this.aEMAIL = "";
            this.aTELEFONO = "";
        }

        public ClsProveedores(string pEMPRESA, String pSUCURSAL, String pCEDULA_JURIDICA, String pRAZON_SOCIAL, String pUBICACION, String pEMAIL, String pTELEFONO)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aCEDULA_JURIDICA = pCEDULA_JURIDICA;
            this.aRAZON_SOCIAL = pRAZON_SOCIAL;
            this.aUBICACION = pUBICACION;
            this.aEMAIL = pEMAIL;
            this.aTELEFONO = pTELEFONO;
        }

        public String MaintenanceProveedores(ClsProveedores proveedores, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_proveedores";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = proveedores.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = proveedores.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_cedula_juridica", OracleDbType.Varchar2)).Value = proveedores.aCEDULA_JURIDICA;
                Cmd.Parameters.Add(new OracleParameter("p_razon_social", OracleDbType.Varchar2)).Value = proveedores.aRAZON_SOCIAL;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = proveedores.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = proveedores.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = proveedores.aTELEFONO;
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

        public DataSet GetListProveedores(ClsProveedores proveedores, String pACCION)
        {
            DataSet DtsProveedores = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsProveedores.Clear();
                DtsProveedores.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_proveedores";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = proveedores.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = proveedores.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_cedula_juridica", OracleDbType.Varchar2)).Value = proveedores.aCEDULA_JURIDICA;
                Cmd.Parameters.Add(new OracleParameter("p_razon_social", OracleDbType.Varchar2)).Value = proveedores.aRAZON_SOCIAL;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = proveedores.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = proveedores.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = proveedores.aTELEFONO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsProveedores);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsProveedores;
        }
    }
}