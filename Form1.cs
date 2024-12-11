using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace OLYMPUS10
{
    public partial class FrmClientes : Form
    {
        private int selectedClienteId = -1; // Variable para almacenar el ID del cliente seleccionado

        public FrmClientes()
        {
            InitializeComponent();
        }

        // Método para guardar cliente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de insertar
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtGmail.Text) ||
                string.IsNullOrWhiteSpace(cbPlan.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Conexión a la base de datos
            string connectionString = "Server=DESKTOP-N2PIPNV\\SQLEXPRESS; Database=OLYMPUS10; User Id=sa; Password=mibichitodeluz;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insertar datos del cliente
                    string queryCliente = "INSERT INTO Clientes (Nombre, Apellido, Direccion, Telefono, FechaAlta, Gmail, Planes, Precio) " +
                                          "VALUES (@Nombre, @Apellido, @Direccion, @Telefono, @FechaAlta, @Gmail, @Planes, @Precio);";

                    using (SqlCommand command = new SqlCommand(queryCliente, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        command.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        command.Parameters.AddWithValue("@FechaAlta", dtpFechaAlta.Value);
                        command.Parameters.AddWithValue("@Gmail", txtGmail.Text);
                        command.Parameters.AddWithValue("@Planes", cbPlan.Text);
                        command.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text));

                        command.ExecuteNonQuery();
                    }

                    // Insertar el pago para el cliente
                    string queryPago = "INSERT INTO Pagos (ClienteNombre, ClienteApellido, Monto, FechaPago, FechaVencimiento, EstadoPago) " +
                                       "VALUES (@ClienteNombre, @ClienteApellido, @Monto, @FechaPago, @FechaVencimiento, 'Pendiente')";

                    using (SqlCommand commandPago = new SqlCommand(queryPago, connection))
                    {
                        commandPago.Parameters.AddWithValue("@ClienteNombre", txtNombre.Text);
                        commandPago.Parameters.AddWithValue("@ClienteApellido", txtApellido.Text);
                        commandPago.Parameters.AddWithValue("@Monto", decimal.Parse(txtPrecio.Text)); // Usamos el precio del cliente
                        commandPago.Parameters.AddWithValue("@FechaPago", DateTime.Now);  // Fecha actual
                        commandPago.Parameters.AddWithValue("@FechaVencimiento", DateTime.Now.AddMonths(1));  // Vencimiento en 1 mes

                        commandPago.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente y pago registrados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    txtGmail.Clear();
                    cbPlan.SelectedIndex = -1;
                    txtPrecio.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Método para cargar lista de clientes
        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            // Conexión a la base de datos
            string connectionString = "Server=DESKTOP-N2PIPNV\\SQLEXPRESS; Database=OLYMPUS10;User Id=sa;Password=mibichitodeluz;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para obtener los datos
                    string query = "SELECT Nombre, Apellido, Direccion, Telefono, FechaAlta, Gmail, Planes, Precio FROM Clientes";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    System.Data.DataTable table = new System.Data.DataTable();

                    adapter.Fill(table);

                    // Asignar los datos al DataGridView
                    dgvClientes.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la lista de clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para eliminar un cliente
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            // Verificar que el usuario seleccionó un cliente
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los valores seleccionados
            string nombre = dgvClientes.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? string.Empty;
            string apellido = dgvClientes.SelectedRows[0].Cells["Apellido"].Value?.ToString() ?? string.Empty;
            string direccion = dgvClientes.SelectedRows[0].Cells["Direccion"].Value?.ToString() ?? string.Empty;
            string telefono = dgvClientes.SelectedRows[0].Cells["Telefono"].Value?.ToString() ?? string.Empty;
            DateTime fechaAlta = dgvClientes.SelectedRows[0].Cells["FechaAlta"].Value == null
                ? DateTime.MinValue
                : Convert.ToDateTime(dgvClientes.SelectedRows[0].Cells["FechaAlta"].Value);
            string gmail = dgvClientes.SelectedRows[0].Cells["Gmail"].Value?.ToString() ?? string.Empty;
            string plan = dgvClientes.SelectedRows[0].Cells["Planes"].Value?.ToString() ?? string.Empty;
            decimal precio = dgvClientes.SelectedRows[0].Cells["Precio"].Value == null
                ? 0
                : Convert.ToDecimal(dgvClientes.SelectedRows[0].Cells["Precio"].Value);

            // Confirmar la eliminación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Conexión a la base de datos
            string connectionString = "Server=DESKTOP-N2PIPNV\\SQLEXPRESS; Database=OLYMPUS10;User Id=sa;Password=mibichitodeluz;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Eliminar cliente usando múltiples criterios
                    string query = "DELETE FROM Clientes WHERE Nombre = @Nombre AND Apellido = @Apellido AND Direccion = @Direccion " +
                                   "AND Telefono = @Telefono AND FechaAlta = @FechaAlta AND Gmail = @Gmail AND Planes = @Planes AND Precio = @Precio";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@FechaAlta", fechaAlta);
                        command.Parameters.AddWithValue("@Gmail", gmail);
                        command.Parameters.AddWithValue("@Planes", plan);
                        command.Parameters.AddWithValue("@Precio", precio);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refrescar la lista de clientes
                            btnListaClientes_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente para eliminar. Puede haber sido modificado por otro usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para manejar la selección de un cliente
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el Nombre y Apellido del cliente seleccionado
                selectedClienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
                string selectedClienteNombre = dgvClientes.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? string.Empty;
                string selectedClienteApellido = dgvClientes.SelectedRows[0].Cells["Apellido"].Value?.ToString() ?? string.Empty;

            }
        }
        // Método para cargar los pagos del cliente seleccionado
        private void CargarPagos(string clienteNombre, string clienteApellido)
        {
            string connectionString = "Server=DESKTOP-N2PIPNV\\SQLEXPRESS; Database=OLYMPUS10; User Id=sa; Password=mibichitodeluz;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para obtener los pagos y su estado utilizando el nombre y apellido
                    string query = "SELECT ClienteNombre, ClienteApellido, FechaPago, Monto, EstadoPago, FechaRenovacion " +
                                   "FROM Pagos WHERE ClienteNombre = @ClienteNombre AND ClienteApellido = @ClienteApellido";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ClienteNombre", clienteNombre);
                    adapter.SelectCommand.Parameters.AddWithValue("@ClienteApellido", clienteApellido);

                    System.Data.DataTable table = new System.Data.DataTable();
                    adapter.Fill(table);

                    // Asignar los datos al DataGridView de pagos
                    dgvPagos.DataSource = table;

                    // Lógica para determinar el estado de pago
                    foreach (DataGridViewRow row in dgvPagos.Rows)
                    {
                        DateTime fechaPago = row.Cells["FechaPago"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row.Cells["FechaPago"].Value);
                        DateTime fechaRenovacion = row.Cells["FechaRenovacion"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row.Cells["FechaRenovacion"].Value);
                        string estadoPago = "Pendiente";

                        // Comparar las fechas
                        if (fechaPago >= fechaRenovacion || fechaPago == DateTime.MinValue)
                        {
                            estadoPago = "Actualizado";
                        }

                        row.Cells["EstadoPago"].Value = estadoPago;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para registrar un pago para el cliente seleccionado
        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente para registrar el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el nombre y apellido del cliente seleccionado
            string nombreCliente = dgvClientes.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? string.Empty;
            string apellidoCliente = dgvClientes.SelectedRows[0].Cells["Apellido"].Value?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(apellidoCliente))
            {
                MessageBox.Show("El cliente seleccionado no tiene nombre o apellido. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el precio del nuevo plan (puede estar en el campo "Precio" del formulario de cliente)
            decimal montoPago = decimal.TryParse(txtPrecio.Text, out montoPago) ? montoPago : 0;

            string connectionString = "Server=DESKTOP-N2PIPNV\\SQLEXPRESS; Database=OLYMPUS10; User Id=sa; Password=mibichitodeluz;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insertar el pago de renovación
                    string query = "INSERT INTO Pagos (ClienteNombre, ClienteApellido, FechaPago, Monto, EstadoPago) " +
                                   "VALUES (@NombreCliente, @ApellidoCliente, @FechaPago, @Monto, 'Pendiente')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreCliente", nombreCliente);
                        command.Parameters.AddWithValue("@ApellidoCliente", apellidoCliente);
                        command.Parameters.AddWithValue("@FechaPago", DateTime.Now);  // Fecha actual de pago
                        command.Parameters.AddWithValue("@Monto", montoPago);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la lista de pagos después de registrar el nuevo pago
                    btnVerPagos_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para ver los pagos del cliente seleccionado
        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            // Conexión a la base de datos
            string connectionString = "Server=DESKTOP-N2PIPNV\\SQLEXPRESS; Database=OLYMPUS10; User Id=sa; Password=mibichitodeluz;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Verificar que se ha seleccionado un cliente
                if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un cliente para ver sus pagos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el nombre y apellido del cliente seleccionado
                string nombreCliente = dgvClientes.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? string.Empty;
                string apellidoCliente = dgvClientes.SelectedRows[0].Cells["Apellido"].Value?.ToString() ?? string.Empty;

                // Verificar que los valores no sean nulos o vacíos
                if (string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(apellidoCliente))
                {
                    MessageBox.Show("El cliente seleccionado no tiene nombre o apellido. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    connection.Open();

                    // Consulta para obtener los pagos del cliente seleccionado
                    string query = "SELECT ClienteNombre, ClienteApellido, FechaPago, Monto, EstadoPago, FechaRenovacion " +
                                   "FROM Pagos WHERE ClienteNombre = @ClienteNombre AND ClienteApellido = @ClienteApellido";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ClienteNombre", nombreCliente);
                    adapter.SelectCommand.Parameters.AddWithValue("@ClienteApellido", apellidoCliente);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Asignar los datos al DataGridView de pagos
                    dgvPagos.DataSource = table;

                    // Lógica para calcular y mostrar la próxima fecha de renovación
                    foreach (DataGridViewRow row in dgvPagos.Rows)
                    {
                        DateTime fechaPago = row.Cells["FechaPago"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row.Cells["FechaPago"].Value);
                        DateTime fechaRenovacion = row.Cells["FechaRenovacion"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row.Cells["FechaRenovacion"].Value);

                        // Si la fecha de renovación está vacía, calculamos la próxima fecha de renovación
                        if (fechaRenovacion == DateTime.MinValue && fechaPago != DateTime.MinValue)
                        {
                            // Calculamos la próxima fecha de renovación (por ejemplo, un mes después de la fecha de pago)
                            fechaRenovacion = fechaPago.AddMonths(1);
                        }

                        // Asignar la fecha de renovación calculada al DataGridView
                        row.Cells["FechaRenovacion"].Value = fechaRenovacion.ToString("yyyy-MM-dd");

                        // Aquí puedes agregar la lógica de estado de pago
                        string estadoPago = "Pendiente";
                        if (fechaPago >= fechaRenovacion || fechaPago == DateTime.MinValue)
                        {
                            estadoPago = "Actualizado";
                        }
                        row.Cells["EstadoPago"].Value = estadoPago;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}