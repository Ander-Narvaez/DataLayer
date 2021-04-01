using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsCarde_Movimiento : ClsConexion
    {
        public String   aEMPRESA;
        public String   aSUCURSAL;
        public String   aUSUARIO;
        public Int32    aMOVIMIENTO;
        public Int32    aINVENTARIO;
        public String   aTIPO;
        public Int32    aCANTIDAD_EXISTENTE;
        public Int32    aCANTIDAD;
        public DateTime aFECHA_HORA;
      

        public ClsCarde_Movimiento()
        {
            this.aEMPRESA = "";
            this.aSUCURSAL = "";
            this.aUSUARIO = "";
            this.aMOVIMIENTO = 0;
            this.aINVENTARIO = 0;
            this.aTIPO = "";
            this.aCANTIDAD_EXISTENTE = 0;
            this.aCANTIDAD = 0;
            this.aFECHA_HORA = DateTime.Today;
           
        }

        public ClsCarde_Movimiento(String pEMPRESA, String pSUCURSAL, String pUSUARIO, Int32 pMOVIMIENTO , Int32 pINVENTARIO, String pTIPO, Int32 pCANTIDAD_EXISTENTE, Int32 pCANTIDAD, DateTime pFECHA_HORA)
        {
            this.aEMPRESA = pEMPRESA;
            this.aSUCURSAL = pSUCURSAL;
            this.aUSUARIO = pUSUARIO;
            this.aMOVIMIENTO = pMOVIMIENTO;
            this.aINVENTARIO = pINVENTARIO;
            this.aTIPO = pTIPO;
            this.aCANTIDAD_EXISTENTE = pCANTIDAD_EXISTENTE;
            this.aCANTIDAD = pCANTIDAD;
            this.aFECHA_HORA = pFECHA_HORA;
            
        }

        public String MaintenanceCarde_Movimiento(ClsCarde_Movimiento carde_Movimiento, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_Carde_Movimiento ";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = carde_Movimiento.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = carde_Movimiento.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_usuario", OracleDbType.Varchar2)).Value = carde_Movimiento.aUSUARIO;
                Cmd.Parameters.Add(new OracleParameter("p_movimiento", OracleDbType.Int32)).Value = carde_Movimiento.aMOVIMIENTO;
                Cmd.Parameters.Add(new OracleParameter("p_inventario", OracleDbType.Int32)).Value = carde_Movimiento.aINVENTARIO;
                Cmd.Parameters.Add(new OracleParameter("p_tipo", OracleDbType.Varchar2)).Value = carde_Movimiento.aTIPO;
                Cmd.Parameters.Add(new OracleParameter("p_cantidad_existente", OracleDbType.Int32)).Value = carde_Movimiento.aCANTIDAD_EXISTENTE;
                Cmd.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32)).Value = carde_Movimiento.aCANTIDAD;
                Cmd.Parameters.Add(new OracleParameter("p_fecha_hora", OracleDbType.Date)).Value = carde_Movimiento.aFECHA_HORA;
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

        public DataSet GetListCarde_Movimiento(ClsCarde_Movimiento carde_Movimiento, String pACCION)
        {
            DataSet DtsCarde_Movimiento = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsCarde_Movimiento.Clear();
                DtsCarde_Movimiento.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_carde_Movimiento";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_empresa", OracleDbType.Varchar2)).Value = carde_Movimiento.aEMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_sucursal", OracleDbType.Varchar2)).Value = carde_Movimiento.aSUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_usuario", OracleDbType.Varchar2)).Value = carde_Movimiento.aUSUARIO;
                Cmd.Parameters.Add(new OracleParameter("p_movimiento", OracleDbType.Int32)).Value = carde_Movimiento.aMOVIMIENTO;
                Cmd.Parameters.Add(new OracleParameter("p_inventario", OracleDbType.Int32)).Value = carde_Movimiento.aINVENTARIO;
                Cmd.Parameters.Add(new OracleParameter("p_tipo", OracleDbType.Varchar2)).Value = carde_Movimiento.aTIPO;
                Cmd.Parameters.Add(new OracleParameter("p_cantidad_existente", OracleDbType.Int32)).Value = carde_Movimiento.aCANTIDAD_EXISTENTE;
                Cmd.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32)).Value = carde_Movimiento.aCANTIDAD;
                Cmd.Parameters.Add(new OracleParameter("p_fecha_hora", OracleDbType.Date)).Value = carde_Movimiento.aFECHA_HORA;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsCarde_Movimiento);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsCarde_Movimiento;
        }
    }
}