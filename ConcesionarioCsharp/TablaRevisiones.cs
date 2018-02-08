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
    public partial class TablaRevisiones : Form
    {
        private EditarRevision editarRevision = new EditarRevision();

        public TablaRevisiones()
        {
            InitializeComponent();
        }

        public Interfaz Opener { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            editarRevision.ShowDialog();
        }
    }
}
