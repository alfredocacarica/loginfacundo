using System;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MiAplicacion
{
    public partial class RegisterForm : Form
    {
        private string cadenaConexion;

        public RegisterForm()
        {
            InitializeComponent();
            
            cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\login.accdb";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            
            if (!ValidarEmail(email))
            {
                MessageBox.Show("Por favor, ingrese un email válido.");
                return;
            }

            
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
                using (OleDbConnection cnn = new OleDbConnection(cadenaConexion))
                {
                    cnn.Open();
                    string query = "INSERT INTO Usuarios (Nombre, Email, Contraseña) VALUES (@Nombre, @Email, @Contraseña)";
                    using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Contraseña", password);
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
