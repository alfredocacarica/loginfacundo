using System.Data.OleDb;

namespace MiAplicacion
{
    public class ConexionDB
    {
        public static string ConnectionString
        {
            get
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\login.accdb";
            }
        }
    }
}
