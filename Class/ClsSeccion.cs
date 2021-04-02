using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsSeccion : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aBODEGA;
        public String aSECCION;
        public String aDESCRIPCION;

        public ClsSeccion()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aBODEGA = "";
            this.aSECCION = "";
            this.aDESCRIPCION = "";
        }

        public ClsSeccion(string pEMPRESA, String pSUCURSAL, String pBODEGA, String pSECCION, String pDESCRIPCION)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aBODEGA = pBODEGA;
            this.aSECCION = pSECCION;
            this.aDESCRIPCION = pDESCRIPCION;
        }

        public String MaintenanceSeccion(ClsSeccion seccion, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_seccion";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = seccion.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = seccion.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = seccion.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_seccion", OracleDbType.Varchar2)).Value = seccion.aSECCION;
                Cmd.Parameters.Add(new OracleParameter("p_descripcion", OracleDbType.Varchar2)).Value = seccion.aDESCRIPCION;
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

        public DataSet GetListSeccion(ClsSeccion seccion, String pACCION)
        {
            DataSet DtsSeccion = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsSeccion.Clear();
                DtsSeccion.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_seccion";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = seccion.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = seccion.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = seccion.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_seccion", OracleDbType.Varchar2)).Value = seccion.aSECCION;
                Cmd.Parameters.Add(new OracleParameter("p_descripcion", OracleDbType.Varchar2)).Value = seccion.aDESCRIPCION;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsSeccion);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsSeccion;
        }
    }
}

