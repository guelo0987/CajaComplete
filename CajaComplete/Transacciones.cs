using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CajaComplete
{
    public partial class Transacciones : Form
    {
        public Transacciones()
        {
            InitializeComponent();
        }

        private void Transacciones_Load(object sender, EventArgs e)
        {
            CargarServicios();
            MostrarTransacciones(); // Mostrar todas las transacciones por defecto
        }

        private void CargarServicios()
        {
            // Cargar los tipos de servicios en el ComboBox
            comboBox1.Items.Add("Todos"); // Opción por defecto
            comboBox1.Items.Add("Corte de pelo");
            comboBox1.Items.Add("Spa");
            comboBox1.Items.Add("Emergencia");

            comboBox1.SelectedIndex = 0; // Seleccionar "Todos" por defecto
        }

        private void MostrarTransacciones(string servicio = "Todos", DateTime? fecha = null)
        {
            try
            {
                listBox1.Items.Clear(); // Limpiar el ListBox

                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();

                    // Crear la consulta SQL
                    string query = @"
                        SELECT B.bill_id, C.full_name AS Cliente, B.amount_due, B.created_at, 
                               CASE 
                                   WHEN B.amount_due = 500 THEN 'Corte de pelo'
                                   WHEN B.amount_due = 399 THEN 'Spa'
                                   WHEN B.amount_due = 1000 THEN 'Emergencia'
                                   ELSE 'Otro'
                               END AS Servicio
                        FROM Bills B
                        JOIN Clients C ON B.client_id = C.client_id
                        WHERE (CASE 
                                   WHEN B.amount_due = 500 THEN 'Corte de pelo'
                                   WHEN B.amount_due = 399 THEN 'Spa'
                                   WHEN B.amount_due = 1000 THEN 'Emergencia'
                                   ELSE 'Otro'
                               END = @servicio OR @servicio = 'Todos')
                          AND (CAST(B.created_at AS DATE) = @fecha OR @fecha IS NULL)
                        ORDER BY B.created_at DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@servicio", servicio);
                        command.Parameters.AddWithValue("@fecha", fecha.HasValue ? fecha.Value.ToString("yyyy-MM-dd") : DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string transaccion = $"ID: {reader["bill_id"]}, Cliente: {reader["Cliente"]}, Servicio: {reader["Servicio"]}, Monto: ${reader["amount_due"]}, Fecha: {reader["created_at"]}";
                                listBox1.Items.Add(transaccion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar transacciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filtrar por servicio al cambiar la selección en el ComboBox
            string servicio = comboBox1.SelectedItem.ToString();
            DateTime? fecha = dateTimePicker1.Value.Date;

            MostrarTransacciones(servicio, fecha);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Filtrar por fecha al cambiar el valor en el DateTimePicker
            string servicio = comboBox1.SelectedItem?.ToString() ?? "Todos";
            DateTime? fecha = dateTimePicker1.Value.Date;

            MostrarTransacciones(servicio, fecha);
        }
    }
}
