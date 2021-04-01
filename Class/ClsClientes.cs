using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsClientes : ClsConexion
    {
        public String aCEDULA;
        public String aNOMBRE;
        public String aAPELLIDO_1;
        public String aAPELLIDO_2;

        public ClsClientes()
        {
            this.aCEDULA = "";
            this.aNOMBRE = "";
            this.aAPELLIDO_1 = "";
            this.aAPELLIDO_2 = "";
        }

        public ClsClientes(string pCEDULA, String pNOMBRE, String pAPELLIDO_1, String pAPELLIDO_2)
        {
            this.aCEDULA = pCEDULA;
            this.aNOMBRE = pNOMBRE;
            this.aAPELLIDO_1 = pAPELLIDO_1;
            this.aAPELLIDO_2 = pAPELLIDO_2;
        }

        public String MaintenanceClientes(ClsClientes clientes, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_clientes";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_cedula", OracleDbType.Varchar2)).Value = clientes.aCEDULA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = clientes.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_apellido_1", OracleDbType.Varchar2)).Value = clientes.aAPELLIDO_1;
                Cmd.Parameters.Add(new OracleParameter("p_apellido_2", OracleDbType.Int32)).Value = clientes.aAPELLIDO_2;
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

        public DataSet GetListClientes(ClsClientes clientes, String pACCION)
        {
            DataSet DtsClientes = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsClientes.Clear();
                DtsClientes.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_clientes";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_cedula", OracleDbType.Varchar2)).Value = clientes.aCEDULA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = clientes.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_apellido_1", OracleDbType.Varchar2)).Value = clientes.aAPELLIDO_1;
                Cmd.Parameters.Add(new OracleParameter("p_apellido_2", OracleDbType.Int32)).Value = clientes.aAPELLIDO_2;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsClientes);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsClientes;
        }
    }
}

