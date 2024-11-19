using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login2
{
    public partial class login : Form
    {
        private string cadenaConexion; 
        private OleDbConnection cnn;

        public login()
        {
            InitializeComponent();
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\login.accdb";

         
        }

        private void LinkLabelReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Crear una instancia del formulario de restablecimiento de contraseña
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm(cadenaConexion);
            // Mostrar el formulario de restablecimiento
            resetPasswordForm.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtNombre.Text; 
            string contraseña = txtContraseña.Text;
            if (ValidarCredenciales(usuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private bool ValidarCredenciales(string usuario, string contraseña)
        {
            try
            {
                cnn = new OleDbConnection(cadenaConexion); cnn.Open();
                string query = "SELECT COUNT(1) FROM Usuarios WHERE Nombre = @Usuario AND Contraseña = @Contraseña";
                using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                    int count = (int)cmd.ExecuteScalar(); 
                    return count == 1;

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error al validar las credenciales: {ex.Message}");
                return false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                { cnn.Close(); }
            }


            
        }
        private void LinkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            this.Close();

          
            Form1 form1 = new Form1();
            form1.Show();
        }


    }
}
