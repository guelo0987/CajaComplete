using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaComplete
{
    public partial class Main : Form
    {

        private int userId;
        private string userName;
        public Main(int userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Clientes
            Clientes formClientes = new Clientes();

            // Mostrar el formulario Clientes como modal
            formClientes.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factura formFactura = new Factura(userId,userName);

            formFactura.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transacciones formTransacciones = new Transacciones();
            formTransacciones.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddCliente formAddCliente = new AddCliente();
            formAddCliente.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CuadreCaja formCuadreCaja = new CuadreCaja(userId,userName);
            formCuadreCaja.ShowDialog();
        }
    }
}
