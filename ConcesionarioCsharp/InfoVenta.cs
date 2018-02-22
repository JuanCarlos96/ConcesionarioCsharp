using System;
using System.Windows.Forms;
using Finisar.SQLite;

namespace ConcesionarioCsharp
{
    public partial class InfoVenta : Form
    {
        public InfoVenta(ConectorSQLite conector, string bastidor, string dni)
        {
            InitializeComponent();
            SQLiteCommand consulta = conector.DameComando();
            SQLiteDataReader reader;
            consulta.CommandText = "SELECT * FROM Venta WHERE N_Bastidor='" + bastidor + "' AND Dni='" + dni + "'";

            reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                txtCoche.Text = reader.GetString(0);
                txtCliente.Text = reader.GetString(1);
                txtFecha.Text = reader.GetString(2);
                txtPrecio.Text = reader.GetFloat(3).ToString();
            }
            reader.Close();
        }
    }
}
