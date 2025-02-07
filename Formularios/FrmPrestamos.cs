using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPrestamos.Controladores;
using SistemaPrestamos.Modelos;

namespace SistemaPrestamos.Formularios
{
    public partial class FrmPrestamos : Form
    {
        public FrmPrestamos()
        {
            InitializeComponent();
            CargarClientes();
            CargarPrestamos();
        }

        private void CargarClientes()
        {
            cmbClientes.DataSource = ClienteController.ObtenerClientes();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "ID";
        }

        private void CargarPrestamos()
        {
            dataGridViewPrestamos.DataSource = PrestamoController.ObtenerPrestamos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue is int idCliente &&
                decimal.TryParse(txtMonto.Text, out decimal monto) &&
                decimal.TryParse(txtInteres.Text, out decimal interes) &&
                int.TryParse(txtPlazo.Text, out int plazo))
            {
                Prestamo nuevoPrestamo = new Prestamo
                {
                    ID_Cliente = idCliente,
                    Monto = monto,
                    Interes = interes,
                    Plazo = plazo
                };

                if (PrestamoController.AgregarPrestamo(nuevoPrestamo))
                {
                    MessageBox.Show("Préstamo agregado con éxito.");
                    CargarPrestamos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el préstamo.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa valores válidos.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int idPrestamo) &&
                decimal.TryParse(txtMonto.Text, out decimal monto) &&
                decimal.TryParse(txtInteres.Text, out decimal interes) &&
                int.TryParse(txtPlazo.Text, out int plazo))
            {
                Prestamo prestamoEditado = new Prestamo
                {
                    ID = idPrestamo,
                    ID_Cliente = (int)cmbClientes.SelectedValue,
                    Monto = monto,
                    Interes = interes,
                    Plazo = plazo
                };

                if (PrestamoController.ActualizarPrestamo(prestamoEditado))
                {
                    MessageBox.Show("Préstamo actualizado con éxito.");
                    CargarPrestamos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el préstamo.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un préstamo válido.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int idPrestamo))
            {
                var confirmacion = MessageBox.Show("¿Estás seguro de eliminar este préstamo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    if (PrestamoController.EliminarPrestamo(idPrestamo))
                    {
                        MessageBox.Show("Préstamo eliminado con éxito.");
                        CargarPrestamos();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el préstamo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un préstamo válido.");
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtMonto.Clear();
            txtInteres.Clear();
            txtPlazo.Clear();
            cmbClientes.SelectedIndex = -1;
        }

        private void dataGridViewPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewPrestamos.Rows[e.RowIndex];
                txtID.Text = fila.Cells["ID"].Value.ToString();
                txtMonto.Text = fila.Cells["Monto"].Value.ToString();
                txtInteres.Text = fila.Cells["Interes"].Value.ToString();
                txtPlazo.Text = fila.Cells["Plazo"].Value.ToString();
                cmbClientes.SelectedValue = fila.Cells["ID_Cliente"].Value;
            }
        }
    }
}
