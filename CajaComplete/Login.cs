using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CajaComplete
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = username.Text.Trim();
            string pass = password.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Por favor, ingresa tu nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                username.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, ingresa tu contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                password.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();
                    string query = @"
                SELECT user_id, username
                FROM Users
                WHERE username = @username
                AND password_hash = @password
                AND is_active = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", user);
                        command.Parameters.AddWithValue("@password", pass);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["user_id"]);
                                string userName = reader["username"].ToString();

                                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Pasar datos al formulario principal
                                this.Hide();
                                Main mainForm = new Main(userId, userName);
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, verifica tus credenciales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                password.Clear();
                                password.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool ValidateLogin(string username, string password)
        {
            try
            {
                using (SqlConnection connection = Conex.GetConnection()) // Usando tu clase `Conex` para la conexión
                {
                    connection.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Users 
                        WHERE username = @username 
                        AND password_hash =  @password
                        AND is_active = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int result = Convert.ToInt32(command.ExecuteScalar());
                        return result > 0; // Si hay al menos un resultado, el login es válido
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
