using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaVentas : Form
    {
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private DataTable dtRecordBastidor;
        private DataTable dtRecordDni;
        private SQLiteDataAdapter DataAdap;
        private SQLiteDataAdapter DataAdapBastidor;
        private SQLiteDataAdapter DataAdapDni;
        private AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection autoComplete2 = new AutoCompleteStringCollection();
        private DateTimePicker calendario;
        bool guardado = true;

        public TablaVentas() { }

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
            this.rellenarComboBastidor();
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.Columns.Insert(0, busqueda);
            dataGridView1.Columns[0].Width = 170;

            //Columna Dni
            DataGridViewTextBoxColumn comboDni = new DataGridViewTextBoxColumn();
            comboDni.Name = "DNI";
            comboDni.DataPropertyName = "Dni";
            this.rellenarComboDni();
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

        public void rellenarComboBastidor()
        {
            ConectorSQLite conector = new ConectorSQLite();
            SQLiteCommand consulta2 = conector.DameComando();
            consulta2.CommandText = "SELECT N_Bastidor FROM Coche";
            SQLiteDataReader reader = consulta2.ExecuteReader();
            this.autoComplete.Clear();
            while (reader.Read())
            {
                this.autoComplete.Add(reader.GetString(0));
            }
            reader.Close();
        }

        public void rellenarComboDni() {
            ConectorSQLite conector = new ConectorSQLite();
            SQLiteCommand consulta3 = conector.DameComando();
            consulta3.CommandText = "SELECT Dni FROM Cliente";
            SQLiteDataReader reader2 = consulta3.ExecuteReader();
            this.autoComplete2.Clear();
            while (reader2.Read())
            {
                autoComplete2.Add(reader2.GetString(0));
            }
            reader2.Close();
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

        public void guardar(int opcion)
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

            switch (opcion)
            {
                case 0:
                    if (correcto)
                    {
                        try
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
                        catch(Finisar.SQLite.SQLiteException exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    break;
                default:
                    if (correcto)
                    {
                        try
                        {
                            dataGridView1.EndEdit();
                            DataAdap.Update(dtRecord);

                            SQLiteCommand consulta = conector.DameComando();
                            consulta.CommandText = "SELECT * FROM Venta";
                            dtRecord = new DataTable();
                            DataAdap.Fill(dtRecord);
                            dataGridView1.DataSource = dtRecord;
                            Opener.pasadatos("ventas2");
                            guardado = true;
                        }
                        catch (Finisar.SQLite.SQLiteException exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }
                    break;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Opener.pasadatos("ventas");
            guardado = false;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.guardar(0);
        }

        //Funciones de teclado
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                switch (keyData)
                {
                    case (Keys.B):
                        if ((MessageBox.Show("¿Desea borrar la venta seleccionada?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes))
                        {
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            this.guardar(0);
                        }
                        break;
                    case (Keys.I):
                        InfoVenta infoVenta = new InfoVenta(this.conector, dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                        infoVenta.ShowDialog();
                        break;
                }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void funcion_menucontextual(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Editar":
                    InfoVenta infoVenta = new InfoVenta(this.conector, dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    infoVenta.ShowDialog();
                    break;
                case "Borrar":
                    if ((MessageBox.Show("¿Desea borrar la venta seleccionada?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        this.guardar(0);
                    }
                    break;
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right & guardado)
            {
                dataGridView1.ClearSelection();
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    ContextMenuStrip m = new ContextMenuStrip();
                    m.Items.Add("Ver Ficha").Name = "Editar";
                    //m.Items[0].Image = Properties.Resources.editar;
                    m.Items.Add("Borrar").Name = "Borrar";
                    //m.Items[1].Image = Properties.Resources.borra;
                    dataGridView1.Rows[currentMouseOverRow].Selected = true;
                    m.ItemClicked += new ToolStripItemClickedEventHandler(funcion_menucontextual);
                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
            else if (e.Button == MouseButtons.Right & !guardado)
                MessageBox.Show("El menú contextual se activa cuando todo está guardado");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 & e.ColumnIndex > -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Fecha")
                {
                    //Inicializa el DateTimePicker Control  
                    this.calendario = new DateTimePicker();
                    //Añade el DateTimePicker control dentro del DataGridView   
                    dataGridView1.Controls.Add(calendario);
                    //Pone el formato sin hora  
                    calendario.Format = DateTimePickerFormat.Short;
                    // Esto me da el area rectangular del area de la celda
                    Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    //Le doy ese tamaño y localización 
                    calendario.Size = new Size(oRectangle.Width, oRectangle.Height);
                    calendario.Location = new Point(oRectangle.X, oRectangle.Y);
                    //Se crea un evento para que se cierre el control al utilizarlo 
                    calendario.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
                    //Un evento para que coloque la fecha en la celda
                    calendario.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                    //Coloca la fecha actual de forma inicial
                    dataGridView1.CurrentRow.Cells[2].Value = calendario.Text.ToString();
                    // Hace visible el calendario
                    calendario.Visible = true;
                    Opener.pasadatos("ventas");
                    guardado = false;
                }
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            //Guarda fecha en la celda
            dataGridView1.CurrentRow.Cells[2].Value = calendario.Text.ToString();
        }
        
        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            //Oculta el control de la celda (pestaña)
            calendario.Visible = false;
        }
    }
}
