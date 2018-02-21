using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaVentas : Form
    {
        private InfoVenta editarVenta = new InfoVenta();
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private DataTable dtRecordBastidor;
        private DataTable dtRecordDni;
        private SQLiteDataAdapter DataAdap;
        private SQLiteDataAdapter DataAdapBastidor;
        private SQLiteDataAdapter DataAdapDni;
        private AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection autoComplete2 = new AutoCompleteStringCollection();
        bool guardado = true;

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

            //Combo auxiliar de Bastidores
            consulta.CommandText = "SELECT N_Bastidor FROM Coche";
            //SQLiteDataAdapter 
            DataAdapBastidor = new SQLiteDataAdapter(consulta);
            dtRecordBastidor = new DataTable();
            DataAdapBastidor.Fill(dtRecordBastidor);

            //Combo auxiliar de DNIs
            consulta.CommandText = "SELECT Dni FROM Cliente";
            //SQLiteDataAdapter 
            DataAdapDni = new SQLiteDataAdapter(consulta);
            dtRecordDni = new DataTable();
            DataAdapDni.Fill(dtRecordDni);

            //Ponemos la columna de la PK a solo lectura para evitar problemas (repetición de números o que pueda modificarlo)
            dataGridView1.Columns["N_Bastidor"].ReadOnly = true;
            dataGridView1.Columns["Dni"].ReadOnly = true;
            dataGridView1.Columns["N_Bastidor"].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.Columns["Dni"].DefaultCellStyle.BackColor = Color.Gray;

            //Anchos de Columnas
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[0].HeaderText = "Bastidor";
            dataGridView1.Columns[1].Width = 103;
            dataGridView1.Columns[1].HeaderText = "DNI";
            dataGridView1.Columns[2].Width = 150;//FECHA
            dataGridView1.Columns[3].Width = 360;//PRECIO

            //Columna Bastidor
            DataGridViewTextBoxColumn busqueda = new DataGridViewTextBoxColumn();
            busqueda.Name = "Bastidor";
            busqueda.DataPropertyName = "N_Bastidor";
            SQLiteCommand consulta2 = conector.DameComando();
            consulta2.CommandText = "SELECT N_Bastidor FROM Coche";
            SQLiteDataReader reader = consulta2.ExecuteReader();
            while (reader.Read())
            {
                autoComplete.Add(reader.GetString(0));
            }
            reader.Close();
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.Columns.Insert(0, busqueda);
            dataGridView1.Columns[0].Width = 170;

            //Columna Dni
            DataGridViewTextBoxColumn comboDni = new DataGridViewTextBoxColumn();
            comboDni.Name = "DNI";
            comboDni.DataPropertyName = "Dni";
            SQLiteCommand consulta3 = conector.DameComando();
            consulta3.CommandText = "SELECT Dni FROM Cliente";
            SQLiteDataReader reader2 = consulta3.ExecuteReader();
            while (reader2.Read())
            {
                autoComplete2.Add(reader2.GetString(0));
            }
            reader2.Close();
            dataGridView1.Columns.RemoveAt(1);
            dataGridView1.Columns.Insert(1, comboDni);
            dataGridView1.Columns[1].Width = 103;

            //COMANDO INSERT
            SQLiteCommand comando_ins = new SQLiteCommand("INSERT INTO Venta VALUES (@bastidor,@dni,@fecha,@precio)", conector.DameConexion());
            comando_ins.Parameters.Add(new SQLiteParameter("@bastidor", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@dni", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@fecha", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@precio", DbType.Decimal));
            comando_ins.Parameters[0].SourceColumn = "N_Bastidor";
            comando_ins.Parameters[1].SourceColumn = "Dni";
            comando_ins.Parameters[2].SourceColumn = "Fecha";
            comando_ins.Parameters[3].SourceColumn = "Precio";
            DataAdap.InsertCommand = comando_ins;
            DataAdap.InsertCommand.Connection = conector.DameConexion();

            //COMANDO UPDATE
            SQLiteCommand comando_act = new SQLiteCommand("UPDATE Venta SET Fecha=@fecha, Precio=@precio WHERE N_Bastidor=@bastidor AND Dni=@dni", conector.DameConexion());
            foreach (SQLiteParameter i in comando_ins.Parameters)
                comando_act.Parameters.Add(i);

            for (int i = 0; i < 4; i++)
                comando_act.Parameters[i].SourceColumn = comando_ins.Parameters[i].SourceColumn;

            DataAdap.UpdateCommand = comando_act;
            DataAdap.UpdateCommand.Connection = conector.DameConexion();

            //COMANDO DELETE
            SQLiteCommand comando_del = new SQLiteCommand("DELETE FROM Venta WHERE N_Bastidor=@bastidor AND Dni=@dni", conector.DameConexion());
            comando_del.Parameters.Add(new SQLiteParameter("@bastidor", DbType.String));
            comando_del.Parameters.Add(new SQLiteParameter("@dni", DbType.String));
            comando_del.Parameters[0].SourceColumn = "N_Bastidor";
            comando_del.Parameters[1].SourceColumn = "Dni";
            DataAdap.DeleteCommand = comando_del;
            DataAdap.DeleteCommand.Connection = conector.DameConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("ventas");
            //editarVenta.ShowDialog();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dataGridView1.Columns.IndexOf(dataGridView1.CurrentCell.OwningColumn);

            if (index==0)
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    autoText.AutoCompleteCustomSource = this.autoComplete;
                }
            }else if (index==1)
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    autoText.AutoCompleteCustomSource = this.autoComplete2;
                }
            }
        }

        public void nuevaFila()
        {
            DataRow fila = dtRecord.NewRow();
            dtRecord.Rows.Add(fila);
            dataGridView1.DataSource = dtRecord;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            guardado = false;
        }

        public void guardar()
        {
            bool correcto = true;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string bastidor = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string dni = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string fecha = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string precio = dataGridView1.Rows[i].Cells[3].Value.ToString();

                if (bastidor == "")
                {
                    MessageBox.Show("Bastidor vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    correcto = false;
                    break;
                }
                else if (dni == "")
                {
                    MessageBox.Show("DNI vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                    correcto = false;
                    break;
                }
                else if (fecha == "")
                {
                    MessageBox.Show("Fecha vacía en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                    correcto = false;
                    break;
                }else if (precio == "")
                {
                    MessageBox.Show("Precio incorrecto en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[3];
                    correcto = false;
                    break;
                }
            }

            if (correcto)
            {
                dataGridView1.EndEdit();
                DataAdap.Update(dtRecord);
                MessageBox.Show("Datos guardados");

                SQLiteCommand consulta = conector.DameComando();
                consulta.CommandText = "SELECT * FROM Venta";
                dtRecord = new DataTable();
                DataAdap.Fill(dtRecord);
                dataGridView1.DataSource = dtRecord;
                Opener.pasadatos("ventas2");
                guardado = true;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Opener.pasadatos("ventas");
            guardado = false;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    MessageBox.Show("Error en el precio, debe ser un número real");
                    break;
            }
        }
    }
}
