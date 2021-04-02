using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsEstante : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aBODEGA;
        public String aSECCION;
        public String aESTANTE;
        public String aDESCRIPCION;


        public ClsEstante()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aBODEGA = "";
            this.aSECCION = "";
            this.aESTANTE = "";
            this.aDESCRIPCION = "";

        }

        public ClsEstante(String pEMPRESA, String pSUCURSAL, String pBODEGA, String pSECCION, String pESTANTE, String pDESCRIPCION)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aBODEGA = pBODEGA;
            this.aSECCION = pSECCION;
            this.aESTANTE = pESTANTE;
            this.aDESCRIPCION = pDESCRIPCION;

        }

        public String MaintenanceEstante(ClsEstante estante, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_Estante ";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = estante.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = estante.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = estante.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_seccion", OracleDbType.Varchar2)).Value = estante.aSECCION;
                Cmd.Parameters.Add(new OracleParameter("p_estante", OracleDbType.Varchar2)).Value = estante.aESTANTE;
                Cmd.Parameters.Add(new OracleParameter("p_descripcion", OracleDbType.Varchar2)).Value = estante.aDESCRIPCION;
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

        public DataSet GetListEstante(ClsEstante estante, String pACCION)
        {
            DataSet DtsEstante = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsEstante.Clear();
                DtsEstante.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_estante";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = estante.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = estante.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = estante.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_seccion", OracleDbType.Varchar2)).Value = estante.aSECCION;
                Cmd.Parameters.Add(new OracleParameter("p_estante", OracleDbType.Varchar2)).Value = estante.aESTANTE;
                Cmd.Parameters.Add(new OracleParameter("p_descripcion", OracleDbType.Varchar2)).Value = estante.aDESCRIPCION;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsEstante);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsEstante;
        }
    }
}
