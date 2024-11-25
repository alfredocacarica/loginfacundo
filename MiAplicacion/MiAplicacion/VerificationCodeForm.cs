using System;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MiAplicacion
{
    public partial class VerificationCodeForm : Form
    {
        private readonly string expectedCode = "123456"; // Código esperado

        public bool IsVerified { get; private set; } = false; // Indica si la verificación fue exitosa

        public VerificationCodeForm()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string inputCode = txtCode.Text;

            if (inputCode == expectedCode)
            {
                MessageBox.Show("Código correcto.");
                IsVerified = true;
                this.Close(); // Cerrar el formulario
            }
            else
            {
                MessageBox.Show("Código incorrecto. Intente de nuevo.");
            }
        }
    }
}
