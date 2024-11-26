using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MiAplicacion
{
    public partial class LoginForm : Form
    {
        private string cadenaConexion;

        public LoginForm()
        {
            InitializeComponent();
            // Construir la cadena de conexión usando |DataDirectory|
            cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\login.accdb";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Validar inicio de sesión
            if (ValidarCredenciales(email, password))
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                // Aquí podrías redirigir a otra ventana
            }
            else
            {
                MessageBox.Show("Email o contraseña incorrectos.");
            }
        }

        private bool ValidarCredenciales(string email, string password)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(cadenaConexion))
                {
                    cnn.Open();
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE Email = @Email AND Contraseña = @Password";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        int count = (int)cmd.ExecuteScalar();
                        return count == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar credenciales: {ex.Message}");
                return false;
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abrir el formulario ResetPasswordForm pasando la cadena de conexión
            ResetPasswordForm resetForm = new ResetPasswordForm(cadenaConexion);
            resetForm.Show();
        }
    }
}
