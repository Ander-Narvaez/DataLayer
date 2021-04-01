using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsEmpresa : ClsConexion
    {
        public String aEMPRESA;
        public String aNOMBRE;
        public String aUBICACION;
        public String aEMAIL;
        public String aTELEFONO;

        public ClsEmpresa()
        {
            this.aEMPRESA = "";
            this.aNOMBRE = "";
            this.aUBICACION = "";
            this.aEMAIL = "";
            this.aTELEFONO = "";
        }

        public ClsEmpresa(string pEMPRESA, String pNOMBRE, String pUBICACION, String pEMAIL, String pTELEFONO)
        {
            this.aEMPRESA = pEMPRESA;
            this.aNOMBRE = pNOMBRE;
            this.aUBICACION = pUBICACION;
            this.aEMAIL = pEMAIL;
            this.aTELEFONO = pTELEFONO;
        }

        public String MaintenanceEmpresa(ClsEmpresa empresa, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_empresa";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = empresa.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = empresa.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = empresa.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = empresa.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = empresa.aTELEFONO;
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

        public DataSet GetListEmpresa(ClsEmpresa empresa, String pACCION)
        {
            DataSet DtsEmpresa = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsEmpresa.Clear();
                DtsEmpresa.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_empresa";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_id_compañia", OracleDbType.Varchar2)).Value = empresa.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = empresa.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = empresa.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = empresa.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = empresa.aTELEFONO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsEmpresa);
                cerrar_base();

            }
            catch (Exception Ex)
            {
               cerrar_base();
               throw new Exception(Ex.Message);
            }
            return DtsEmpresa;
        }
    }
}
