using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CajaComplete
{
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            // Cargar clientes y servicios al cargar el formulario
            CargarClientes();
            CargarServicios();

            // Mostrar el nombre de la sucursal 1
            label2.Text = "Sucursal Central"; // Puedes obtenerlo desde la base de datos si es necesario
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT client_id, full_name, document_id FROM Clients ORDER BY full_name ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(new ComboBoxItem
                                {
                                    Text = $"{reader["full_name"]} ({reader["document_id"]})",
                                    Value = Convert.ToInt32(reader["client_id"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarServicios()
        {
            comboBox2.Items.Add(new ComboBoxItem { Text = "Corte de pelo", Value = 500 });
            comboBox2.Items.Add(new ComboBoxItem { Text = "Spa", Value = 399 });
            comboBox2.Items.Add(new ComboBoxItem { Text = "Emergencia", Value = 1000 });
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar el precio del servicio seleccionado en el label4
            var selectedService = comboBox2.SelectedItem as ComboBoxItem;
            if (selectedService != null)
            {
                label4.Text = $"${selectedService.Value}";
                textBox5.Text = selectedService.Value.ToString(); // También actualiza el monto a pagar
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cliente = comboBox1.SelectedItem as ComboBoxItem;
            var servicio = comboBox2.SelectedItem as ComboBoxItem;

            if (cliente == null || servicio == null || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Por favor, selecciona un cliente, servicio y asegúrate de ingresar el monto recibido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal amountDue = Convert.ToDecimal(servicio.Value);
            decimal amountPaid;

            if (!decimal.TryParse(textBox5.Text, out amountPaid) || amountPaid < amountDue)
            {
                MessageBox.Show("El monto recibido es insuficiente o inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int billId;

                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();

                    // Insertar factura en Bills y obtener el ID generado
                    string insertBill = @"
                        INSERT INTO Bills (client_id, branch_id, amount_due, amount_paid, is_paid, created_at)
                        OUTPUT INSERTED.bill_id
                        VALUES (@client_id, @branch_id, @amount_due, @amount_paid, 1, GETDATE());
                    ";

                    using (SqlCommand command = new SqlCommand(insertBill, connection))
                    {
                        command.Parameters.AddWithValue("@client_id", cliente.Value);
                        command.Parameters.AddWithValue("@branch_id", 1); // Sucursal fija
                        command.Parameters.AddWithValue("@amount_due", amountDue);
                        command.Parameters.AddWithValue("@amount_paid", amountPaid);

                        billId = (int)command.ExecuteScalar();
                    }
                }

                // Generar el PDF con los detalles de la factura
                GenerarPDF(cliente.Text, servicio.Text, amountDue, amountPaid, billId);

                MessageBox.Show("Factura registrada y PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPDF(string cliente, string servicio, decimal amountDue, decimal amountPaid, int billId)
        {
            try
            {
                string filePath = $"Factura_{billId}.pdf";

                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    var document = new Document();
                    var writer = PdfWriter.GetInstance(document, stream);

                    document.Open();

                    // Título
                    var titleFont = FontFactory.GetFont("Arial", "16", Font.Bold);
                    var title = new Paragraph("Factura Digital\n", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    document.Add(title);

                    document.Add(new Paragraph("\n"));

                    // Detalles del cliente
                    var font = FontFactory.GetFont("Arial", 12);
                    document.Add(new Paragraph($"Factura ID: {billId}", font));
                    document.Add(new Paragraph($"Cliente: {cliente}", font));
                    document.Add(new Paragraph($"Servicio: {servicio}", font));
                    document.Add(new Paragraph($"Monto a Pagar: ${amountDue}", font));
                    document.Add(new Paragraph($"Monto Recibido: ${amountPaid}", font));
                    document.Add(new Paragraph($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", font));

                    document.Close();
                    writer.Close();
                }

                MessageBox.Show($"PDF generado: {filePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Clase para los elementos del ComboBox
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
