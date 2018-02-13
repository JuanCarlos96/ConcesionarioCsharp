using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
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
            //Ponemos la columna de la PK a solo lectura para evitar problemas (repetición de números o que pueda modificarlo)
            dataGridView1.Columns["N_Bastidor"].ReadOnly = true;
            dataGridView1.Columns["N_Bastidor"].DefaultCellStyle.BackColor = Color.Gray;

            //Personalización de Columnas
            //Como las columnas solamente se conocen en tiempo de ejecución, le tengo que dar aquí los anchos
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].HeaderText = "Bastidor";
            dataGridView1.Columns[1].Width = 100;//MARCA
            dataGridView1.Columns[2].Width = 90;//MODELO
            dataGridView1.Columns[3].Width = 80;//MOTOR
            dataGridView1.Columns[4].Width = 40;//CABALLOS
            dataGridView1.Columns[5].Width = 90;//TIPO
            dataGridView1.Columns[6].Width = 80;//COLOR
            dataGridView1.Columns[7].Width = 53;//PRECIO
            dataGridView1.Columns[8].Width = 100;//IMAGEN

            //Columna Tipo
            DataGridViewComboBoxColumn comboTipo = new DataGridViewComboBoxColumn();
            comboTipo.Name = "Tipo";
            comboTipo.DataPropertyName = "Tipo";
            comboTipo.Items.Add("TURISMO");
            comboTipo.Items.Add("SEDÁN");
            comboTipo.Items.Add("COMPACTO");
            comboTipo.Items.Add("DEPORTIVO");
            comboTipo.Items.Add("COMERCIAL");
            comboTipo.Items.Add("FAMILIAR");
            comboTipo.Items.Add("TODOTERRENO");
            dataGridView1.Columns.RemoveAt(5);
            dataGridView1.Columns.Insert(5, comboTipo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("coches");
            //editarCoche.ShowDialog();
        }
    }
}
