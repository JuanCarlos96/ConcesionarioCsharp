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
    public partial class EditarVenta : Form
    {
        public EditarVenta()
        {
            InitializeComponent();
        }

        private void btnCancelarVentaModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}