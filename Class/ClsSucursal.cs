using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsSucursal : ClsConexion
    {
        public String aEMPRESA;
        public String aSUCURSAL;
        public String aNOMBRE;
        public String aUBICACION;
        public String aEMAIL;
        public String aTELEFONO;

        public ClsSucursal()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aNOMBRE = "";
            this.aUBICACION = "";
            this.aEMAIL = "";
            this.aTELEFONO = "";
        }

        public ClsSucursal(string pEMPRESA, string pSUCURSAL, String pNOMBRE, String pUBICACION, String pEMAIL, String pTELEFONO)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aNOMBRE = pNOMBRE;
            this.aUBICACION = pUBICACION;
            this.aEMAIL = pEMAIL;
            this.aTELEFONO = pTELEFONO;
        }

        public String MaintenanceSucursal(ClsSucursal sucursal, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_sucursal";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = sucursal.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = sucursal.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = sucursal.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = sucursal.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = sucursal.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = sucursal.aTELEFONO;
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

        public DataSet GetListSucursal(ClsSucursal sucursal, String pACCION)
        {
            DataSet DtsSucursal = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsSucursal.Clear();
                DtsSucursal.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_sucursal";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = sucursal.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = sucursal.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2)).Value = sucursal.aNOMBRE;
                Cmd.Parameters.Add(new OracleParameter("p_ubicacion", OracleDbType.Varchar2)).Value = sucursal.aUBICACION;
                Cmd.Parameters.Add(new OracleParameter("p_email", OracleDbType.Varchar2)).Value = sucursal.aEMAIL;
                Cmd.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2)).Value = sucursal.aTELEFONO;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsSucursal);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsSucursal;
        }
    }
}
