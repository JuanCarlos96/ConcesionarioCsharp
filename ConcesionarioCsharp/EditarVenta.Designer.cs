namespace ConcesionarioCsharp
{
    partial class EditarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDniVentaModificar = new System.Windows.Forms.TextBox();
            this.txtBastidorVentaModificar = new System.Windows.Forms.TextBox();
            this.txtPrecioVentaModificar = new System.Windows.Forms.TextBox();
            this.btnCancelarVentaModificar = new System.Windows.Forms.Button();
            this.btnAceptarVentaModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(58, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Coche:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Precio:";
            // 
            // txtDniVentaModificar
            // 
            this.txtDniVentaModificar.Location = new System.Drawing.Point(60, 75);
            this.txtDniVentaModificar.Name = "txtDniVentaModificar";
            this.txtDniVentaModificar.Size = new System.Drawing.Size(142, 20);
            this.txtDniVentaModificar.TabIndex = 5;
            // 
            // txtBastidorVentaModificar
            // 
            this.txtBastidorVentaModificar.Location = new System.Drawing.Point(60, 136);
            this.txtBastidorVentaModificar.Name = "txtBastidorVentaModificar";
            this.txtBastidorVentaModificar.Size = new System.Drawing.Size(142, 20);
            this.txtBastidorVentaModificar.TabIndex = 6;
            // 
            // txtPrecioVentaModificar
            // 
            this.txtPrecioVentaModificar.Location = new System.Drawing.Point(60, 199);
            this.txtPrecioVentaModificar.Name = "txtPrecioVentaModificar";
            this.txtPrecioVentaModificar.Size = new System.Drawing.Size(76, 20);
            this.txtPrecioVentaModificar.TabIndex = 7;
            // 
            // btnCancelarVentaModificar
            // 
            this.btnCancelarVentaModificar.Location = new System.Drawing.Point(185, 246);
            this.btnCancelarVentaModificar.Name = "btnCancelarVentaModificar";
            this.btnCancelarVentaModificar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarVentaModificar.TabIndex = 8;
            this.btnCancelarVentaModificar.Text = "Cancelar";
            this.btnCancelarVentaModificar.UseVisualStyleBackColor = true;
            this.btnCancelarVentaModificar.Click += new System.EventHandler(this.btnCancelarVentaModificar_Click);
            // 
            // btnAceptarVentaModificar
            // 
            this.btnAceptarVentaModificar.Location = new System.Drawing.Point(104, 246);
            this.btnAceptarVentaModificar.Name = "btnAceptarVentaModificar";
            this.btnAceptarVentaModificar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarVentaModificar.TabIndex = 9;
            this.btnAceptarVentaModificar.Text = "Aceptar";
            this.btnAceptarVentaModificar.UseVisualStyleBackColor = true;
            // 
            // EditarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 281);
            this.Controls.Add(this.btnAceptarVentaModificar);
            this.Controls.Add(this.btnCancelarVentaModificar);
            this.Controls.Add(this.txtPrecioVentaModificar);
            this.Controls.Add(this.txtBastidorVentaModificar);
            this.Controls.Add(this.txtDniVentaModificar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "EditarVenta";
            this.Text = "Editar venta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDniVentaModificar;
        private System.Windows.Forms.TextBox txtBastidorVentaModificar;
        private System.Windows.Forms.TextBox txtPrecioVentaModificar;
        private System.Windows.Forms.Button btnCancelarVentaModificar;
        private System.Windows.Forms.Button btnAceptarVentaModificar;
    }
}