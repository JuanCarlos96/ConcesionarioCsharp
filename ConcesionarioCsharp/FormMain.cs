using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcesionarioCsharp
{
    public partial class FormMain : Form, Interfaz
    {
        private TablaCoches tablaCoches;
        private TablaVentas tablaVentas = new TablaVentas();
        private TablaRevisiones tablaRevisiones = new TablaRevisiones();
        private TablaClientes tablaClientes = new TablaClientes();

        public FormMain()
        {
            InitializeComponent();
            tablaCoches = this.iniciar_coches();
        }

        private void coches_Click(object sender, EventArgs e)
        {
            this.abrir_hijo(0);
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            tablaVentas.ShowDialog();
        }

        private void revisiones_Click(object sender, EventArgs e)
        {
            tablaRevisiones.ShowDialog();
        }

        private void clientes_Click(object sender, EventArgs e)
        {
            tablaClientes.ShowDialog();
        }

        private TablaCoches iniciar_coches()
        {
            tablaCoches.MdiParent = this;
            tablaCoches.Opener = this;
            return tablaCoches;
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
                }
            }
        }

        public void pasadatos(string arg1)
        {
            throw new NotImplementedException();
        }
    }
}
