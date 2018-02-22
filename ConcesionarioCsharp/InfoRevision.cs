using System;
using System.Windows.Forms;
using Finisar.SQLite;

namespace ConcesionarioCsharp
{
    public partial class InfoRevision : Form
    {
        public InfoRevision(ConectorSQLite conector, object id)
        {
            InitializeComponent();
            int nrevision = Convert.ToInt16(id);
            string frenos = null;
            string aceite = null;
            string filtro = null;
            SQLiteCommand consulta = conector.DameComando();
            SQLiteDataReader reader;
            consulta.CommandText = "SELECT * FROM Revision WHERE N_Revision=" + nrevision;

            reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                txtId.Text = reader.GetInt16(0).ToString();
                txtFecha.Text = reader.GetString(1);
                frenos = reader.GetString(2);
                aceite = reader.GetString(3);
                filtro = reader.GetString(4);
                txtBastidor.Text = reader.GetString(5);
            }
            reader.Close();

            if (frenos == "Sí")
            {
                chkFrenos.Checked = true;
            }
            else
            {
                chkFrenos.Checked = false;
            }

            if (aceite == "Sí")
            {
                chkAceite.Checked = true;
            }
            else
            {
                chkAceite.Checked = false;
            }

            if (filtro == "Sí")
            {
                chkFiltro.Checked = true;
            }
            else
            {
                chkFiltro.Checked = false;
            }

            string bastidor = txtBastidor.Text;
            SQLiteCommand consulta2 = conector.DameComando();
            SQLiteDataReader reader2;
            consulta2.CommandText = "SELECT Marca, Modelo FROM Coche WHERE N_Bastidor='" + bastidor + "'";

            reader2 = consulta2.ExecuteReader();
            while (reader2.Read())
            {
                txtMarca.Text = reader2.GetString(0);
                txtModelo.Text = reader2.GetString(1);
            }
            reader2.Close();
        }
    }
}
