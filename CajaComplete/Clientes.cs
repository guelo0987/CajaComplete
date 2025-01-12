using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CajaComplete
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            // Llamar al método para cargar los clientes
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                // Usar la conexión desde la clase Conex
                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();
                    // Consulta SQL con orden alfabético
                    string query = "SELECT client_id, full_name, document_id, phone_number, email FROM Clients ORDER BY full_name ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Construir el texto a mostrar en el ListBox
                                string cliente = $"ID: {reader["client_id"]} | Nombre: {reader["full_name"]} | " +
                                                 $"Documento: {reader["document_id"]} | Teléfono: {reader["phone_number"]} | " +
                                                 $"Email: {reader["email"]}";

                                // Agregar al ListBox
                                listBox1.Items.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si ocurre algún error
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
