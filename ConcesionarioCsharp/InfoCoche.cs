using Finisar.SQLite;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class InfoCoche : Form
    {
        public InfoCoche(ConectorSQLite conector, string bastidor)
        {
            InitializeComponent();
            SQLiteCommand consulta = conector.DameComando();
            SQLiteDataReader reader;
            consulta.CommandText = "SELECT * FROM Coche WHERE N_Bastidor='"+bastidor+"'";

            reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                txtBastidor.Text = reader.GetString(0);
                txtMarca.Text = reader.GetString(1);
                txtModelo.Text = reader.GetString(2);
                txtMotor.Text = reader.GetString(3);
                txtCV.Text = reader.GetInt16(4).ToString();
                txtTipo.Text = reader.GetString(5);
                txtColor.Text = reader.GetString(6);
                txtPrecio.Text = reader.GetFloat(7).ToString();
                
                try
                {
                    byte[] imageBytes = (System.Byte[])reader["Img"];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    pImagen.Image = Image.FromStream(ms, true);
                } 
                catch (Exception ex)
                { }

            }
            reader.Close();
        }
    }
}
