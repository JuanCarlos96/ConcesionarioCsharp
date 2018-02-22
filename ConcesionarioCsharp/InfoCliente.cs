using System;
using System.Windows.Forms;
using Finisar.SQLite;

namespace ConcesionarioCsharp
{
    public partial class InfoCliente : Form
    {
        public InfoCliente(ConectorSQLite conector, string dni)
        {
            InitializeComponent();
            SQLiteCommand consulta = conector.DameComando();
            SQLiteDataReader reader;
            consulta.CommandText = "SELECT * FROM Cliente WHERE Dni='" + dni+ "'";

            reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                txtDni.Text = reader.GetString(0);
                txtNombre.Text = reader.GetString(1);
                txtApellidos.Text = reader.GetString(2);
                txtTelefono.Text = reader.GetString(3);
                txtDireccion.Text = reader.GetString(4);
            }
            reader.Close();
        }
    }
}
