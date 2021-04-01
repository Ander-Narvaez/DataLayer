using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsBodega : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aUSUARIO;
        public String aBODEGA;
        public int aINVENTARIO;
        public String aNOMBRE;
        public String aUBICACION;

        public ClsBodega()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aUSUARIO = "";
            this.aBODEGA = "";
            this.aINVENTARIO = 0;
            this.aNOMBRE = "";
            this.aUBICACION = "";
        }

        public ClsBodega(string pEMPRESA, String pSUCURSAL, String pUSUARIO, string pBODEGA, int pINVENTARIO, String pNOMBRE, String pUBICACION)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aUSUARIO = pUSUARIO;
            this.aBODEGA = pBODEGA;
            this.aINVENTARIO = pINVENTARIO;
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
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = bodega.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = bodega.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_usuario", OracleDbType.Varchar2)).Value = bodega.aUSUARIO;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = bodega.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_inventario", OracleDbType.Varchar2)).Value = bodega.aINVENTARIO;
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
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = bodega.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = bodega.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_usuario", OracleDbType.Varchar2)).Value = bodega.aUSUARIO;
                Cmd.Parameters.Add(new OracleParameter("p_bodega", OracleDbType.Varchar2)).Value = bodega.aBODEGA;
                Cmd.Parameters.Add(new OracleParameter("p_inventario", OracleDbType.Varchar2)).Value = bodega.aINVENTARIO;
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

