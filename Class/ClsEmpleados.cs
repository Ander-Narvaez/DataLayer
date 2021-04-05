using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsEmpleados : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aCEDULA;
        public String aNOMBRE;
        public String aAPELLIDOS;
        public String aEMAIL;
        public String aTELEFONO;

        public ClsEmpleados()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aCEDULA = "";
            this.aNOMBRE = "";
            this.aAPELLIDOS = "";
            this.aEMAIL = "";
            this.aTELEFONO = "";
        }

        public ClsEmpleados(string pEMPRESA, String pSUCURSAL, String pCEDULA, String pNOMBRE, String pAPELLIDOS, String pEMAIL, String pTELEFONO)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aCEDULA = pCEDULA;
            this.aNOMBRE = pNOMBRE;
            this.aAPELLIDOS = pAPELLIDOS;
            this.aEMAIL = pEMAIL;
            this.aTELEFONO = pTELEFONO;
        }

        public String MaintenanceEmpleados(ClsEmpleados empleados, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_empleados";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = empleados.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = empleados.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_cedula", OracleDbType.Varchar2)).Value = empleados.aCEDULA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = empleados.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_apellidos", OracleDbType.Varchar2)).Value = empleados.aAPELLIDOS;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = empleados.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = empleados.aTELEFONO;
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

        public DataSet GetListEmpleados(ClsEmpleados empleados, String pACCION)
        {
            DataSet DtsEmpleados = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsEmpleados.Clear();
                DtsEmpleados.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_empleados";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = empleados.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = empleados.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_cedula", OracleDbType.Varchar2)).Value = empleados.aCEDULA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = empleados.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_apellidos", OracleDbType.Varchar2)).Value = empleados.aAPELLIDOS;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = empleados.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = empleados.aTELEFONO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsEmpleados);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsEmpleados;
        }
    }
}

