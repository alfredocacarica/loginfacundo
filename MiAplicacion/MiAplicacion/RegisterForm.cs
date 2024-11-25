using System;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace MiAplicacion
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Validar email
            if (!ValidarEmail(email))
            {
                MessageBox.Show("Por favor, ingrese un email válido.");
                return;
            }

            // Registrar usuario
            if (RegistrarUsuario(username, email, password))
            {
                MessageBox.Show("Usuario registrado con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario.");
            }
        }

        private bool ValidarEmail(string email)
        {
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patronEmail);
        }

        private bool RegistrarUsuario(string username, string email, string password)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection("ConnectionString"))
                {
                    cnn.Open();
                    string query = "INSERT INTO Usuarios (Username, Email, Contraseña) VALUES (@Username, @Email, @Password)";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
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
