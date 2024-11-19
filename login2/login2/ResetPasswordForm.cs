using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace login2
{
    public partial class ResetPasswordForm : Form
    {
        private string cadenaConexion;

        public ResetPasswordForm(string conexion)
        {
            InitializeComponent();
            cadenaConexion = conexion;
            txtCode.Enabled = false; // Deshabilitar el TextBox de código inicialmente
        }

        

        private void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string code = txtCode.Text;
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (code != "123456")
            {
                MessageBox.Show("Código incorrecto.");
                return;
            }

            if (!ValidarEmail(email))
            {
                MessageBox.Show("El email no existe en la base de datos.");
                return;
            }

            if (ActualizarContraseña(email, newPassword))
            {
                MessageBox.Show("Contraseña actualizada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la contraseña.");
            }
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(cadenaConexion))
                {
                    cnn.Open();
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE Email = @Email";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)cmd.ExecuteScalar();
                        return count == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el email: {ex.Message}");
                return false;
            }
        }

        private bool ActualizarContraseña(string email, string nuevaContraseña)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(cadenaConexion))
                {
                    cnn.Open();
                    string query = "UPDATE Usuarios SET Contraseña = @NuevaContraseña WHERE Email = @Email";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@NuevaContraseña", nuevaContraseña);
                        cmd.Parameters.AddWithValue("@Email", email);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la contraseña: {ex.Message}");
                return false;
            }
        }

        private void btnVerificarEmail_Click(object sender, EventArgs e)
        {
            {
                string email = txtEmail.Text;

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Por favor, ingrese su email.");
                    return;
                }

                if (ValidarEmail(email))
                {
                    txtCode.Enabled = true; // Habilitar el TextBox de código
                    MessageBox.Show("Email verificado, ahora puede ingresar el código.");
                }
                else
                {
                    MessageBox.Show("El email no existe en la base de datos.");
                }
            }
        }
    }
}
