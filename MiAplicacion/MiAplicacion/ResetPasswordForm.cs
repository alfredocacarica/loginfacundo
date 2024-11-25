using System;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MiAplicacion
{
    public partial class ResetPasswordForm : Form
    {
        private string cadenaConexion;

        public ResetPasswordForm(string conexion)
        {
            InitializeComponent();
            cadenaConexion = conexion;
            txtCode.Enabled = false;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string newPassword = txtNewPassword.Text;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Actualizar contraseña
            if (ActualizarContraseña(email, newPassword))
            {
                MessageBox.Show("Contraseña actualizada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la contraseña. Verifique que el email exista.");
            }
        }

        private bool ActualizarContraseña(string email, string newPassword)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(cadenaConexion))
                {
                    cnn.Open();
                    string query = "UPDATE Usuarios SET Contraseña = @Password WHERE Email = @Email";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@Email", email);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
