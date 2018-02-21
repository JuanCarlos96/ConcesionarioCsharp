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
    public partial class InfoRevision : Form
    {
        public InfoRevision()
        {
            InitializeComponent();
        }

        private void btnCancelarRevisionModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
