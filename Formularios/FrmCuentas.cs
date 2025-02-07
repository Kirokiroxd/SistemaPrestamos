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
    public partial class FrmCuentas : Form
    {
        public FrmCuentas()
        {
            InitializeComponent();
            CargarClientes();
            CargarCuentas();
        }

        private void CargarClientes()
        {
            cmbClientes.DataSource = ClienteController.ObtenerClientes();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "ID";
        }

        private void CargarCuentas()
        {
            dataGridViewCuentas.DataSource = CuentaController.ObtenerCuentas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue is int idCliente && decimal.TryParse(txtSaldo.Text, out decimal saldo))
            {
                Cuenta nuevaCuenta = new Cuenta
                {
                    ID_Cliente = idCliente,
                    Saldo = saldo
                };

                if (CuentaController.AgregarCuenta(nuevaCuenta))
                {
                    MessageBox.Show("Cuenta agregada con éxito.");
                    CargarCuentas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar la cuenta.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente válido y proporciona un saldo correcto.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int idCuenta) && decimal.TryParse(txtSaldo.Text, out decimal saldo))
            {
                Cuenta cuentaEditada = new Cuenta
                {
                    ID = idCuenta,
                    ID_Cliente = (int)cmbClientes.SelectedValue,
                    Saldo = saldo
                };

                if (CuentaController.ActualizarCuenta(cuentaEditada))
                {
                    MessageBox.Show("Cuenta actualizada con éxito.");
                    CargarCuentas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la cuenta.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int idCuenta))
            {
                var confirmacion = MessageBox.Show("¿Estás seguro de eliminar esta cuenta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    if (CuentaController.EliminarCuenta(idCuenta))
                    {
                        MessageBox.Show("Cuenta eliminada con éxito.");
                        CargarCuentas();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la cuenta.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una cuenta válida.");
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtSaldo.Clear();
            cmbClientes.SelectedIndex = -1;
        }

        private void dataGridViewCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewCuentas.Rows[e.RowIndex];
                txtID.Text = fila.Cells["ID"].Value.ToString();
                txtSaldo.Text = fila.Cells["Saldo"].Value.ToString();
                cmbClientes.SelectedValue = fila.Cells["ID_Cliente"].Value;
            }
        }
    }
}
