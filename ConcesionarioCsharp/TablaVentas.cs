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
            dataGridView1.Columns[3].Width = 360;//PRECIO

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
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.Columns.Insert(0, comboBastidor);
            dataGridView1.Columns[0].Width = 170;

            //Columna Dni
            DataGridViewComboBoxColumn comboDni = new DataGridViewComboBoxColumn();
            comboDni.Name = "DNI";
            comboDni.DataPropertyName = "Dni";
            SQLiteCommand consulta3 = conector.DameComando();
            consulta2.CommandText = "SELECT Dni FROM Cliente";
            SQLiteDataReader reader2 = consulta2.ExecuteReader();
            while (reader2.Read())
            {
                comboDni.Items.Add(reader2.GetString(0));
            }
            reader2.Close();
            dataGridView1.Columns.RemoveAt(1);
            dataGridView1.Columns.Insert(1, comboDni);
            dataGridView1.Columns[1].Width = 103;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("ventas");
            //editarVenta.ShowDialog();
        }
    }
}
