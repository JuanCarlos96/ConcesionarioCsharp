﻿namespace ConcesionarioCsharp
{
    partial class EditarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDniClienteModificar = new System.Windows.Forms.TextBox();
            this.txtNombreClienteModificar = new System.Windows.Forms.TextBox();
            this.txtApellidosClienteModificar = new System.Windows.Forms.TextBox();
            this.txtTelefonoClienteModificar = new System.Windows.Forms.TextBox();
            this.txtDireccionClienteModificar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Teléfono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección";
            // 
            // txtDniClienteModificar
            // 
            this.txtDniClienteModificar.Location = new System.Drawing.Point(15, 39);
            this.txtDniClienteModificar.Name = "txtDniClienteModificar";
            this.txtDniClienteModificar.Size = new System.Drawing.Size(135, 20);
            this.txtDniClienteModificar.TabIndex = 5;
            // 
            // txtNombreClienteModificar
            // 
            this.txtNombreClienteModificar.Location = new System.Drawing.Point(186, 40);
            this.txtNombreClienteModificar.Name = "txtNombreClienteModificar";
            this.txtNombreClienteModificar.Size = new System.Drawing.Size(135, 20);
            this.txtNombreClienteModificar.TabIndex = 6;
            // 
            // txtApellidosClienteModificar
            // 
            this.txtApellidosClienteModificar.Location = new System.Drawing.Point(15, 115);
            this.txtApellidosClienteModificar.Name = "txtApellidosClienteModificar";
            this.txtApellidosClienteModificar.Size = new System.Drawing.Size(135, 20);
            this.txtApellidosClienteModificar.TabIndex = 7;
            // 
            // txtTelefonoClienteModificar
            // 
            this.txtTelefonoClienteModificar.Location = new System.Drawing.Point(186, 115);
            this.txtTelefonoClienteModificar.Name = "txtTelefonoClienteModificar";
            this.txtTelefonoClienteModificar.Size = new System.Drawing.Size(135, 20);
            this.txtTelefonoClienteModificar.TabIndex = 8;
            // 
            // txtDireccionClienteModificar
            // 
            this.txtDireccionClienteModificar.Location = new System.Drawing.Point(15, 198);
            this.txtDireccionClienteModificar.Name = "txtDireccionClienteModificar";
            this.txtDireccionClienteModificar.Size = new System.Drawing.Size(306, 20);
            this.txtDireccionClienteModificar.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // EditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 272);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDireccionClienteModificar);
            this.Controls.Add(this.txtTelefonoClienteModificar);
            this.Controls.Add(this.txtApellidosClienteModificar);
            this.Controls.Add(this.txtNombreClienteModificar);
            this.Controls.Add(this.txtDniClienteModificar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarCliente";
            this.Text = "Editar cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDniClienteModificar;
        private System.Windows.Forms.TextBox txtNombreClienteModificar;
        private System.Windows.Forms.TextBox txtApellidosClienteModificar;
        private System.Windows.Forms.TextBox txtTelefonoClienteModificar;
        private System.Windows.Forms.TextBox txtDireccionClienteModificar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}