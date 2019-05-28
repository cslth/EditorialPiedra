namespace AppProyectoBD
{
    partial class AgregarTipoTrabajoEmpleado
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
			this.label2 = new System.Windows.Forms.Label();
			this.descripcion = new System.Windows.Forms.RichTextBox();
			this.nombre = new System.Windows.Forms.TextBox();
			this.cerrar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.guardar = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 21);
			this.label2.TabIndex = 57;
			this.label2.Text = "Descripción";
			// 
			// descripcion
			// 
			this.descripcion.Font = new System.Drawing.Font("Gothic A1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.descripcion.Location = new System.Drawing.Point(133, 83);
			this.descripcion.Name = "descripcion";
			this.descripcion.Size = new System.Drawing.Size(228, 81);
			this.descripcion.TabIndex = 56;
			this.descripcion.Text = "";
			// 
			// nombre
			// 
			this.nombre.Font = new System.Drawing.Font("Gothic A1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nombre.Location = new System.Drawing.Point(133, 45);
			this.nombre.Name = "nombre";
			this.nombre.Size = new System.Drawing.Size(228, 22);
			this.nombre.TabIndex = 51;
			// 
			// cerrar
			// 
			this.cerrar.BackColor = System.Drawing.Color.Transparent;
			this.cerrar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cerrar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cerrar.Location = new System.Drawing.Point(17, 170);
			this.cerrar.Name = "cerrar";
			this.cerrar.Size = new System.Drawing.Size(72, 34);
			this.cerrar.TabIndex = 49;
			this.cerrar.Text = "Cerrar";
			this.cerrar.UseVisualStyleBackColor = false;
			this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 21);
			this.label4.TabIndex = 52;
			this.label4.Text = "Nombre";
			// 
			// guardar
			// 
			this.guardar.BackColor = System.Drawing.Color.Transparent;
			this.guardar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.guardar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guardar.Location = new System.Drawing.Point(289, 170);
			this.guardar.Name = "guardar";
			this.guardar.Size = new System.Drawing.Size(72, 34);
			this.guardar.TabIndex = 55;
			this.guardar.Text = "Guardar";
			this.guardar.UseVisualStyleBackColor = false;
			this.guardar.Click += new System.EventHandler(this.guardar_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(391, 221);
			this.panel1.TabIndex = 58;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			// 
			// panel7
			// 
			this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
			this.panel7.Controls.Add(this.label1);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(389, 30);
			this.panel7.TabIndex = 51;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Gothic A1", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(389, 30);
			this.label1.TabIndex = 33;
			this.label1.Text = "TIPO DE TRABAJO";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
			// 
			// AgregarTipoTrabajoEmpleado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(391, 221);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.descripcion);
			this.Controls.Add(this.nombre);
			this.Controls.Add(this.cerrar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.guardar);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AgregarTipoTrabajoEmpleado";
			this.Text = "AgregarTipoTrabajo";
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox descripcion;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
    }
}