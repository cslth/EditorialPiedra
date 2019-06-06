namespace PruebaA
{
	partial class worker_project_registry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(worker_project_registry));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgTrab = new PruebaA.CircularPictureBox();
            this.lblFN = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaTipoEmpleado = new System.Windows.Forms.DataGridView();
            this.tablaTels = new System.Windows.Forms.DataGridView();
            this.tablaRedes = new System.Windows.Forms.DataGridView();
            this.lblRFC = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrab)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTipoEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRedes)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.imgTrab);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 566);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // imgTrab
            // 
            this.imgTrab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.imgTrab.Image = ((System.Drawing.Image)(resources.GetObject("imgTrab.Image")));
            this.imgTrab.Location = new System.Drawing.Point(3, 155);
            this.imgTrab.Name = "imgTrab";
            this.imgTrab.Size = new System.Drawing.Size(194, 191);
            this.imgTrab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgTrab.TabIndex = 0;
            this.imgTrab.TabStop = false;
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.BackColor = System.Drawing.SystemColors.Control;
            this.lblFN.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFN.ForeColor = System.Drawing.Color.Black;
            this.lblFN.Location = new System.Drawing.Point(13, 469);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(94, 21);
            this.lblFN.TabIndex = 8;
            this.lblFN.Text = "F. Nacimiento:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmail.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(16, 90);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 21);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "E-mail:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.SystemColors.Control;
            this.lblNombre.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(16, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 21);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tablaTipoEmpleado);
            this.panel1.Controls.Add(this.tablaTels);
            this.panel1.Controls.Add(this.tablaRedes);
            this.panel1.Controls.Add(this.lblRFC);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.lblSexo);
            this.panel1.Controls.Add(this.lblCiudad);
            this.panel1.Controls.Add(this.lblCP);
            this.panel1.Controls.Add(this.lblColonia);
            this.panel1.Controls.Add(this.lblCalle);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblFN);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel1.Location = new System.Drawing.Point(211, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 566);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(359, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 25);
            this.label3.TabIndex = 30;
            this.label3.Text = "TIPO DE TRABAJADOR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(359, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "TELEFONOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(359, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "REDES SOCIALES";
            // 
            // tablaTipoEmpleado
            // 
            this.tablaTipoEmpleado.AllowUserToDeleteRows = false;
            this.tablaTipoEmpleado.BackgroundColor = System.Drawing.Color.White;
            this.tablaTipoEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTipoEmpleado.Location = new System.Drawing.Point(364, 365);
            this.tablaTipoEmpleado.Name = "tablaTipoEmpleado";
            this.tablaTipoEmpleado.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.tablaTipoEmpleado.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tablaTipoEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTipoEmpleado.Size = new System.Drawing.Size(324, 137);
            this.tablaTipoEmpleado.TabIndex = 27;
            // 
            // tablaTels
            // 
            this.tablaTels.AllowUserToDeleteRows = false;
            this.tablaTels.BackgroundColor = System.Drawing.Color.White;
            this.tablaTels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTels.Location = new System.Drawing.Point(364, 35);
            this.tablaTels.Name = "tablaTels";
            this.tablaTels.ReadOnly = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.tablaTels.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tablaTels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTels.Size = new System.Drawing.Size(324, 124);
            this.tablaTels.TabIndex = 26;
            // 
            // tablaRedes
            // 
            this.tablaRedes.AllowUserToDeleteRows = false;
            this.tablaRedes.BackgroundColor = System.Drawing.Color.White;
            this.tablaRedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaRedes.Location = new System.Drawing.Point(364, 199);
            this.tablaRedes.Name = "tablaRedes";
            this.tablaRedes.ReadOnly = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.tablaRedes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.tablaRedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaRedes.Size = new System.Drawing.Size(324, 124);
            this.tablaRedes.TabIndex = 25;
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.BackColor = System.Drawing.SystemColors.Control;
            this.lblRFC.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFC.ForeColor = System.Drawing.Color.Black;
            this.lblRFC.Location = new System.Drawing.Point(13, 414);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(38, 21);
            this.lblRFC.TabIndex = 24;
            this.lblRFC.Text = "RFC:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Gothic A1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar.Location = new System.Drawing.Point(592, 520);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(95, 33);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.SystemColors.Control;
            this.lblEstado.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(16, 365);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 21);
            this.lblEstado.TabIndex = 19;
            this.lblEstado.Text = "Estado:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.BackColor = System.Drawing.SystemColors.Control;
            this.lblSexo.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexo.ForeColor = System.Drawing.Color.Black;
            this.lblSexo.Location = new System.Drawing.Point(16, 524);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(42, 21);
            this.lblSexo.TabIndex = 18;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.BackColor = System.Drawing.SystemColors.Control;
            this.lblCiudad.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.ForeColor = System.Drawing.Color.Black;
            this.lblCiudad.Location = new System.Drawing.Point(16, 308);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(55, 21);
            this.lblCiudad.TabIndex = 17;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.BackColor = System.Drawing.SystemColors.Control;
            this.lblCP.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.ForeColor = System.Drawing.Color.Black;
            this.lblCP.Location = new System.Drawing.Point(16, 252);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(34, 21);
            this.lblCP.TabIndex = 16;
            this.lblCP.Text = "C.P:";
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.BackColor = System.Drawing.SystemColors.Control;
            this.lblColonia.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonia.ForeColor = System.Drawing.Color.Black;
            this.lblColonia.Location = new System.Drawing.Point(13, 199);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(56, 21);
            this.lblColonia.TabIndex = 15;
            this.lblColonia.Text = "Colonia:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.BackColor = System.Drawing.SystemColors.Control;
            this.lblCalle.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.ForeColor = System.Drawing.Color.Black;
            this.lblCalle.Location = new System.Drawing.Point(16, 144);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(42, 21);
            this.lblCalle.TabIndex = 14;
            this.lblCalle.Text = "Calle:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnCerrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(698, 564);
            this.panel3.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "DATOS PERSONALES";
            // 
            // worker_project_registry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "worker_project_registry";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgTrab)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTipoEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRedes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblFN;
		private System.Windows.Forms.Label lblSexo;
		private System.Windows.Forms.Label lblCiudad;
		private System.Windows.Forms.Label lblCP;
		private System.Windows.Forms.Label lblColonia;
		private System.Windows.Forms.Label lblCalle;
		private System.Windows.Forms.Label lblEstado;
		private CircularPictureBox imgTrab;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Label lblRFC;
		private System.Windows.Forms.DataGridView tablaTipoEmpleado;
		private System.Windows.Forms.DataGridView tablaTels;
		private System.Windows.Forms.DataGridView tablaRedes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}