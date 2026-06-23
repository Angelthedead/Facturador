using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CapaDeEntidades;
using System.Windows.Forms;

namespace CapaDeDatos
{
    // Interface to allow mocking the database interactions
    public interface IDatabaseService
    {
        void ExecuteNonQuery(string query, Action<SqlCommand> addParameters);
        object ExecuteScalar(string query, Action<SqlCommand> addParameters = null);
    }

    // Default implementation using actual SqlConnection/SqlCommand
    public class SqlDatabaseService : IDatabaseService
    {
        private readonly string _conexion;

        public SqlDatabaseService(string conexion)
        {
            _conexion = conexion;
        }

        public void ExecuteNonQuery(string query, Action<SqlCommand> addParameters)
        {
            using (SqlConnection Conn = new SqlConnection(_conexion))
            {
                using (SqlCommand Cmd = new SqlCommand(query, Conn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    if (addParameters != null)
                    {
                        addParameters(Cmd);
                    }
                    Cmd.Connection.Open();
                    Cmd.ExecuteNonQuery();
                    Cmd.Connection.Close();
                }
            }
        }

        public object ExecuteScalar(string query, Action<SqlCommand> addParameters = null)
        {
            using (SqlConnection Conn = new SqlConnection(_conexion))
            {
                using (SqlCommand Cmd = new SqlCommand(query, Conn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    if (addParameters != null)
                    {
                        addParameters(Cmd);
                    }
                    Cmd.Connection.Open();
                    object result = Cmd.ExecuteScalar();
                    Cmd.Connection.Close();
                    return result;
                }
            }
        }
    }

    public class CapaDeDatosFacturacion
    {
        private readonly IDatabaseService _databaseService;

        // Default constructor uses the real DB connection for backward compatibility
        public CapaDeDatosFacturacion()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
            _databaseService = new SqlDatabaseService(conexion);
        }

        // Injectable constructor for testing
        public CapaDeDatosFacturacion(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void InsertarCliente(CapaDeEntidadesCliente _Cliente)
        {
            try
            {
                string Query = "INSERTAR_CLIENTE";
                _databaseService.ExecuteNonQuery(Query, Cmd =>
                {
                    Cmd.Parameters.AddWithValue("@Nombres", _Cliente.Nombres);
                    Cmd.Parameters.AddWithValue("@Apellidos", _Cliente.Apellidos);
                    Cmd.Parameters.AddWithValue("@Cedula", _Cliente.Cedula);
                    Cmd.Parameters.AddWithValue("@Telefono", _Cliente.Telefono);
                    Cmd.Parameters.AddWithValue("@Correo", _Cliente.Correo);
                    Cmd.Parameters.AddWithValue("@Direccion", _Cliente.Direccion);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error1: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertarFactura(CapaDeEntidadesFactura _Facturacion)
        {
            try
            {
                string Query = "INSERTAR_FACTURA";
                _databaseService.ExecuteNonQuery(Query, Cmd =>
                {
                    Cmd.Parameters.AddWithValue("@IdCliente", _Facturacion.IdCliente);
                    Cmd.Parameters.AddWithValue("@BaseImponibleCero", _Facturacion.BaseImponibleCero);
                    Cmd.Parameters.AddWithValue("@BaseImponibleDoce", _Facturacion.BaseImponibleDoce);
                    Cmd.Parameters.AddWithValue("@Subtotal", _Facturacion.Subtotal);
                    Cmd.Parameters.AddWithValue("@IVA", _Facturacion.IVA);
                    Cmd.Parameters.AddWithValue("@Total", _Facturacion.Total);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error2: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InsertarDetalle(CapaDeEntidadesDetalle _Detalle)
        {
            try
            {
                string Query = "INSERTAR_DETALLE_FACTURA";
                _databaseService.ExecuteNonQuery(Query, Cmd =>
                {
                    Cmd.Parameters.AddWithValue("@IdFactura", _Detalle.IdFactura);
                    Cmd.Parameters.AddWithValue("@DescripcionProducto", _Detalle.DescripcionProducto);
                    Cmd.Parameters.AddWithValue("@Cantidad", _Detalle.Cantidad);
                    Cmd.Parameters.AddWithValue("@PrecioUnitario", _Detalle.PrecioUnitario);
                    Cmd.Parameters.AddWithValue("@IVAProducto", _Detalle.IVAProducto);
                    Cmd.Parameters.AddWithValue("@TotalProducto", _Detalle.TotalProducto);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error3: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public int ObtenerIdFactura()
        {
            try
            {
                string Query = "ObtenerUltimoIdFactura";
                return (int)_databaseService.ExecuteScalar(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error4: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }

        }

    }
}
