﻿using System;
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
    public partial class InfoCoche : Form
    {
        public InfoCoche()
        {
            InitializeComponent();
        }

        private void btnCancelarCocheModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
