using System;
using System.Windows.Forms;
using Finisar.SQLite;

namespace ConcesionarioCsharp
{
    public partial class FormMain : Form, Interfaz
    {
        private TablaCoches tablaCoches;
        private TablaVentas tablaVentas;
        private TablaRevisiones tablaRevisiones;
        private TablaClientes tablaClientes;
        private ConectorSQLite con;
        private FormInforme ventana_informe;

        public FormMain()
        {
            InitializeComponent();
            con = new ConectorSQLite();
            tablaCoches = this.iniciar_coches();
            tablaVentas = this.iniciar_ventas();
            tablaRevisiones = this.iniciar_revisiones();
            tablaClientes = this.iniciar_clientes();
            rellenarComboMarcas();
            ventana_informe = new FormInforme();
            //Abro la tabla de los coches cuando inicio el programa
            this.abrir_hijo(0);
        }

        private void coches_Click(object sender, EventArgs e)
        {
            this.abrir_hijo(0);
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            tablaVentas.rellenarComboBastidor();
            tablaVentas.rellenarComboDni();
            this.tablaVentas.Validate();
            this.tablaVentas.guardar(1);
            this.tablaVentas.Refresh();
            this.abrir_hijo(1);
        }

        private void revisiones_Click(object sender, EventArgs e)
        {
            tablaRevisiones.rellenarComboBastidor();
            this.tablaRevisiones.Validate();
            this.tablaRevisiones.guardar(1);
            this.tablaRevisiones.Refresh();
            this.abrir_hijo(2);
        }

        private void clientes_Click(object sender, EventArgs e)
        {
            this.abrir_hijo(3);
        }

        private TablaCoches iniciar_coches()
        {
            tablaCoches = new TablaCoches(this.con);
            tablaCoches.MdiParent = this;
            tablaCoches.FormBorderStyle = FormBorderStyle.None;
            tablaCoches.Dock = DockStyle.Fill;
            tablaCoches.Opener = this;
            return tablaCoches;
        }

        private TablaVentas iniciar_ventas()
        {
            tablaVentas = new TablaVentas(this.con);
            tablaVentas.MdiParent = this;
            tablaVentas.FormBorderStyle = FormBorderStyle.None;
            tablaVentas.Dock = DockStyle.Fill;
            tablaVentas.Opener = this;
            return tablaVentas;
        }

        private TablaRevisiones iniciar_revisiones()
        {
            tablaRevisiones = new TablaRevisiones(this.con);
            tablaRevisiones.MdiParent = this;
            tablaRevisiones.FormBorderStyle = FormBorderStyle.None;
            tablaRevisiones.Dock = DockStyle.Fill;
            tablaRevisiones.Opener = this;
            return tablaRevisiones;
        }

        private TablaClientes iniciar_clientes()
        {
            tablaClientes = new TablaClientes(this.con);
            tablaClientes.MdiParent = this;
            tablaClientes.FormBorderStyle = FormBorderStyle.None;
            tablaClientes.Dock = DockStyle.Fill;
            tablaClientes.Opener = this;
            return tablaClientes;
        }

        private void abrir_hijo(int ventana)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Hide();

            if(this.ActiveMdiChild == null)
            {
                switch (ventana)
                {
                    case 0:
                        tablaCoches.Show();
                        break;
                    case 1:
                        tablaVentas.Show();
                        break;
                    case 2:
                        tablaRevisiones.Show();
                        break;
                    default:
                        tablaClientes.Show();
                        break;
                }
            }
        }

        public void pasadatos(string arg1)
        {
            switch (arg1)
            {
                case "coches":
                    nuevo.Enabled = false;
                    toolStripButton1.Enabled = true;
                    coches.Enabled = false;
                    revisiones.Enabled = false;
                    ventas.Enabled = false;
                    clientes.Enabled = false;
                    break;
                case "coches2":
                    nuevo.Enabled = true;
                    toolStripButton1.Enabled = false;
                    coches.Enabled = true;
                    revisiones.Enabled = true;
                    ventas.Enabled = true;
                    clientes.Enabled = true;
                    break;
                case "revisiones":
                    nuevo.Enabled = false;
                    toolStripButton1.Enabled = true;
                    coches.Enabled = false;
                    revisiones.Enabled = false;
                    ventas.Enabled = false;
                    clientes.Enabled = false;
                    break;
                case "revisiones2":
                    nuevo.Enabled = true;
                    toolStripButton1.Enabled = false;
                    coches.Enabled = true;
                    revisiones.Enabled = true;
                    ventas.Enabled = true;
                    clientes.Enabled = true;
                    break;
                case "ventas":
                    nuevo.Enabled = false;
                    toolStripButton1.Enabled = true;
                    coches.Enabled = false;
                    revisiones.Enabled = false;
                    ventas.Enabled = false;
                    clientes.Enabled = false;
                    break;
                case "ventas2":
                    nuevo.Enabled = true;
                    toolStripButton1.Enabled = false;
                    coches.Enabled = true;
                    revisiones.Enabled = true;
                    ventas.Enabled = true;
                    clientes.Enabled = true;
                    break;
                case "clientes":
                    nuevo.Enabled = false;
                    toolStripButton1.Enabled = true;
                    coches.Enabled = false;
                    revisiones.Enabled = false;
                    ventas.Enabled = false;
                    clientes.Enabled = false;
                    break;
                default:
                    nuevo.Enabled = true;
                    toolStripButton1.Enabled = false;
                    coches.Enabled = true;
                    revisiones.Enabled = true;
                    ventas.Enabled = true;
                    clientes.Enabled = true;
                    break;
            }
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            string tabla = this.ActiveMdiChild.Name;

            switch (tabla)
            {
                case "TablaCoches":
                    TablaCoches tablaCoches = (TablaCoches)this.ActiveMdiChild;
                    tablaCoches.nuevaFila();
                    break;
                case "TablaRevisiones":
                    TablaRevisiones tablaRevisiones = (TablaRevisiones)this.ActiveMdiChild;
                    tablaRevisiones.nuevaFila();
                    break;
                case "TablaVentas":
                    TablaVentas tablaVentas = (TablaVentas)this.ActiveMdiChild;
                    tablaVentas.nuevaFila();
                    break;
                default:
                    TablaClientes tablaClientes = (TablaClientes)this.ActiveMdiChild;
                    tablaClientes.nuevaFila();
                    break;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string tabla = this.ActiveMdiChild.Name;

            switch (tabla)
            {
                case "TablaCoches":
                    TablaCoches tablaCoches = (TablaCoches)this.ActiveMdiChild;
                    tablaCoches.Validate();
                    tablaCoches.guardar(0);
                    tablaCoches.Refresh();
                    rellenarComboMarcas();
                    break;
                case "TablaRevisiones":
                    TablaRevisiones tablaRevisiones = (TablaRevisiones)this.ActiveMdiChild;
                    tablaRevisiones.Validate();
                    tablaRevisiones.guardar(0);
                    tablaRevisiones.Refresh();
                    break;
                case "TablaVentas":
                    TablaVentas tablaVentas = (TablaVentas)this.ActiveMdiChild;
                    tablaVentas.Validate();
                    tablaVentas.guardar(0);
                    tablaVentas.Refresh();
                    break;
                default:
                    TablaClientes tablaClientes = (TablaClientes)this.ActiveMdiChild;
                    tablaClientes.Validate();
                    tablaClientes.guardar(0);
                    tablaClientes.Refresh();
                    break;
            }
        }

        private void reiniciarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se borrarán todos los datos, ¿desea reiniciar la base de datos?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.reiniciarBBDD();
                tablaCoches.Validate();
                tablaCoches.guardar(1);
                tablaCoches.Refresh();
                tablaRevisiones.Validate();
                tablaRevisiones.guardar(1);
                tablaRevisiones.Refresh();
                tablaVentas.Validate();
                tablaVentas.guardar(1);
                tablaVentas.Refresh();
                tablaClientes.Validate();
                tablaClientes.guardar(1);
                tablaClientes.Refresh();
            }
        }

        //función local para controlar la salida
        private bool salir()
        {
            if (toolStripButton1.Enabled == true)
            {
                if (MessageBox.Show("Hay datos sin Guardar. ¿Cerrar sin Guardar?", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return (true);//Sale
                else
                    return (false);
            }
            else
                return (true);//Sale

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salir() == true)
                e.Cancel = false;
            else
            {
                e.Cancel = true;
                con.cerrarBBDD();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Concesionario 3.0\nJuan Carlos Expósito Romero\nDesarrollo de interfaces 2DAM");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Alt | Keys.N):
                    toolStrip1.Items[1].PerformClick();
                    break;
                case (Keys.Alt | Keys.G):
                    toolStrip1.Items[2].PerformClick();
                    break;
                case (Keys.Alt | Keys.C):
                    toolStrip1.Items[3].PerformClick();
                    break;
                case (Keys.Control | Keys.E):
                    toolStrip1.Items[4].PerformClick();
                    break;
                case (Keys.Alt | Keys.V):
                    toolStrip1.Items[5].PerformClick();
                    break;
                case (Keys.Alt | Keys.L):
                    toolStrip1.Items[6].PerformClick();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rellenarComboMarcas()
        {
            this.cbMarcas.Items.Clear();
            this.cbMarcas.Items.Add("Todos");
            SQLiteCommand consulta = con.DameComando();
            consulta.CommandText = "SELECT DISTINCT Marca FROM Coche";
            SQLiteDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                this.cbMarcas.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }

        private void cbMarcas_TextChanged(object sender, EventArgs e)
        {
            if(cbMarcas.Text == "Todos")
            {
                crea_informe("SELECT * FROM Coche");
            }
            else
            {
                string marca = cbMarcas.Text;
                string sql = "SELECT * FROM Coche WHERE Marca = '"+marca+"'";
                crea_informe(sql);
            }
        }

        private void crea_informe(string sql)
        {
            SQLiteCommand consulta = con.DameComando();
            consulta.CommandText = sql;
            SQLiteDataAdapter DataAdap = new SQLiteDataAdapter(consulta);//Hace de intermediario entre la base de datos y el DataGrid
            DataSet1 Ds = new DataSet1();//Se crea un DataSet
            DataAdap.Fill(Ds, "Coche");//Se enlaza con el que hemos creado desde la interfaz gráfica

            if (Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No hay datos que mostrar, revisar la SQL", "Informe");
                return;
            }

            InformeCoches informe = new InformeCoches(); ;//Se crea el objeto informe
            informe.Load("..\\..\\CrystalReport1.rpt"); //Dado que el directorio es debug, he de salir a la raiz
            informe.SetDataSource(Ds);//Se toma el origen de datos del informe

            ventana_informe.crystalReportViewer1.ReportSource = informe;//Añadimos al Viewer el informe que vamos a mostrar
            ventana_informe.crystalReportViewer1.Refresh();//Se actualiza el informe
            ventana_informe.ShowDialog();//Muestro la ventana de diálogo
        }
    }
}
