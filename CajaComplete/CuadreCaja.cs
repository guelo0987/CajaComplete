using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CajaComplete
{
    public partial class CuadreCaja : Form
    {
        private int userId; // ID del usuario que hizo login
        private string userName; // Nombre del usuario que hizo login

        public CuadreCaja(int loggedInUserId, string loggedInUserName)
        {
            InitializeComponent();
            userId = loggedInUserId;
            userName = loggedInUserName;
        }

        private void CuadreCaja_Load(object sender, EventArgs e)
        {
            // Mostrar fecha actual
            label4.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Mostrar monto inicial fijo
            label5.Text = "$10,000";

            // Mostrar datos del cajero y sucursal
            label7.Text = userName;
            label9.Text = "Sucursal Central";

            // Calcular y mostrar entrada, salida y total
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal totalIn = 0;
            decimal totalOut = 0;
            decimal closingAmount = 0;
            decimal initialAmount = 10000; // Monto inicial fijo

            try
            {
                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();

                    // Obtener total de entrada del día actual
                    string queryIn = @"SELECT ISNULL(SUM(amount), 0) AS TotalIn
                                        FROM Cash_Transactions
                                        WHERE transaction_type = 'IN' AND CAST(created_at AS DATE) = CAST(GETDATE() AS DATE);";

                    using (SqlCommand command = new SqlCommand(queryIn, connection))
                    {
                        totalIn = Convert.ToDecimal(command.ExecuteScalar());
                    }

                    // Obtener total de salida del día actual
                    string queryOut = @"SELECT ISNULL(SUM(amount), 0) AS TotalOut
                                         FROM Cash_Transactions
                                         WHERE transaction_type = 'OUT' AND CAST(created_at AS DATE) = CAST(GETDATE() AS DATE);";

                    using (SqlCommand command = new SqlCommand(queryOut, connection))
                    {
                        totalOut = Convert.ToDecimal(command.ExecuteScalar());
                    }

                    // Calcular el monto de cierre
                    closingAmount = initialAmount + totalIn - totalOut;

                    // Actualizar los labels
                    label10.Text = totalIn.ToString("C");
                    label12.Text = totalOut.ToString("C");
                    label15.Text = closingAmount.ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular los totales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalIn = decimal.Parse(label10.Text, System.Globalization.NumberStyles.Currency);
            decimal totalOut = decimal.Parse(label12.Text, System.Globalization.NumberStyles.Currency);
            decimal closingAmount = decimal.Parse(label15.Text, System.Globalization.NumberStyles.Currency);
            decimal initialAmount = 10000; // Monto inicial fijo

            try
            {
                using (SqlConnection connection = Conex.GetConnection())
                {
                    connection.Open();

                    // Insertar en Cash_Daily
                    string insertDaily = @"INSERT INTO Cash_Daily (user_id, branch_id, date, initial_amount, total_in, total_out, closing_amount, is_closed)
                                            VALUES (@user_id, @branch_id, CAST(GETDATE() AS DATE), @initial_amount, @total_in, @total_out, @closing_amount, 1);";

                    using (SqlCommand command = new SqlCommand(insertDaily, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", userId);
                        command.Parameters.AddWithValue("@branch_id", 1); // Sucursal fija
                        command.Parameters.AddWithValue("@initial_amount", initialAmount);
                        command.Parameters.AddWithValue("@total_in", totalIn);
                        command.Parameters.AddWithValue("@total_out", totalOut);
                        command.Parameters.AddWithValue("@closing_amount", closingAmount);

                        command.ExecuteNonQuery();
                    }
                }

                // Generar el reporte en PDF
                GenerarReportePDF(initialAmount, totalIn, totalOut, closingAmount);

                MessageBox.Show("Cuadre realizado y reporte generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el cuadre de caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReportePDF(decimal initialAmount, decimal totalIn, decimal totalOut, decimal closingAmount)
        {
            try
            {
                string filePath = $"CuadreCaja_{DateTime.Now:yyyyMMdd}.pdf";

                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    var document = new Document();
                    var writer = PdfWriter.GetInstance(document, stream);

                    document.Open();

                    // Título del reporte
                    var titleFont = FontFactory.GetFont("Arial", "16", Font.Bold);
                    var title = new Paragraph("Reporte de Cuadre de Caja\n", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    document.Add(title);

                    document.Add(new Paragraph("\n"));

                    // Detalles del cuadre
                    var font = FontFactory.GetFont("Arial", 12);
                    document.Add(new Paragraph($"Fecha: {DateTime.Now:yyyy-MM-dd}", font));
                    document.Add(new Paragraph($"Cajero: {userName}", font));
                    document.Add(new Paragraph($"Sucursal: {label9.Text}\n", font));

                    document.Add(new Paragraph($"Monto Inicial: {initialAmount:C}", font));
                    document.Add(new Paragraph($"Entradas: {totalIn:C}", font));
                    document.Add(new Paragraph($"Salidas: {totalOut:C}", font));
                    document.Add(new Paragraph($"Monto de Cierre: {closingAmount:C}\n", font));

                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("Reporte generado automáticamente.", font));

                    document.Close();
                    writer.Close();
                }

                MessageBox.Show($"Reporte generado: {filePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
