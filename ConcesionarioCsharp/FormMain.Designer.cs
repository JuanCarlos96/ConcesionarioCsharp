namespace ConcesionarioCsharp
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reiniciarBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevoCoche = new System.Windows.Forms.ToolStripButton();
            this.nuevaVenta = new System.Windows.Forms.ToolStripButton();
            this.nuevaRevision = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.coches = new System.Windows.Forms.ToolStripButton();
            this.ventas = new System.Windows.Forms.ToolStripButton();
            this.revisiones = new System.Windows.Forms.ToolStripButton();
            this.clientes = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reiniciarBaseDeDatosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            // 
            // reiniciarBaseDeDatosToolStripMenuItem
            // 
            this.reiniciarBaseDeDatosToolStripMenuItem.Name = "reiniciarBaseDeDatosToolStripMenuItem";
            this.reiniciarBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(195, 23);
            this.reiniciarBaseDeDatosToolStripMenuItem.Text = "Reiniciar Base de Datos";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(255, 23);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem2.Text = "Informes";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCoche,
            this.nuevaVenta,
            this.nuevaRevision,
            this.toolStripSeparator1,
            this.coches,
            this.ventas,
            this.revisiones,
            this.clientes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(829, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevoCoche
            // 
            this.nuevoCoche.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoCoche.Image = ((System.Drawing.Image)(resources.GetObject("nuevoCoche.Image")));
            this.nuevoCoche.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoCoche.Name = "nuevoCoche";
            this.nuevoCoche.Size = new System.Drawing.Size(23, 22);
            this.nuevoCoche.Text = "toolStripButton1";
            // 
            // nuevaVenta
            // 
            this.nuevaVenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevaVenta.Image = ((System.Drawing.Image)(resources.GetObject("nuevaVenta.Image")));
            this.nuevaVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevaVenta.Name = "nuevaVenta";
            this.nuevaVenta.Size = new System.Drawing.Size(23, 22);
            this.nuevaVenta.Text = "toolStripButton2";
            // 
            // nuevaRevision
            // 
            this.nuevaRevision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevaRevision.Image = ((System.Drawing.Image)(resources.GetObject("nuevaRevision.Image")));
            this.nuevaRevision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevaRevision.Name = "nuevaRevision";
            this.nuevaRevision.Size = new System.Drawing.Size(23, 22);
            this.nuevaRevision.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // coches
            // 
            this.coches.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.coches.Image = ((System.Drawing.Image)(resources.GetObject("coches.Image")));
            this.coches.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.coches.Name = "coches";
            this.coches.Size = new System.Drawing.Size(23, 22);
            this.coches.Click += new System.EventHandler(this.coches_Click);
            // 
            // ventas
            // 
            this.ventas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ventas.Image = ((System.Drawing.Image)(resources.GetObject("ventas.Image")));
            this.ventas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(23, 22);
            this.ventas.Text = "toolStripButton4";
            this.ventas.Click += new System.EventHandler(this.ventas_Click);
            // 
            // revisiones
            // 
            this.revisiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.revisiones.Image = ((System.Drawing.Image)(resources.GetObject("revisiones.Image")));
            this.revisiones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.revisiones.Name = "revisiones";
            this.revisiones.Size = new System.Drawing.Size(23, 22);
            this.revisiones.Text = "toolStripButton5";
            this.revisiones.Click += new System.EventHandler(this.revisiones_Click);
            // 
            // clientes
            // 
            this.clientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clientes.Image = ((System.Drawing.Image)(resources.GetObject("clientes.Image")));
            this.clientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clientes.Name = "clientes";
            this.clientes.Size = new System.Drawing.Size(23, 22);
            this.clientes.Text = "toolStripButton6";
            this.clientes.Click += new System.EventHandler(this.clientes_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 420);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Concesionario";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox reiniciarBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox salirToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuevoCoche;
        private System.Windows.Forms.ToolStripButton nuevaVenta;
        private System.Windows.Forms.ToolStripButton nuevaRevision;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ventas;
        private System.Windows.Forms.ToolStripButton revisiones;
        private System.Windows.Forms.ToolStripButton clientes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton coches;
    }
}

