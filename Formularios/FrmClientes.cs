using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPrestamos.Modelos;
using SistemaPrestamos.Controladores;

namespace SistemaPrestamos.Formularios
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            dataGridViewClientes.DataSource = ClienteController.ObtenerClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text
            };

            if (ClienteController.AgregarCliente(nuevoCliente))
            {
                MessageBox.Show("Cliente agregado con éxito.");
                CargarClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el cliente.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                Cliente clienteEditado = new Cliente
                {
                    ID = id,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text
                };

                if (ClienteController.ActualizarCliente(clienteEditado))
                {
                    MessageBox.Show("Cliente actualizado con éxito.");
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cliente.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                if (ClienteController.EliminarCliente(id))
                {
                    MessageBox.Show("Cliente eliminado con éxito.");
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.");
                }
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewClientes.Rows[e.RowIndex];
                txtID.Text = fila.Cells["ID"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            }
        }
    }
}
