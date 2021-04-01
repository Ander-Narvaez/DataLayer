using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsBodega : ClsConexion
    {
        public String aBODEGA;
        public String aNOMBRE;
        public String aUBICACION;

        public ClsBodega()
        {
            this.aBODEGA = "";
            this.aNOMBRE = "";
            this.aUBICACION = "";
        }

        public ClsBodega(string pBODEGA, String pNOMBRE, String pUBICACION)
        {
            this.aBODEGA = pBODEGA;
            this.aNOMBRE = pNOMBRE;
            this.aUBICACION = pUBICACION;
        }

        public String MaintenanceBodega(ClsBodega bodega, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_bodega";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = bodega.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = bodega.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = bodega.aUBICACION;
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

        public DataSet GetListBodega(ClsBodega bodega, String pACCION)
        {
            DataSet DtsBodega = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsBodega.Clear();
                DtsBodega.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_bodega";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = bodega.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = bodega.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = bodega.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsBodega);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsBodega;
        }
    }
}

