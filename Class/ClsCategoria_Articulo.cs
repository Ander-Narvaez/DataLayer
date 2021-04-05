using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsCategoria_articulo : ClsConexion
    {
        public String aCODIGO;
        public String aDESCRIPCION;
        public Int32  aIMPUESTO;
       

        public ClsCategoria_articulo()
        {
            this.aCODIGO = "";
            this.aDESCRIPCION = "";
            this.aIMPUESTO = 0;
          
        }

        public ClsCategoria_articulo(string pCODIGO, String pDESCRIPCION, Int32 pIMPUESTO)
        {
            this.aCODIGO = pCODIGO;
            this.aDESCRIPCION = pDESCRIPCION;
            this.aIMPUESTO = pIMPUESTO;
           
        }

        public String MaintenanceCategoria_articulo(ClsCategoria_articulo categoria_articulo, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_categoria";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_codigo", OracleDbType.Varchar2)).Value = categoria_articulo.aCODIGO;
                Cmd.Parameters.Add(new OracleParameter("p_descripcion", OracleDbType.Varchar2)).Value = categoria_articulo.aDESCRIPCION;
                Cmd.Parameters.Add(new OracleParameter("p_impuesto", OracleDbType.Int32)).Value = categoria_articulo.aIMPUESTO;
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

        public DataSet GetListCategoria_articulo(ClsCategoria_articulo categoria_articulo, String pACCION)
        {
            DataSet DtsCategoria_articulo = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsCategoria_articulo.Clear();
                DtsCategoria_articulo.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_categoria";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_codigo", OracleDbType.Varchar2)).Value = categoria_articulo.aCODIGO;
                Cmd.Parameters.Add(new OracleParameter("p_descripcion", OracleDbType.Varchar2)).Value = categoria_articulo.aDESCRIPCION;
                Cmd.Parameters.Add(new OracleParameter("p_impuesto", OracleDbType.Int32)).Value = categoria_articulo.aIMPUESTO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsCategoria_articulo);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsCategoria_articulo;
        }
    }
}

