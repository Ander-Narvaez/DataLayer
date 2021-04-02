using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsUsuarios : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public int aID;
        public String aUSUARIO;
        public String aCONTRA;
        public String aTIPO;

        public ClsUsuarios()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aID = 0;
            this.aUSUARIO = "";
            this.aCONTRA = "";
            this.aTIPO = "";
        }

        public ClsUsuarios(string pEMPRESA, String pSUCURSAL, int pID, String pUSUARIO, String pCONTRA, String pTIPO)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aID = pID;
            this.aUSUARIO = pUSUARIO;
            this.aCONTRA = pCONTRA;
            this.aTIPO = pTIPO;
        }

        public String MaintenanceUsuarios(ClsUsuarios usuarios, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_usuarios";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = usuarios.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = usuarios.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_id", OracleDbType.Int32)).Value = usuarios.aID;
                Cmd.Parameters.Add(new OracleParameter("p_usuario", OracleDbType.Varchar2)).Value = usuarios.aUSUARIO;
                Cmd.Parameters.Add(new OracleParameter("p_contra", OracleDbType.Varchar2)).Value = usuarios.aCONTRA;
                Cmd.Parameters.Add(new OracleParameter("p_tipo", OracleDbType.Varchar2)).Value = usuarios.aTIPO;
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

        public DataSet GetListUsuarios(ClsUsuarios usuarios, String pACCION)
        {
            DataSet DtsUsuarios = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsUsuarios.Clear();
                DtsUsuarios.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_usuarios";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = usuarios.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = usuarios.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_id", OracleDbType.Int32)).Value = usuarios.aID;
                Cmd.Parameters.Add(new OracleParameter("p_usuario", OracleDbType.Varchar2)).Value = usuarios.aUSUARIO;
                Cmd.Parameters.Add(new OracleParameter("p_contra", OracleDbType.Varchar2)).Value = usuarios.aCONTRA;
                Cmd.Parameters.Add(new OracleParameter("p_tipo", OracleDbType.Varchar2)).Value = usuarios.aTIPO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsUsuarios);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsUsuarios;
        }
    }
}

