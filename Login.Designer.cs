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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.circlePicture1 = new AppProyectoBD.CirclePicture();
            this.ses = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCerrar
            // 
            this.pbCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCerrar.BackColor = System.Drawing.Color.Transparent;
            this.pbCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(325, 3);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(24, 24);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCerrar.TabIndex = 14;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // pbMin
            // 
            this.pbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMin.BackColor = System.Drawing.Color.Transparent;
            this.pbMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMin.Image = ((System.Drawing.Image)(resources.GetObject("pbMin.Image")));
            this.pbMin.Location = new System.Drawing.Point(295, 3);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(24, 24);
            this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMin.TabIndex = 12;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 241);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 27);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(22, 175);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 27);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gothic A1", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 38);
            this.label1.TabIndex = 21;
            this.label1.Text = "LOGIN\r\n";
            // 
            // circlePicture1
            // 
            this.circlePicture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.circlePicture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circlePicture1.Image = ((System.Drawing.Image)(resources.GetObject("circlePicture1.Image")));
            this.circlePicture1.Location = new System.Drawing.Point(118, 40);
            this.circlePicture1.Name = "circlePicture1";
            this.circlePicture1.Size = new System.Drawing.Size(123, 122);
            this.circlePicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circlePicture1.TabIndex = 11;
            this.circlePicture1.TabStop = false;
            // 
            // ses
            // 
            this.ses.AutoSize = true;
            this.ses.Font = new System.Drawing.Font("Gothic A1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ses.Location = new System.Drawing.Point(148, 353);
            this.ses.Name = "ses";
            this.ses.Size = new System.Drawing.Size(51, 19);
            this.ses.TabIndex = 25;
            this.ses.Text = "SESION";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(72, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 45);
            this.button1.TabIndex = 26;
            this.button1.Text = "INGRESAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.Location = new System.Drawing.Point(62, 175);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(257, 27);
            this.tbUser.TabIndex = 27;
            // 
            // tbPwd
            // 
            this.tbPwd.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPwd.Location = new System.Drawing.Point(62, 241);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(257, 27);
            this.tbPwd.TabIndex = 28;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(350, 381);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.pbMin);
            this.Controls.Add(this.circlePicture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Opacity = 0.95D;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePicture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private CirclePicture circlePicture1;
		private System.Windows.Forms.PictureBox pbCerrar;
		private System.Windows.Forms.PictureBox pbMin;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPwd;
    }
}