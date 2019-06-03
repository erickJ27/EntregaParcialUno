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
    public partial class rUbicacion : Form
    {
        public rUbicacion()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Ubicacion LlenarClase()
        {
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.Id = (int)IdNumericUpDown.Value;
            ubicacion.Descripcion = DescripcionTextBox.Text;
            return ubicacion;
        }

        private bool ExistenteEnLaBaseDeDatos()
        {
            Ubicacion ubicacion = UbicacionBLL.Buscar((int)IdNumericUpDown.Value);
            return (ubicacion != null);
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

            

            return paso;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacion;
            bool paso = false;

            if (!validar())
                return;

            ubicacion = LlenarClase();
            Limpiar();

            if (IdNumericUpDown.Value == 0)
                paso = UbicacionBLL.Guardar(ubicacion);
            else
            {
                if (!ExistenteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una ubicacion que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UbicacionBLL.Modificar(ubicacion);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (!ExistenteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un usuario que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();



            if (UbicacionBLL.Eliminar(id))

                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else

                MyErrorProvider.SetError(IdNumericUpDown, "No se puede eliminar un usuario que no existe");


        }
        private void LlenarCampo(Ubicacion ubicacion)
        {
            IdNumericUpDown.Value = ubicacion.Id;
            DescripcionTextBox.Text = ubicacion.Descripcion;
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Ubicacion ubicacion = new Ubicacion();
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            ubicacion = UbicacionBLL.Buscar(id);

            if (ubicacion != null)
            {
                MessageBox.Show("Ubicacion Encontrado");
                LlenarCampo(ubicacion);
            }
            else
                MessageBox.Show("Ubicacion no encontrado");
        }
    }
}
