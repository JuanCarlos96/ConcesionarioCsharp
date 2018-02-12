using Finisar.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaCoches : Form
    {
        private EditarCoche editarCoche = new EditarCoche();
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private SQLiteDataAdapter DataAdap;

        public TablaCoches(ConectorSQLite con)
        {
            button2.Hide();
            conector = con;
            InitializeComponent();
            string sql;
            sql = "SELECT * FROM Coche";
            iniciar_datagrid(sql);
        }

        public Interfaz Opener { get; set; }

        private void iniciar_datagrid(string sql)
        {
            SQLiteCommand consulta = conector.DameComando();
            consulta.CommandText = sql;

            //SQLiteDataAdapter 
            DataAdap = new SQLiteDataAdapter(consulta);//Hace de intermediario entre la base de datos y el DataGrid
            dtRecord = new DataTable();
            DataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("coches");
            //editarCoche.ShowDialog();
        }
    }
}
