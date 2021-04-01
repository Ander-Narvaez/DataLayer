using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLayer.Class
{
    public class ClsDetalle_Factura : ClsConexion
    {
        public String aID_EMPRESA;
        public String aID_SUCURSAL;
        public Int32  aNUM_LINEA;
        public Int32  aFACTURA;
        public String aARTICULO;
        public Int32  aCANTIDAD;
        public Int32  aIMPUESTO;
        public Int32  aDESCUENTO;
        public Int32  aTOTAL;

        public ClsDetalle_Factura()
        {
            this.aID_EMPRESA  = "";
            this.aID_SUCURSAL = "";
            this.aNUM_LINEA   = 0;
            this.aFACTURA     = 0;
            this.aARTICULO    = "";
            this.aCANTIDAD    = 0;
            this.aIMPUESTO    = 0;
            this.aDESCUENTO   = 0;
            this.aTOTAL       = 0;
        }

        public ClsDetalle_Factura(string pID_EMPRESA, String pID_SUCURSAL, Int32 pNUM_LINEA, Int32 pFACTURA, String pARTICULO, Int32 pCANTIDAD, Int32 pIMPUESTO, Int32 pDESCUENTO, Int32 pTOTAL)
        {
            this.aID_EMPRESA  = pID_EMPRESA;
            this.aID_SUCURSAL = pID_SUCURSAL;
            this.aNUM_LINEA   = pNUM_LINEA;
            this.aFACTURA     = pFACTURA;
            this.aARTICULO    = pARTICULO;
            this.aCANTIDAD    = pCANTIDAD;
            this.aIMPUESTO    = pIMPUESTO;
            this.aDESCUENTO   = pDESCUENTO;
            this.aTOTAL       = pTOTAL;
        }

        public String MaintenanceDetalle_Factura(ClsDetalle_Factura detalle_Factura, String pACCION)
        {
            String Menssage = "";
            try
            {

                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                AbrirBaseDatos();
                Cmd.CommandText = "package_supermercados.stp_mantenimiento_detalle_Factura";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_id_empresa", OracleDbType.Varchar2)).Value = detalle_Factura.aID_EMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_id_sucursal", OracleDbType.Varchar2)).Value = detalle_Factura.aID_SUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_num_linea", OracleDbType.Int32)).Value = detalle_Factura.aNUM_LINEA;
                Cmd.Parameters.Add(new OracleParameter("p_factura", OracleDbType.Int32)).Value = detalle_Factura.aFACTURA;
                Cmd.Parameters.Add(new OracleParameter("p_articulo", OracleDbType.Varchar2)).Value = detalle_Factura.aARTICULO;
                Cmd.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32)).Value = detalle_Factura.aCANTIDAD;
                Cmd.Parameters.Add(new OracleParameter("p_impuesto", OracleDbType.Int32)).Value = detalle_Factura.aIMPUESTO;
                Cmd.Parameters.Add(new OracleParameter("p_descuento", OracleDbType.Int32)).Value = detalle_Factura.aDESCUENTO;
                Cmd.Parameters.Add(new OracleParameter("p_total", OracleDbType.Int32)).Value = detalle_Factura.aTOTAL;
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

        public DataSet GetListDetalle_Factura(ClsDetalle_Factura detalle_Factura, String pACCION)
        {
            DataSet DtsDetalle_Factura = new DataSet();

            try
            {
                AbrirBaseDatos();
                DtsDetalle_Factura.Clear();
                DtsDetalle_Factura.EnforceConstraints = false;
                Cmd = new OracleCommand();
                Cmd.Connection = conexion;
                Cmd.CommandText = "package_supermercados.stp_detalle_Factura";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new OracleParameter("p_id_empresa", OracleDbType.Varchar2)).Value = detalle_Factura.aID_EMPRESA;
                Cmd.Parameters.Add(new OracleParameter("p_id_sucursal", OracleDbType.Varchar2)).Value = detalle_Factura.aID_SUCURSAL;
                Cmd.Parameters.Add(new OracleParameter("p_num_linea", OracleDbType.Int32)).Value = detalle_Factura.aNUM_LINEA;
                Cmd.Parameters.Add(new OracleParameter("p_factura", OracleDbType.Int32)).Value = detalle_Factura.aFACTURA;
                Cmd.Parameters.Add(new OracleParameter("p_articulo", OracleDbType.Varchar2)).Value = detalle_Factura.aARTICULO;
                Cmd.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32)).Value = detalle_Factura.aCANTIDAD;
                Cmd.Parameters.Add(new OracleParameter("p_impuesto", OracleDbType.Int32)).Value = detalle_Factura.aIMPUESTO;
                Cmd.Parameters.Add(new OracleParameter("p_descuento", OracleDbType.Int32)).Value = detalle_Factura.aDESCUENTO;
                Cmd.Parameters.Add(new OracleParameter("p_total", OracleDbType.Int32)).Value = detalle_Factura.aTOTAL;
                Cmd.Parameters.Add(new OracleParameter("p_accion", OracleDbType.Varchar2)).Value = pACCION;
                Cmd.Parameters.Add(new OracleParameter("p_recordset", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
                OracleDataAdapter DataAdapter = new OracleDataAdapter(Cmd);
                DataAdapter.Fill(DtsDetalle_Factura);
                cerrar_base();

            }
            catch (Exception Ex)
            {
                cerrar_base();
                throw new Exception(Ex.Message);
            }
            return DtsDetalle_Factura;
        }
    }
}