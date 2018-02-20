using System;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class FormMain : Form, Interfaz
    {
        private TablaCoches tablaCoches;
        private TablaVentas tablaVentas;
        private TablaRevisiones tablaRevisiones;
        private TablaClientes tablaClientes;
        private ConectorSQLite con;

        public FormMain()
        {
            InitializeComponent();
            con = new ConectorSQLite();
            tablaCoches = this.iniciar_coches();
            tablaVentas = this.iniciar_ventas();
            tablaRevisiones = this.iniciar_revisiones();
            tablaClientes = this.iniciar_clientes();
            //Abro la tabla de los coches cuando inicio el programa
            this.abrir_hijo(0);
        }

        private void coches_Click(object sender, EventArgs e)
        {
            this.abrir_hijo(0);
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            this.abrir_hijo(1);
        }

        private void revisiones_Click(object sender, EventArgs e)
        {
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
                    tablaCoches.guardar();
                    tablaCoches.Refresh();
                    break;
                case "TablaRevisiones":
                    TablaRevisiones tablaRevisiones = (TablaRevisiones)this.ActiveMdiChild;
                    tablaRevisiones.Validate();
                    tablaRevisiones.guardar();
                    tablaRevisiones.Refresh();
                    break;
                case "TablaVentas":
                    TablaVentas tablaVentas = (TablaVentas)this.ActiveMdiChild;
                    tablaVentas.Validate();
                    tablaVentas.guardar();
                    tablaVentas.Refresh();
                    break;
                default:
                    TablaClientes tablaClientes = (TablaClientes)this.ActiveMdiChild;
                    tablaClientes.Validate();
                    tablaClientes.guardar();
                    tablaClientes.Refresh();
                    break;
            }
        }
    }
}
