using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaRevisiones : Form
    {
        private EditarRevision editarRevision = new EditarRevision();
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private SQLiteDataAdapter DataAdap;

        public TablaRevisiones(ConectorSQLite con)
        {
            conector = con;
            InitializeComponent();
            string sql;
            sql = "SELECT * FROM Revision";
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
            //Ponemos la columna de la PK a solo lectura para evitar problemas (repetición de números o que pueda modificarlo)
            dataGridView1.Columns["N_Revision"].ReadOnly = true;
            dataGridView1.Columns["N_Revision"].DefaultCellStyle.BackColor = Color.Gray;

            //Personalización de Columnas
            //Como las columnas solamente se conocen en tiempo de ejecución, le tengo que dar aquí los anchos
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[0].HeaderText = "Nº Revisión";
            dataGridView1.Columns[1].Width = 103;//FECHA
            dataGridView1.Columns[2].Width = 150;//FRENOS
            dataGridView1.Columns[2].HeaderText = "Revisión de frenos";
            dataGridView1.Columns[3].Width = 150;//ACEITE
            dataGridView1.Columns[3].HeaderText = "Cambio de aceite";
            dataGridView1.Columns[4].Width = 150;//FILTRO
            dataGridView1.Columns[4].HeaderText = "Cambio de filtro";
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[5].HeaderText = "Bastidor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("revisiones");
            //editarRevision.ShowDialog();
        }
    }
}
