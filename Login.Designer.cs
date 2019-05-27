namespace AppProyectoBD
{
    partial class Login
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.usuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.pwd = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.pbCerrar = new System.Windows.Forms.PictureBox();
			this.pbMin = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
			this.SuspendLayout();
			// 
			// usuario
			// 
			this.usuario.Depth = 0;
			this.usuario.Hint = "";
			this.usuario.Location = new System.Drawing.Point(128, 196);
			this.usuario.MaxLength = 32767;
			this.usuario.MouseState = MaterialSkin.MouseState.HOVER;
			this.usuario.Name = "usuario";
			this.usuario.PasswordChar = '\0';
			this.usuario.SelectedText = "";
			this.usuario.SelectionLength = 0;
			this.usuario.SelectionStart = 0;
			this.usuario.Size = new System.Drawing.Size(173, 23);
			this.usuario.TabIndex = 11;
			this.usuario.TabStop = false;
			this.usuario.UseSystemPasswordChar = false;
			// 
			// pwd
			// 
			this.pwd.Depth = 0;
			this.pwd.Hint = "";
			this.pwd.Location = new System.Drawing.Point(128, 243);
			this.pwd.MaxLength = 32767;
			this.pwd.MouseState = MaterialSkin.MouseState.HOVER;
			this.pwd.Name = "pwd";
			this.pwd.PasswordChar = '*';
			this.pwd.SelectedText = "";
			this.pwd.SelectionLength = 0;
			this.pwd.SelectionStart = 0;
			this.pwd.Size = new System.Drawing.Size(173, 23);
			this.pwd.TabIndex = 14;
			this.pwd.TabStop = false;
			this.pwd.UseSystemPasswordChar = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(106, 36);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(126, 125);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Gothic A1", 9.75F);
			this.button1.Location = new System.Drawing.Point(14, 302);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 36);
			this.button1.TabIndex = 18;
			this.button1.Text = "INICIAR SESION";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(138, 302);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(184, 36);
			this.button2.TabIndex = 19;
			this.button2.Text = "RECUPERAR CONTRASEÑA";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(34, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 21);
			this.label1.TabIndex = 20;
			this.label1.Text = "Usuario";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(34, 247);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 21);
			this.label2.TabIndex = 21;
			this.label2.Text = "Contraseña";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(336, 372);
			this.panel1.TabIndex = 22;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// panel7
			// 
			this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
			this.panel7.Controls.Add(this.pbCerrar);
			this.panel7.Controls.Add(this.pbMin);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(334, 30);
			this.panel7.TabIndex = 11;
			this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown_1);
			// 
			// pbCerrar
			// 
			this.pbCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbCerrar.BackColor = System.Drawing.Color.Transparent;
			this.pbCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
			this.pbCerrar.Location = new System.Drawing.Point(305, 2);
			this.pbCerrar.Name = "pbCerrar";
			this.pbCerrar.Size = new System.Drawing.Size(24, 24);
			this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbCerrar.TabIndex = 11;
			this.pbCerrar.TabStop = false;
			this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click_1);
			// 
			// pbMin
			// 
			this.pbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbMin.BackColor = System.Drawing.Color.Transparent;
			this.pbMin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbMin.Image = ((System.Drawing.Image)(resources.GetObject("pbMin.Image")));
			this.pbMin.Location = new System.Drawing.Point(276, 2);
			this.pbMin.Name = "pbMin";
			this.pbMin.Size = new System.Drawing.Size(24, 24);
			this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbMin.TabIndex = 10;
			this.pbMin.TabStop = false;
			this.pbMin.Click += new System.EventHandler(this.pbMin_Click_1);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(336, 372);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pwd);
			this.Controls.Add(this.usuario);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Login";
			this.Text = "Login";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField usuario;
        private MaterialSkin.Controls.MaterialSingleLineTextField pwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pbMin;
    }
}