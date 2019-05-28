using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntregaParcialUno.UI.Registros;
using EntregaParcialUno.UI.Consultas;

namespace EntregaParcialUno
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos productos = new rProductos();
            productos.Show();
        }

        private void TotalInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cValorInventario valor = new cValorInventario();
            valor.Show();
        }
    }
}
