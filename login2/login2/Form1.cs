using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace login2
{
    public partial class Form1 : Form
    {
        
        private string cadenaConexion;
        private OleDbConnection cnn;
        private OleDbDataAdapter da;
        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
            
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\login.accdb";
            InitializeDataAdapter();
        }

        private void InitializeDataAdapter()
        {
            try
            {
                cnn = new OleDbConnection(cadenaConexion);
                if (cnn.State == ConnectionState.Open) cnn.Close(); 
                cnn.Open();

                string sSQL = "SELECT * FROM Usuarios";
                da = new OleDbDataAdapter(sSQL, cnn);
                ds = new DataSet();
                da.Fill(ds, "Usuarios");

     
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar DataAdapter: {ex.Message}");
            }
        }

        

        

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                cnn = new OleDbConnection(cadenaConexion);
                cnn.Open();

                
                string query = "INSERT INTO Usuarios (Nombre, Email, Contraseña) VALUES (@Nombre, @Email, @Contraseña)";

                using (OleDbCommand cmd = new OleDbCommand(query, cnn))
                {
                
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Email", txtMail.Text);
                    cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);

     
                    cmd.ExecuteNonQuery();
                }

     
                cnn.Close();
                MessageBox.Show("Registro guardado exitosamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el registro: {ex.Message}");
            }
        }
    }
}

