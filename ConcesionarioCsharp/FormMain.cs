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
    public partial class FormMain : Form
    {
        private TablaCoches tablaCoches = new TablaCoches();
        private TablaVentas tablaVentas = new TablaVentas();
        private TablaRevisiones tablaRevisiones = new TablaRevisiones();
        private TablaClientes tablaClientes = new TablaClientes();

        public FormMain()
        {
            InitializeComponent();
        }

        private void coches_Click(object sender, EventArgs e)
        {
            tablaCoches.ShowDialog();
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
    }
}
