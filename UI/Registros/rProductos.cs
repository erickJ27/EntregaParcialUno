using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntregaParcialUno.Entidades;
using EntregaParcialUno.BLL;

namespace EntregaParcialUno.UI.Registros
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaNumericUpDown.Value = 0;
            CostoNumericUpDown.Value = 0;
            ValorInventarioTextBox.Text = string.Empty;

        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Productos LlenarClase()
        {

            Productos producto = new Productos();
            producto.Id = (int)IdNumericUpDown.Value;
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Existencia =(int)ExistenciaNumericUpDown.Value; ;
            producto.Costo = CostoNumericUpDown.Value;
            producto.ValorInventario = Convert.ToDecimal(ValorInventarioTextBox.Text);
            return producto;

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Productos productos = ProductosBLL.Buscar((int)IdNumericUpDown.Value);
            return (productos != null);

        }
        private bool validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (DescripcionTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripcionTextBox, "El campo Descripcion no puede estar vacio");
                DescripcionTextBox.Focus();
                paso = false;
            }
           
            if(ExistenciaNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(ExistenciaNumericUpDown, "El campo Existencia no puede estar en 0");
                ExistenciaNumericUpDown.Focus();
                paso = false;
            }
            if (CostoNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CostoNumericUpDown, "El campo Existencia no puede estar en 0");
                CostoNumericUpDown.Focus();
                paso = false;
            }
            
            return paso;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos productos;
            bool paso = false;

            if (!validar())
                return;

            productos = LlenarClase();
            Limpiar();

            if (IdNumericUpDown.Value == 0)
                paso = ProductosBLL.Guardar(productos);
            else
            {
            if(!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede modificar un usuario que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            paso = ProductosBLL.Modificar(productos);

            }

            if(paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un usuario que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();



            if (ProductosBLL.Eliminar(id))

                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else

                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar un usuario que no existe");


        }
        private void LlenarCampo(Productos productos)
        {

            IdNumericUpDown.Value = productos.Id;
            DescripcionTextBox.Text = productos.Descripcion;
            ExistenciaNumericUpDown.Value = productos.Existencia;


        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Productos producto = new Productos();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            producto = ProductosBLL.Buscar(id);

            if (producto != null)
            {
                MessageBox.Show("Usuario Encontrado");
                LlenarCampo(producto);
            }
            else
            MessageBox.Show("Usuario no encontrado");

        }
        private void CalcularValor()
        {
            if(CostoNumericUpDown.Value >0 && ExistenciaNumericUpDown.Value > 0)
            {
                ValorInventarioTextBox.Text = Convert.ToString(CostoNumericUpDown.Value * ExistenciaNumericUpDown.Value);
    }
}

        private void ValorInventarioTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }

        private void CostoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularValor();
        }


    }
}
