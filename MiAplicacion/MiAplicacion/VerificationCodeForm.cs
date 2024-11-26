using System;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MiAplicacion
{
    public partial class VerificationCodeForm : Form
    {
        public bool IsCodeValid { get; private set; } = false;

        public VerificationCodeForm()
        {
            InitializeComponent();
            txtCode.Enabled = false; // Deshabilitar el TextBox al inicio
        }

        private void btnEnableCode_Click(object sender, EventArgs e)
        {
            txtCode.Enabled = true; // Habilitar el TextBox cuando sea necesario
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "123456")
            {
                IsCodeValid = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Código incorrecto. Intente de nuevo.");
                IsCodeValid = false;
            }
        }
    }
}
