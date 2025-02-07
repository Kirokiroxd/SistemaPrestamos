using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPrestamos.Formularios;


namespace SistemaPrestamos
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes clientesForm = new FrmClientes();
            clientesForm.Show();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            FrmCuentas cuentasForm = new FrmCuentas();
            cuentasForm.Show();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            FrmPrestamos prestamosForm = new FrmPrestamos();
            prestamosForm.Show();
        }
    }
}
