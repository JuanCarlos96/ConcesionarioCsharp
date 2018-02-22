using Finisar.SQLite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class TablaClientes : Form
    {
        private ConectorSQLite conector;
        private DataTable dtRecord;
        private SQLiteDataAdapter DataAdap;
        private TablaVentas TablaVentas;
        bool guardado = true;

        public TablaClientes(ConectorSQLite con)
        {
            conector = con;
            InitializeComponent();
            string sql;
            sql = "SELECT * FROM Cliente";
            iniciar_datagrid(sql);
            TablaVentas = new TablaVentas();
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
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].HeaderText = "DNI";
            dataGridView1.Columns[1].Width = 100;//NOMBRE
            dataGridView1.Columns[2].Width = 150;//APELLIDOS
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Teléfono";
            dataGridView1.Columns[4].Width = 353;
            dataGridView1.Columns[4].HeaderText = "Dirección";

            //COMANDO INSERT
            SQLiteCommand comando_ins = new SQLiteCommand("INSERT INTO Cliente VALUES (@dni,@nombre,@apellidos,@telefono,@direccion)", conector.DameConexion());
            comando_ins.Parameters.Add(new SQLiteParameter("@dni", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@nombre", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@apellidos", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@telefono", DbType.String));
            comando_ins.Parameters.Add(new SQLiteParameter("@direccion", DbType.String));
            comando_ins.Parameters[0].SourceColumn = "Dni";
            comando_ins.Parameters[1].SourceColumn = "Nombre";
            comando_ins.Parameters[2].SourceColumn = "Apellidos";
            comando_ins.Parameters[3].SourceColumn = "Telefono";
            comando_ins.Parameters[4].SourceColumn = "Direccion";
            DataAdap.InsertCommand = comando_ins;
            DataAdap.InsertCommand.Connection = conector.DameConexion();

            //COMANDO UPDATE
            SQLiteCommand comando_act = new SQLiteCommand("UPDATE Cliente SET Nombre=@nombre, Apellidos=@apellidos, Telefono=@telefono, Direccion=@direccion WHERE Dni=@dni", conector.DameConexion());
            foreach (SQLiteParameter i in comando_ins.Parameters)
                comando_act.Parameters.Add(i);

            for (int i = 0; i < 5; i++)
                comando_act.Parameters[i].SourceColumn = comando_ins.Parameters[i].SourceColumn;

            DataAdap.UpdateCommand = comando_act;
            DataAdap.UpdateCommand.Connection = conector.DameConexion();

            //COMANDO DELETE
            SQLiteCommand comando_del = new SQLiteCommand("DELETE FROM Cliente WHERE Dni=@dni", conector.DameConexion());
            comando_del.Parameters.Add(new SQLiteParameter("@dni", DbType.String));
            comando_del.Parameters[0].SourceColumn = "Dni";
            DataAdap.DeleteCommand = comando_del;
            DataAdap.DeleteCommand.Connection = conector.DameConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("clientes");
            //editarCliente.ShowDialog();
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
                string dni = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string apellidos = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string telefono = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string direccion = dataGridView1.Rows[i].Cells[4].Value.ToString();

                if (dni == "")
                {
                    MessageBox.Show("DNI vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    correcto = false;
                    break;
                }
                else if (nombre == "")
                {
                    MessageBox.Show("Nombre vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                    correcto = false;
                    break;
                }
                else if (apellidos == "")
                {
                    MessageBox.Show("Apellidos vacíos en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                    correcto = false;
                    break;
                }
                else if (telefono == "")
                {
                    MessageBox.Show("Teléfono vacío en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[3];
                    correcto = false;
                    break;
                }
                else if (direccion == "")
                {
                    MessageBox.Show("Dirección vacía en fila " + (i + 1));
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[4];
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
                consulta.CommandText = "SELECT * FROM Cliente";
                dtRecord = new DataTable();
                DataAdap.Fill(dtRecord);
                dataGridView1.DataSource = dtRecord;
                Opener.pasadatos("clientes2");
                guardado = true;
                TablaVentas.rellenarComboDni();
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Opener.pasadatos("clientes");
            guardado = false;
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.guardar();
        }

        //Funciones de teclado
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                switch (keyData)
                {
                    case (Keys.B):
                        if ((MessageBox.Show("¿Desea borrar el cliente seleccionado?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes))
                        {
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            this.guardar();
                        }
                        break;
                    case (Keys.I):
                        InfoCliente infoCliente = new InfoCliente(this.conector, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        infoCliente.ShowDialog();
                        break;
                }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void funcion_menucontextual(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Editar":
                    InfoCliente infoCliente = new InfoCliente(this.conector, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    infoCliente.ShowDialog();
                    break;
                case "Borrar":
                    if ((MessageBox.Show("¿Desea borrar el cliente seleccionado?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        this.guardar();
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
    }
}
