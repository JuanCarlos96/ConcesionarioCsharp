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

            //Columna Revisión de frenos
            DataGridViewCheckBoxColumn columnacheck = new DataGridViewCheckBoxColumn();
            columnacheck.HeaderText = "Revisión de frenos";
            columnacheck.Name = "frenos";
            columnacheck.DataPropertyName = "Frenos";
            columnacheck.FalseValue = "No";
            columnacheck.TrueValue = "Sí";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, columnacheck);
            dataGridView1.Columns[2].Width = 140;

            //Columna Cambio de aceite
            DataGridViewCheckBoxColumn columnacheck2 = new DataGridViewCheckBoxColumn();
            columnacheck2.HeaderText = "Cambio de aceite";
            columnacheck2.Name = "aceite";
            columnacheck2.DataPropertyName = "Aceite";
            columnacheck2.FalseValue = "No";
            columnacheck2.TrueValue = "Sí";
            dataGridView1.Columns.RemoveAt(3);
            dataGridView1.Columns.Insert(3, columnacheck2);
            dataGridView1.Columns[3].Width = 140;

            //Columna Cambio de filtro
            DataGridViewCheckBoxColumn columnacheck3 = new DataGridViewCheckBoxColumn();
            columnacheck3.HeaderText = "Cambio de filtro";
            columnacheck3.Name = "filtro";
            columnacheck3.DataPropertyName = "Filtro";
            columnacheck3.FalseValue = "No";
            columnacheck3.TrueValue = "Sí";
            dataGridView1.Columns.RemoveAt(4);
            dataGridView1.Columns.Insert(4, columnacheck3);
            dataGridView1.Columns[4].Width = 140;

            //Columna Bastidor
            DataGridViewComboBoxColumn comboBastidor = new DataGridViewComboBoxColumn();
            comboBastidor.Name = "Bastidor";
            comboBastidor.DataPropertyName = "N_Bastidor";
            SQLiteCommand consulta2 = conector.DameComando();
            consulta2.CommandText = "SELECT N_Bastidor FROM Coche";
            SQLiteDataReader reader = consulta2.ExecuteReader();
            while (reader.Read())
            {
                comboBastidor.Items.Add(reader.GetString(0));
            }
            reader.Close();
            dataGridView1.Columns.RemoveAt(5);
            dataGridView1.Columns.Insert(5, comboBastidor);
            dataGridView1.Columns[5].Width = 170;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("revisiones");
            //editarRevision.ShowDialog();
        }
    }
}
