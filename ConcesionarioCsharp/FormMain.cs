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
                    this.nuevoCoche.Enabled = false;
                    break;
                case "revisiones":
                    this.nuevaRevision.Enabled = false;
                    break;
                case "ventas":
                    this.nuevaVenta.Enabled = false;
                    break;
                default:
                    this.nuevoCoche.Enabled = true;
                    this.nuevaRevision.Enabled = true;
                    this.nuevaVenta.Enabled = true;
                    break;
            }
        }
    }
}
