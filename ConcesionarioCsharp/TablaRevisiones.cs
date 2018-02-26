using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaRevisiones : Form
    {
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private DataTable dtRecord2;
        private SQLiteDataAdapter DataAdap;
        private SQLiteDataAdapter DataAdap2;
        private AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private DateTimePicker calendario;
        bool guardado = true;

        public TablaRevisiones() { }

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

            //Combo auxiliar de Bastidores
            consulta.CommandText = "SELECT N_Bastidor FROM Coche";
            //SQLiteDataAdapter 
            DataAdap2 = new SQLiteDataAdapter(consulta);
            dtRecord2 = new DataTable();
            DataAdap2.Fill(dtRecord2);

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
            DataGridViewTextBoxColumn comboBastidor = new DataGridViewTextBoxColumn();
            comboBastidor.Name = "Bastidor";
            comboBastidor.DataPropertyName = "N_Bastidor";
            this.rellenarComboBastidor();
            dataGridView1.Columns.RemoveAt(5);
            dataGridView1.Columns.Insert(5, comboBastidor);
            dataGridView1.Columns[5].Width = 170;

            //COMANDO INSERT
            SQLiteCommand comando_ins = new SQLiteCommand("INSERT INTO Revision VALUES (@revision,@fecha,@frenos,@aceite,@filtro,@bastidor)", conector.DameConexion());
            comando_ins.Parameters.Add(new SQLiteParameter("@revision", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@fecha", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@frenos", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@aceite", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@filtro", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@bastidor", DbType.String));
            comando_ins.Parameters[0].SourceColumn = "N_Revision";
            comando_ins.Parameters[1].SourceColumn = "Fecha";
            comando_ins.Parameters[2].SourceColumn = "Frenos";
            comando_ins.Parameters[3].SourceColumn = "Aceite";
            comando_ins.Parameters[4].SourceColumn = "Filtro";
            comando_ins.Parameters[5].SourceColumn = "N_Bastidor";
            DataAdap.InsertCommand = comando_ins;
            DataAdap.InsertCommand.Connection = conector.DameConexion();

            //COMANDO UPDATE
            SQLiteCommand comando_act = new SQLiteCommand("UPDATE Revision SET Fecha=@fecha, Frenos=@frenos, Aceite=@aceite, Filtro=@filtro, N_Bastidor=@bastidor WHERE N_Revision=@revision", conector.DameConexion());
            foreach (SQLiteParameter i in comando_ins.Parameters)
                comando_act.Parameters.Add(i);

            for (int i = 0; i < 6; i++)
                comando_act.Parameters[i].SourceColumn = comando_ins.Parameters[i].SourceColumn;

            DataAdap.UpdateCommand = comando_act;
            DataAdap.UpdateCommand.Connection = conector.DameConexion();

            //COMANDO DELETE
            SQLiteCommand comando_del = new SQLiteCommand("DELETE FROM Revision WHERE N_Revision=@revision", conector.DameConexion());
            comando_del.Parameters.Add(new SQLiteParameter("@revision", DbType.String));
            comando_del.Parameters[0].SourceColumn = "N_Revision";
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
                autoComplete.Add(reader.GetString(0));
            }
            reader.Close();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = dataGridView1.Columns.IndexOf(dataGridView1.CurrentCell.OwningColumn);

            if (index == 5)
            {
                TextBox autoText = e.Control as TextBox;//Se genera un textbox desplegable
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    autoText.AutoCompleteCustomSource = this.autoComplete;//Se asigna la colección al TexBox Desplegable
                }
            }
        }

        public void nuevaFila()
        {
            DataRow fila = dtRecord.NewRow();
            dtRecord.Rows.Add(fila);
            dataGridView1.DataSource = dtRecord;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
            SQLiteCommand nrevision = conector.DameComando();
            nrevision.CommandText = "SELECT MAX(N_Revision) FROM Revision";
            SQLiteDataReader reader = nrevision.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = reader.GetInt16(0)+1;
            }
            reader.Close();
            guardado = false;
        }

        public void guardar(int opcion)
        {
            bool correcto = true;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string fecha = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string frenos = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string aceite = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string filtro = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string bastidor = dataGridView1.Rows[i].Cells[5].Value.ToString();

                if (fecha == "")
                {
                    MessageBox.Show("Fecha vacía en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                    correcto = false;
                    break;
                }
                else if (frenos == "" && aceite == "" && filtro == "")
                {
                    MessageBox.Show("Debe seleccionar al menos una opción");
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                    correcto = false;
                    break;
                }
                else if (bastidor == "")
                {
                    MessageBox.Show("Bastidor vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[5];
                    correcto = false;
                    break;
                }
            }

            switch (opcion) {
                case 0:
                    if (correcto)
                    {
                        dataGridView1.EndEdit();
                        DataAdap.Update(dtRecord);
                        MessageBox.Show("Datos guardados");

                        SQLiteCommand consulta = conector.DameComando();
                        consulta.CommandText = "SELECT * FROM Revision";
                        dtRecord = new DataTable();
                        DataAdap.Fill(dtRecord);
                        dataGridView1.DataSource = dtRecord;
                        Opener.pasadatos("revisiones2");
                        guardado = true;
                    }
                    break;
                default:
                    if (correcto)
                    {
                        dataGridView1.EndEdit();
                        DataAdap.Update(dtRecord);

                        SQLiteCommand consulta = conector.DameComando();
                        consulta.CommandText = "SELECT * FROM Revision";
                        dtRecord = new DataTable();
                        DataAdap.Fill(dtRecord);
                        dataGridView1.DataSource = dtRecord;
                        Opener.pasadatos("revisiones2");
                        guardado = true;
                    }
                    break;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Opener.pasadatos("revisiones");
            guardado = false;
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
                        if ((MessageBox.Show("¿Desea borrar la revisión seleccionada?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes))
                        {
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            this.guardar(0);
                        }
                        break;
                    case (Keys.I):
                        InfoRevision infoRevision = new InfoRevision(this.conector, dataGridView1.SelectedRows[0].Cells[0].Value);
                        infoRevision.ShowDialog();
                        break;
                }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void funcion_menucontextual(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Editar":
                    InfoRevision infoRevision = new InfoRevision(this.conector, dataGridView1.SelectedRows[0].Cells[0].Value);
                    infoRevision.ShowDialog();
                    break;
                case "Borrar":
                    if ((MessageBox.Show("¿Desea borrar la revisión seleccionada?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes))
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
                    dataGridView1.CurrentRow.Cells[1].Value = calendario.Text.ToString();
                    // Hace visible el calendario
                    calendario.Visible = true;
                    Opener.pasadatos("revisiones");
                    guardado = false;
                }
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            //Guarda fecha en la celda
            dataGridView1.CurrentRow.Cells[1].Value = calendario.Text.ToString();
        }

        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            //Oculta el control de la celda (pestaña)
            calendario.Visible = false;
        }
    }
}
