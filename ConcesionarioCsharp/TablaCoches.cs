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

            //COMANDO INSERT
            SQLiteCommand comando_ins = new SQLiteCommand("INSERT INTO Coche VALUES (@bastidor,@marca,@modelo,@motor,@cv,@tipo,@color,@precio,@imagen)", conector.DameConexion());
            //Se establece la anti-inyeccion SQL enlazando los parámetros 
            comando_ins.Parameters.Add(new SQLiteParameter("@bastidor", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@marca", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@modelo", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@motor", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@cv", DbType.Int16));
            comando_ins.Parameters.Add(new SQLiteParameter("@tipo", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@color", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@precio", DbType.Decimal));
            comando_ins.Parameters.Add(new SQLiteParameter("@imagen", DbType.Binary));
            //Añado los nombres de los campos de la base de datos. Los números de columnas se corresponde con el orden de los parámetros anteriores
            comando_ins.Parameters[0].SourceColumn = "N_Bastidor";
            comando_ins.Parameters[1].SourceColumn = "Marca";
            comando_ins.Parameters[2].SourceColumn = "Modelo";
            comando_ins.Parameters[3].SourceColumn = "Motor";
            comando_ins.Parameters[4].SourceColumn = "CV";
            comando_ins.Parameters[5].SourceColumn = "Tipo";
            comando_ins.Parameters[6].SourceColumn = "Color";
            comando_ins.Parameters[7].SourceColumn = "Precio";
            comando_ins.Parameters[8].SourceColumn = "Img";
            //Se actualiza el comando Insert y se le asocia la conexión
            DataAdap.InsertCommand = comando_ins;
            DataAdap.InsertCommand.Connection = conector.DameConexion();

            //COMANDO UPDATE
            SQLiteCommand comando_act = new SQLiteCommand("UPDATE Coche SET Marca=@marca, Modelo=@modelo, Motor=@motor, CV=@cv, Tipo=@tipo, Color=@color, Precio=@precio, Img=@imagen WHERE N_Bastidor=@bastidor", conector.DameConexion());
            //Dado que son los mismos parámmetros que para el comando insert puedo hacer lo siguiente: copiar parámetros y sourcecolumns 
            foreach (SQLiteParameter i in comando_ins.Parameters)
                comando_act.Parameters.Add(i);

            for (int i = 0; i < 9; i++)
                comando_act.Parameters[i].SourceColumn = comando_ins.Parameters[i].SourceColumn;

            DataAdap.UpdateCommand = comando_act;
            DataAdap.UpdateCommand.Connection = conector.DameConexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("coches");
            //editarCoche.ShowDialog();
        }

        public void nuevaFila()
        {
            DataRow fila = dtRecord.NewRow();
            dtRecord.Rows.Add(fila);
            dataGridView1.DataSource = dtRecord;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
        }
    }
}
