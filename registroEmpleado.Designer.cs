namespace PruebaA
{
	partial class registroEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registroEmpleado));
            this.label2 = new System.Windows.Forms.Label();
            this.fechaN = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_addWork = new System.Windows.Forms.Button();
            this.labelwork = new System.Windows.Forms.Label();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cbTipoTrab = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCiudad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRFC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbColonia = new System.Windows.Forms.TextBox();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tbCP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDelTels = new System.Windows.Forms.Button();
            this.btnAddTelNum = new System.Windows.Forms.Button();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.tablaTels = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDelRedes = new System.Windows.Forms.Button();
            this.cbRedes = new System.Windows.Forms.ComboBox();
            this.btnAddNet = new System.Windows.Forms.Button();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.tablaRedes = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.imgTrab1 = new PruebaA.CircularPictureBox();
            this.btn_DelWork = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRedes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrab1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gothic A1", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(61, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Añadir foto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // fechaN
            // 
            this.fechaN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fechaN.Location = new System.Drawing.Point(348, 492);
            this.fechaN.Name = "fechaN";
            this.fechaN.Size = new System.Drawing.Size(200, 20);
            this.fechaN.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(201, 491);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "Fecha de nacimiento:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(223, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "E-mail:*";
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(291, 104);
            this.tbEmail.MaxLength = 255;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(257, 24);
            this.tbEmail.TabIndex = 16;
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(291, 50);
            this.tbNombre.MaxLength = 255;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(257, 24);
            this.tbNombre.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(223, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre:*";
            // 
            // btn_addWork
            // 
            this.btn_addWork.BackColor = System.Drawing.Color.Transparent;
            this.btn_addWork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addWork.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addWork.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addWork.ForeColor = System.Drawing.Color.Black;
            this.btn_addWork.Location = new System.Drawing.Point(884, 34);
            this.btn_addWork.Name = "btn_addWork";
            this.btn_addWork.Size = new System.Drawing.Size(68, 36);
            this.btn_addWork.TabIndex = 51;
            this.btn_addWork.Text = "Añadir";
            this.btn_addWork.UseVisualStyleBackColor = false;
            this.btn_addWork.Click += new System.EventHandler(this.btn_addWork_Click);
            // 
            // labelwork
            // 
            this.labelwork.AutoSize = true;
            this.labelwork.BackColor = System.Drawing.SystemColors.Control;
            this.labelwork.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelwork.ForeColor = System.Drawing.Color.Black;
            this.labelwork.Location = new System.Drawing.Point(661, 74);
            this.labelwork.Name = "labelwork";
            this.labelwork.Size = new System.Drawing.Size(155, 15);
            this.labelwork.TabIndex = 50;
            this.labelwork.Text = "Aquí aparecen los trabajos...";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(658, 17);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(131, 19);
            this.materialLabel1.TabIndex = 49;
            this.materialLabel1.Text = "Tipo de trabajador";
            // 
            // cbTipoTrab
            // 
            this.cbTipoTrab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoTrab.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoTrab.ForeColor = System.Drawing.Color.Black;
            this.cbTipoTrab.FormattingEnabled = true;
            this.cbTipoTrab.Location = new System.Drawing.Point(663, 43);
            this.cbTipoTrab.Name = "cbTipoTrab";
            this.cbTipoTrab.Size = new System.Drawing.Size(191, 28);
            this.cbTipoTrab.TabIndex = 48;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(469, 550);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 17);
            this.radioButton2.TabIndex = 47;
            this.radioButton2.Text = "Femenino";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(378, 550);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 17);
            this.radioButton1.TabIndex = 46;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Masculino";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // tbEstado
            // 
            this.tbEstado.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEstado.Location = new System.Drawing.Point(291, 370);
            this.tbEstado.MaxLength = 255;
            this.tbEstado.Name = "tbEstado";
            this.tbEstado.Size = new System.Drawing.Size(257, 24);
            this.tbEstado.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(223, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Estado:";
            // 
            // tbCiudad
            // 
            this.tbCiudad.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCiudad.Location = new System.Drawing.Point(291, 316);
            this.tbCiudad.MaxLength = 255;
            this.tbCiudad.Name = "tbCiudad";
            this.tbCiudad.Size = new System.Drawing.Size(257, 24);
            this.tbCiudad.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(223, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "Ciudad: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(309, 550);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Sexo:*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(223, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 21);
            this.label4.TabIndex = 40;
            this.label4.Text = "RFC:";
            // 
            // tbRFC
            // 
            this.tbRFC.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRFC.Location = new System.Drawing.Point(291, 429);
            this.tbRFC.MaxLength = 255;
            this.tbRFC.Name = "tbRFC";
            this.tbRFC.Size = new System.Drawing.Size(257, 24);
            this.tbRFC.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(224, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 21);
            this.label9.TabIndex = 38;
            this.label9.Text = "Colonia:";
            // 
            // tbColonia
            // 
            this.tbColonia.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbColonia.Location = new System.Drawing.Point(291, 207);
            this.tbColonia.MaxLength = 255;
            this.tbColonia.Name = "tbColonia";
            this.tbColonia.Size = new System.Drawing.Size(257, 24);
            this.tbColonia.TabIndex = 37;
            // 
            // tbCalle
            // 
            this.tbCalle.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCalle.Location = new System.Drawing.Point(291, 158);
            this.tbCalle.MaxLength = 255;
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Size = new System.Drawing.Size(257, 24);
            this.tbCalle.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(223, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 35;
            this.label10.Text = "Calle:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(106, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 25);
            this.label13.TabIndex = 56;
            this.label13.Text = "+";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(855, 561);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 36);
            this.btnCancelar.TabIndex = 57;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(954, 561);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(93, 36);
            this.btnAceptar.TabIndex = 58;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(223, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 21);
            this.label14.TabIndex = 63;
            this.label14.Text = "CP:";
            // 
            // tbCP
            // 
            this.tbCP.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCP.Location = new System.Drawing.Point(291, 262);
            this.tbCP.MaxLength = 10;
            this.tbCP.Name = "tbCP";
            this.tbCP.Size = new System.Drawing.Size(257, 24);
            this.tbCP.TabIndex = 62;
            this.tbCP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCP_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(28, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 25);
            this.label11.TabIndex = 64;
            this.label11.Text = "NUEVO EMPLEADO";
            // 
            // btnDelTels
            // 
            this.btnDelTels.BackColor = System.Drawing.Color.Transparent;
            this.btnDelTels.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelTels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelTels.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelTels.ForeColor = System.Drawing.Color.Black;
            this.btnDelTels.Location = new System.Drawing.Point(979, 112);
            this.btnDelTels.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnDelTels.Name = "btnDelTels";
            this.btnDelTels.Size = new System.Drawing.Size(68, 36);
            this.btnDelTels.TabIndex = 69;
            this.btnDelTels.Text = "Borrar";
            this.btnDelTels.UseVisualStyleBackColor = false;
            this.btnDelTels.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddTelNum
            // 
            this.btnAddTelNum.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTelNum.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTelNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTelNum.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTelNum.ForeColor = System.Drawing.Color.Black;
            this.btnAddTelNum.Location = new System.Drawing.Point(884, 112);
            this.btnAddTelNum.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnAddTelNum.Name = "btnAddTelNum";
            this.btnAddTelNum.Size = new System.Drawing.Size(68, 36);
            this.btnAddTelNum.TabIndex = 68;
            this.btnAddTelNum.Text = "Añadir";
            this.btnAddTelNum.UseVisualStyleBackColor = false;
            this.btnAddTelNum.Click += new System.EventHandler(this.btnAddTelNum_Click);
            // 
            // tbTel
            // 
            this.tbTel.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTel.Location = new System.Drawing.Point(661, 128);
            this.tbTel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbTel.MaxLength = 20;
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(147, 24);
            this.tbTel.TabIndex = 67;
            this.tbTel.TextChanged += new System.EventHandler(this.tbTel_TextChanged);
            this.tbTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTel_KeyPress);
            // 
            // tablaTels
            // 
            this.tablaTels.AllowUserToDeleteRows = false;
            this.tablaTels.BackgroundColor = System.Drawing.Color.White;
            this.tablaTels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTels.Location = new System.Drawing.Point(663, 158);
            this.tablaTels.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tablaTels.Name = "tablaTels";
            this.tablaTels.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.tablaTels.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaTels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTels.Size = new System.Drawing.Size(385, 145);
            this.tablaTels.TabIndex = 66;
            this.tablaTels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaTels_CellContentClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(661, 104);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 65;
            this.label12.Text = "Teléfono";
            // 
            // btnDelRedes
            // 
            this.btnDelRedes.BackColor = System.Drawing.Color.Transparent;
            this.btnDelRedes.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelRedes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelRedes.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelRedes.ForeColor = System.Drawing.Color.Black;
            this.btnDelRedes.Location = new System.Drawing.Point(979, 330);
            this.btnDelRedes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelRedes.Name = "btnDelRedes";
            this.btnDelRedes.Size = new System.Drawing.Size(68, 36);
            this.btnDelRedes.TabIndex = 76;
            this.btnDelRedes.Text = "Borrar";
            this.btnDelRedes.UseVisualStyleBackColor = false;
            this.btnDelRedes.Click += new System.EventHandler(this.btnDelRedes_Click);
            // 
            // cbRedes
            // 
            this.cbRedes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRedes.FormattingEnabled = true;
            this.cbRedes.Location = new System.Drawing.Point(716, 321);
            this.cbRedes.Name = "cbRedes";
            this.cbRedes.Size = new System.Drawing.Size(116, 21);
            this.cbRedes.TabIndex = 75;
            // 
            // btnAddNet
            // 
            this.btnAddNet.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNet.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNet.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNet.ForeColor = System.Drawing.Color.Black;
            this.btnAddNet.Location = new System.Drawing.Point(884, 330);
            this.btnAddNet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNet.Name = "btnAddNet";
            this.btnAddNet.Size = new System.Drawing.Size(68, 36);
            this.btnAddNet.TabIndex = 74;
            this.btnAddNet.Text = "Añadir";
            this.btnAddNet.UseVisualStyleBackColor = false;
            this.btnAddNet.Click += new System.EventHandler(this.btnAddNet_Click);
            // 
            // tbCuenta
            // 
            this.tbCuenta.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCuenta.Location = new System.Drawing.Point(715, 345);
            this.tbCuenta.Margin = new System.Windows.Forms.Padding(2);
            this.tbCuenta.MaxLength = 255;
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.Size = new System.Drawing.Size(117, 24);
            this.tbCuenta.TabIndex = 73;
            // 
            // tablaRedes
            // 
            this.tablaRedes.AllowUserToDeleteRows = false;
            this.tablaRedes.BackgroundColor = System.Drawing.Color.White;
            this.tablaRedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaRedes.Location = new System.Drawing.Point(668, 379);
            this.tablaRedes.Margin = new System.Windows.Forms.Padding(2);
            this.tablaRedes.Name = "tablaRedes";
            this.tablaRedes.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.tablaRedes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaRedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaRedes.Size = new System.Drawing.Size(380, 154);
            this.tablaRedes.TabIndex = 72;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(660, 350);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 21);
            this.label15.TabIndex = 71;
            this.label15.Text = "Cuenta";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(659, 318);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 21);
            this.label16.TabIndex = 70;
            this.label16.Text = "Tipo";
            // 
            // imgTrab1
            // 
            this.imgTrab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.imgTrab1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgTrab1.Image = ((System.Drawing.Image)(resources.GetObject("imgTrab1.Image")));
            this.imgTrab1.Location = new System.Drawing.Point(18, 124);
            this.imgTrab1.Name = "imgTrab1";
            this.imgTrab1.Size = new System.Drawing.Size(195, 195);
            this.imgTrab1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgTrab1.TabIndex = 10;
            this.imgTrab1.TabStop = false;
            this.imgTrab1.Click += new System.EventHandler(this.imgTrab1_Click);
            // 
            // btn_DelWork
            // 
            this.btn_DelWork.BackColor = System.Drawing.Color.Transparent;
            this.btn_DelWork.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DelWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DelWork.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelWork.ForeColor = System.Drawing.Color.Black;
            this.btn_DelWork.Location = new System.Drawing.Point(981, 34);
            this.btn_DelWork.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btn_DelWork.Name = "btn_DelWork";
            this.btn_DelWork.Size = new System.Drawing.Size(66, 36);
            this.btn_DelWork.TabIndex = 77;
            this.btn_DelWork.Text = "Borrar";
            this.btn_DelWork.UseVisualStyleBackColor = false;
            this.btn_DelWork.Click += new System.EventHandler(this.btn_DelWork_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_DelWork);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnDelRedes);
            this.panel1.Controls.Add(this.btnAddNet);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnDelTels);
            this.panel1.Controls.Add(this.btnAddTelNum);
            this.panel1.Controls.Add(this.btn_addWork);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.imgTrab1);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 610);
            this.panel1.TabIndex = 78;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // registroEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1063, 610);
            this.Controls.Add(this.cbRedes);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.tablaRedes);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbTel);
            this.Controls.Add(this.tablaTels);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbCP);
            this.Controls.Add(this.labelwork);
            this.Controls.Add(this.cbTipoTrab);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.tbEstado);
            this.Controls.Add(this.tbCiudad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRFC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbColonia);
            this.Controls.Add(this.tbCalle);
            this.Controls.Add(this.fechaN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "registroEmpleado";
            this.Text = "registroEmpleado";
            this.Load += new System.EventHandler(this.registroEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaTels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRedes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrab1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private CircularPictureBox imgTrab1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker fechaN;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.TextBox tbNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_addWork;
		private System.Windows.Forms.Label labelwork;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private System.Windows.Forms.ComboBox cbTipoTrab;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox tbEstado;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbCiudad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbRFC;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbColonia;
		private System.Windows.Forms.TextBox tbCalle;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbCP;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnDelTels;
		private System.Windows.Forms.Button btnAddTelNum;
		private System.Windows.Forms.TextBox tbTel;
		private System.Windows.Forms.DataGridView tablaTels;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btnDelRedes;
		private System.Windows.Forms.ComboBox cbRedes;
		private System.Windows.Forms.Button btnAddNet;
		private System.Windows.Forms.TextBox tbCuenta;
		private System.Windows.Forms.DataGridView tablaRedes;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btn_DelWork;
        private System.Windows.Forms.Panel panel1;
    }
}