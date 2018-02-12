using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaClientes : Form
    {
        private EditarCliente editarCliente = new EditarCliente();
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private SQLiteDataAdapter DataAdap;

        public TablaClientes(ConectorSQLite con)
        {
            conector = con;
            InitializeComponent();
            string sql;
            sql = "SELECT * FROM Cliente";
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
            dataGridView1.Columns["Dni"].ReadOnly = true;
            dataGridView1.Columns["Dni"].DefaultCellStyle.BackColor = Color.Gray;

            //Personalización de Columnas
            //Como las columnas solamente se conocen en tiempo de ejecución, le tengo que dar aquí los anchos
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].HeaderText = "DNI";
            dataGridView1.Columns[1].Width = 100;//NOMBRE
            dataGridView1.Columns[2].Width = 150;//APELLIDOS
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Teléfono";
            dataGridView1.Columns[4].Width = 353;
            dataGridView1.Columns[4].HeaderText = "Dirección";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("clientes");
            //editarCliente.ShowDialog();
        }
    }
}
