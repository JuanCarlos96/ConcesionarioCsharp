using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaVentas : Form
    {
        private EditarVenta editarVenta = new EditarVenta();
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private SQLiteDataAdapter DataAdap;

        public TablaVentas(ConectorSQLite con)
        {
            conector = con;
            InitializeComponent();
            string sql;
            sql = "SELECT * FROM Venta";
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
            dataGridView1.Columns["Dni"].ReadOnly = true;
            dataGridView1.Columns["N_Bastidor"].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.Columns["Dni"].DefaultCellStyle.BackColor = Color.Gray;

            //Personalización de Columnas
            //Como las columnas solamente se conocen en tiempo de ejecución, le tengo que dar aquí los anchos
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].HeaderText = "Bastidor";
            dataGridView1.Columns[1].Width = 103;
            dataGridView1.Columns[1].HeaderText = "DNI";
            dataGridView1.Columns[2].Width = 150;//FECHA
            dataGridView1.Columns[3].Width = 390;//PRECIO
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("ventas");
            //editarVenta.ShowDialog();
        }
    }
}
