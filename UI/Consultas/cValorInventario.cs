using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntregaParcialUno.BLL;
using EntregaParcialUno.Entidades;

namespace EntregaParcialUno.UI.Consultas
{
    public partial class cValorInventario : Form
    {
        int id = 1;
        public cValorInventario()
        {
            InitializeComponent();
        }

        private void ActualizarButton_Click(object sender, EventArgs e)
        {

            ValorInventario valorinventario = new ValorInventario();
            bool paso = false;

            valorinventario = ValorInventarioBLL.Buscar(id);
            if (valorinventario == null)
            {

                valorinventario = LlenaClase();
                paso = ValorInventarioBLL.Guardar(valorinventario);
     
            }
            else
            {

                valorinventario = LlenaClase();
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No actualizado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = ValorInventarioBLL.Modificar(valorinventario);


            }
            MostrarInventario();

        }

        private void LlenaCampo(ValorInventario valorinventario)
        {

            ValorTotalInvetarioTextBox.Text = Convert.ToString(valorinventario.ValorTotalInventario);

        }

        private decimal CalculodeInventario()
        {
            decimal resultado =0;
            int contador = 1;

            Productos producto = new Productos();
            while (producto != null)
            {

                producto = ProductosBLL.Buscar(contador);


                if (producto != null)
                {
                    resultado = resultado + producto.ValorInventario;

                }
                else
                {
                    break;
                }
                contador++;
            }
            return resultado;
            
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            ValorInventario valorinventario = ValorInventarioBLL.Buscar(1);
            return (valorinventario != null);

        }

        private void MostrarInventario()
        {
            string d = "1";

            int.TryParse(d, out id);

            ValorInventario valorinventario = new ValorInventario();
            valorinventario = ValorInventarioBLL.Buscar(id);

            if (valorinventario != null)
            {
                MessageBox.Show("Inventario Actualizado");
                LlenaCampo(valorinventario);

            }
            else
            {
                MessageBox.Show("No actualizasdo");
            }

        }

    

        public ValorInventario LlenaClase()
        {
            ValorInventario valorInventario = new ValorInventario();
            valorInventario.ValorTotalInventario = CalculodeInventario();
            valorInventario.ValorInventarioId = id;

            return valorInventario;
        }

        private void ValorTotalInvetarioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
