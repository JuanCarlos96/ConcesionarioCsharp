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
    public partial class TablaCoches : Form
    {
        private EditarCoche editarCoche = new EditarCoche();

        public TablaCoches()
        {
            InitializeComponent();
        }

        public Interfaz Opener { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Opener.pasadatos("coches");
            //editarCoche.ShowDialog();
        }
    }
}
