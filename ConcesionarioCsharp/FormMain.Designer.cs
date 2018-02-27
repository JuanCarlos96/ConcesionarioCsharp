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
            this.reiniciarBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.informeDeCochesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbMarcas = new System.Windows.Forms.ToolStripComboBox();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.coches = new System.Windows.Forms.ToolStripButton();
            this.revisiones = new System.Windows.Forms.ToolStripButton();
            this.ventas = new System.Windows.Forms.ToolStripButton();
            this.clientes = new System.Windows.Forms.ToolStripButton();
            this.informeDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem1.Text = "&Archivo";
            // 
            // reiniciarBaseDeDatosToolStripMenuItem
            // 
            this.reiniciarBaseDeDatosToolStripMenuItem.Image = global::ConcesionarioCsharp.Properties.Resources.refresh_icon2;
            this.reiniciarBaseDeDatosToolStripMenuItem.Name = "reiniciarBaseDeDatosToolStripMenuItem";
            this.reiniciarBaseDeDatosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.reiniciarBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.reiniciarBaseDeDatosToolStripMenuItem.Text = "&Reiniciar Base de Datos";
            this.reiniciarBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.reiniciarBaseDeDatosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::ConcesionarioCsharp.Properties.Resources.exit_icon;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeDeCochesToolStripMenuItem,
            this.informeDeVentasToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem2.Text = "&Informes";
            // 
            // informeDeCochesToolStripMenuItem
            // 
            this.informeDeCochesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbMarcas});
            this.informeDeCochesToolStripMenuItem.Name = "informeDeCochesToolStripMenuItem";
            this.informeDeCochesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.informeDeCochesToolStripMenuItem.Text = "Informe de Coches";
            // 
            // cbMarcas
            // 
            this.cbMarcas.Name = "cbMarcas";
            this.cbMarcas.Size = new System.Drawing.Size(152, 23);
            this.cbMarcas.TextChanged += new System.EventHandler(this.cbMarcas_TextChanged);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ay&uda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = global::ConcesionarioCsharp.Properties.Resources.about_icon;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.acercaDeToolStripMenuItem.Text = "&Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Image = global::ConcesionarioCsharp.Properties.Resources.pdf_icon;
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.manualToolStripMenuItem.Text = "&Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevo,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.coches,
            this.revisiones,
            this.ventas,
            this.clientes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(829, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevo
            // 
            this.nuevo.Image = global::ConcesionarioCsharp.Properties.Resources.add_icon;
            this.nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(46, 51);
            this.nuevo.Text = "&Nuevo";
            this.nuevo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = global::ConcesionarioCsharp.Properties.Resources.save_icon;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(53, 51);
            this.toolStripButton1.Text = "&Guardar";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // coches
            // 
            this.coches.Image = global::ConcesionarioCsharp.Properties.Resources.favicon_32x32;
            this.coches.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.coches.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.coches.Name = "coches";
            this.coches.Size = new System.Drawing.Size(50, 51);
            this.coches.Text = "&Coches";
            this.coches.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.coches.Click += new System.EventHandler(this.coches_Click);
            // 
            // revisiones
            // 
            this.revisiones.Image = global::ConcesionarioCsharp.Properties.Resources.tools_icon;
            this.revisiones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.revisiones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.revisiones.Name = "revisiones";
            this.revisiones.Size = new System.Drawing.Size(66, 51);
            this.revisiones.Text = "R&evisiones";
            this.revisiones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.revisiones.Click += new System.EventHandler(this.revisiones_Click);
            // 
            // ventas
            // 
            this.ventas.Image = global::ConcesionarioCsharp.Properties.Resources.invoice_icon;
            this.ventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(45, 51);
            this.ventas.Text = "&Ventas";
            this.ventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ventas.Click += new System.EventHandler(this.ventas_Click);
            // 
            // clientes
            // 
            this.clientes.Image = global::ConcesionarioCsharp.Properties.Resources.client_icon1;
            this.clientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clientes.Name = "clientes";
            this.clientes.Size = new System.Drawing.Size(53, 51);
            this.clientes.Text = "C&lientes";
            this.clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.clientes.Click += new System.EventHandler(this.clientes_Click);
            // 
            // informeDeVentasToolStripMenuItem
            // 
            this.informeDeVentasToolStripMenuItem.Name = "informeDeVentasToolStripMenuItem";
            this.informeDeVentasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.informeDeVentasToolStripMenuItem.Text = "Informe de Ventas";
            this.informeDeVentasToolStripMenuItem.Click += new System.EventHandler(this.informeDeVentasToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 421);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Concesionario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ventas;
        private System.Windows.Forms.ToolStripButton revisiones;
        private System.Windows.Forms.ToolStripButton clientes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton coches;
        private System.Windows.Forms.ToolStripMenuItem reiniciarBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem informeDeCochesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbMarcas;
        private System.Windows.Forms.ToolStripMenuItem informeDeVentasToolStripMenuItem;
    }
}

