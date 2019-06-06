namespace PruebaA
{
	partial class Empleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.campoNombre = new System.Windows.Forms.TextBox();
            this.agregarEmpleado = new System.Windows.Forms.Button();
            this.tablaEmpleados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarEmp = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nom = new System.Windows.Forms.Label();
            this.tEmpleado = new System.Windows.Forms.Label();
            this.imgTrab = new PruebaA.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaEmpleados)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrab)).BeginInit();
            this.SuspendLayout();
            // 
            // campoNombre
            // 
            this.campoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.campoNombre.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoNombre.Location = new System.Drawing.Point(40, 82);
            this.campoNombre.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.campoNombre.Name = "campoNombre";
            this.campoNombre.Size = new System.Drawing.Size(212, 24);
            this.campoNombre.TabIndex = 8;
            this.campoNombre.TextChanged += new System.EventHandler(this.campoNombre_TextChanged);
            // 
            // agregarEmpleado
            // 
            this.agregarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.agregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agregarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.agregarEmpleado.FlatAppearance.BorderSize = 0;
            this.agregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregarEmpleado.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarEmpleado.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.agregarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("agregarEmpleado.Image")));
            this.agregarEmpleado.Location = new System.Drawing.Point(544, 71);
            this.agregarEmpleado.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.agregarEmpleado.Name = "agregarEmpleado";
            this.agregarEmpleado.Size = new System.Drawing.Size(35, 36);
            this.agregarEmpleado.TabIndex = 10;
            this.agregarEmpleado.UseVisualStyleBackColor = false;
            this.agregarEmpleado.Click += new System.EventHandler(this.agregarEmpleado_Click);
            // 
            // tablaEmpleados
            // 
            this.tablaEmpleados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tablaEmpleados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(136)))), ((int)(((byte)(143)))));
            this.tablaEmpleados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaEmpleados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaEmpleados.Location = new System.Drawing.Point(40, 118);
            this.tablaEmpleados.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.tablaEmpleados.Name = "tablaEmpleados";
            this.tablaEmpleados.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.tablaEmpleados.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaEmpleados.Size = new System.Drawing.Size(539, 356);
            this.tablaEmpleados.TabIndex = 6;
            this.tablaEmpleados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaEmpleados_CellClick);
            this.tablaEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaEmpleados_CellContentClick);
            this.tablaEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaEmpleados_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "INFORMACIÓN DE EMPLEADOS";
            // 
            // btnEliminarEmp
            // 
            this.btnEliminarEmp.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarEmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEmp.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEliminarEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEmp.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarEmp.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarEmp.Location = new System.Drawing.Point(459, 71);
            this.btnEliminarEmp.Name = "btnEliminarEmp";
            this.btnEliminarEmp.Size = new System.Drawing.Size(66, 36);
            this.btnEliminarEmp.TabIndex = 53;
            this.btnEliminarEmp.Text = "Borrar";
            this.btnEliminarEmp.UseVisualStyleBackColor = false;
            this.btnEliminarEmp.Click += new System.EventHandler(this.btnEliminarEmp_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Location = new System.Drawing.Point(387, 71);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(66, 36);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 55;
            this.label2.Text = "Nombre";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tEmpleado);
            this.panel1.Controls.Add(this.nom);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.imgTrab);
            this.panel1.Location = new System.Drawing.Point(587, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 492);
            this.panel1.TabIndex = 56;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gothic A1", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(136)))), ((int)(((byte)(143)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(4, 302);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(260, 136);
            this.dataGridView1.TabIndex = 57;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 58;
            this.label4.Text = "TRABAJOS";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(101, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 30);
            this.button1.TabIndex = 59;
            this.button1.Text = "Ver todo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gothic A1", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 60;
            this.label5.Text = "Tipo de empleado";
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.Location = new System.Drawing.Point(3, 198);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(38, 21);
            this.nom.TabIndex = 61;
            this.nom.Text = "----";
            // 
            // tEmpleado
            // 
            this.tEmpleado.AutoSize = true;
            this.tEmpleado.Location = new System.Drawing.Point(3, 245);
            this.tEmpleado.Name = "tEmpleado";
            this.tEmpleado.Size = new System.Drawing.Size(38, 21);
            this.tEmpleado.TabIndex = 62;
            this.tEmpleado.Text = "----";
            // 
            // imgTrab
            // 
            this.imgTrab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.imgTrab.Image = ((System.Drawing.Image)(resources.GetObject("imgTrab.Image")));
            this.imgTrab.Location = new System.Drawing.Point(56, 12);
            this.imgTrab.Name = "imgTrab";
            this.imgTrab.Size = new System.Drawing.Size(165, 162);
            this.imgTrab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgTrab.TabIndex = 1;
            this.imgTrab.TabStop = false;
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(857, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminarEmp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.agregarEmpleado);
            this.Controls.Add(this.campoNombre);
            this.Controls.Add(this.tablaEmpleados);
            this.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Empleados";
            this.Text = "Empleados";
            this.Load += new System.EventHandler(this.Empleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaEmpleados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button agregarEmpleado;
		private System.Windows.Forms.DataGridView tablaEmpleados;
		private System.Windows.Forms.TextBox campoNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEliminarEmp;
		private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private CircularPictureBox imgTrab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tEmpleado;
        private System.Windows.Forms.Label nom;
    }
}