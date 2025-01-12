using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CajaComplete
{
    public partial class AddCliente : Form
    {
        public AddCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar los campos
            string nombre = textBox1.Text.Trim();
            string email = textBox3.Text.Trim();
            string documento = textBox2.Text.Trim();
            string phone = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("El documento es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();

                    // Consulta para insertar el cliente
                    string query = @"
                        INSERT INTO Clients (full_name, document_id, phone_number, email)
                        VALUES (@full_name, @document_id, @phone_number, @email);
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@full_name", nombre);
                        command.Parameters.AddWithValue("@document_id", documento);
                        command.Parameters.AddWithValue("@phone_number", string.IsNullOrEmpty(phone) ? DBNull.Value : phone);
                        command.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? DBNull.Value : email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }
    }
}
