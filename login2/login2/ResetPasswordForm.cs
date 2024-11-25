using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace login2
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Validar formato de email
            if (!ValidarFormatoEmail(email))
            {
                MessageBox.Show("Por favor, ingrese un email válido.");
                return;
            }

            // Registrar el usuario
            if (RegistrarUsuario(email, username, password))
            {
                MessageBox.Show("Registro exitoso.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario. Por favor, intente nuevamente.");
            }
        }

        private bool ValidarFormatoEmail(string email)
        {
            try
            {
                var emailValidator = new System.Net.Mail.MailAddress(email);
                return emailValidator.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool RegistrarUsuario(string email, string username, string password)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection("TU_CONEXION_AQUI"))
                {
                    cnn.Open();
                    string query = "INSERT INTO Usuarios (Email, Username, Contraseña) VALUES (@Email, @Username, @Password)";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}
