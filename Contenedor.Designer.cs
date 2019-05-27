namespace AppProyectoBD
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panelInfo = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbTitulo = new MaterialSkin.Controls.MaterialLabel();
			this.menu = new System.Windows.Forms.Button();
			this.sideBar = new System.Windows.Forms.Panel();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.usuario = new MaterialSkin.Controls.MaterialLabel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.reportes = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.trabajos = new System.Windows.Forms.Button();
			this.panel8 = new System.Windows.Forms.Panel();
			this.proyectos = new System.Windows.Forms.Button();
			this.panel9 = new System.Windows.Forms.Panel();
			this.empleados = new System.Windows.Forms.Button();
			this.inicio = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.pbCerrar = new System.Windows.Forms.PictureBox();
			this.pbMax = new System.Windows.Forms.PictureBox();
			this.pbMin = new System.Windows.Forms.PictureBox();
			this.circlePicture1 = new AppProyectoBD.CirclePicture();
			this.panel1.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel2.SuspendLayout();
			this.sideBar.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.circlePicture1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkGray;
			this.panel1.Controls.Add(this.panel10);
			this.panel1.Controls.Add(this.sideBar);
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1034, 561);
			this.panel1.TabIndex = 0;
			// 
			// panel10
			// 
			this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(228)))));
			this.panel10.Controls.Add(this.panelInfo);
			this.panel10.Controls.Add(this.panel2);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel10.Location = new System.Drawing.Point(170, 30);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(864, 531);
			this.panel10.TabIndex = 11;
			// 
			// panelInfo
			// 
			this.panelInfo.BackColor = System.Drawing.Color.White;
			this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelInfo.Location = new System.Drawing.Point(0, 38);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new System.Drawing.Size(864, 493);
			this.panelInfo.TabIndex = 10;
			this.panelInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInfo_Paint);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(136)))), ((int)(((byte)(143)))));
			this.panel2.Controls.Add(this.lbTitulo);
			this.panel2.Controls.Add(this.menu);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(864, 38);
			this.panel2.TabIndex = 9;
			// 
			// lbTitulo
			// 
			this.lbTitulo.AutoSize = true;
			this.lbTitulo.Depth = 0;
			this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lbTitulo.Location = new System.Drawing.Point(46, 8);
			this.lbTitulo.MouseState = MaterialSkin.MouseState.HOVER;
			this.lbTitulo.Name = "lbTitulo";
			this.lbTitulo.Size = new System.Drawing.Size(51, 18);
			this.lbTitulo.TabIndex = 10;
			this.lbTitulo.Text = "INICIO";
			// 
			// menu
			// 
			this.menu.FlatAppearance.BorderSize = 0;
			this.menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menu.Image = ((System.Drawing.Image)(resources.GetObject("menu.Image")));
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(40, 38);
			this.menu.TabIndex = 8;
			this.menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.menu.UseVisualStyleBackColor = true;
			this.menu.Click += new System.EventHandler(this.menu_Click_1);
			// 
			// sideBar
			// 
			this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(136)))), ((int)(((byte)(143)))));
			this.sideBar.Controls.Add(this.btnCerrar);
			this.sideBar.Controls.Add(this.circlePicture1);
			this.sideBar.Controls.Add(this.usuario);
			this.sideBar.Controls.Add(this.panel5);
			this.sideBar.Controls.Add(this.panel6);
			this.sideBar.Controls.Add(this.reportes);
			this.sideBar.Controls.Add(this.panel4);
			this.sideBar.Controls.Add(this.trabajos);
			this.sideBar.Controls.Add(this.panel8);
			this.sideBar.Controls.Add(this.proyectos);
			this.sideBar.Controls.Add(this.panel9);
			this.sideBar.Controls.Add(this.empleados);
			this.sideBar.Controls.Add(this.inicio);
			this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
			this.sideBar.Location = new System.Drawing.Point(0, 30);
			this.sideBar.Name = "sideBar";
			this.sideBar.Size = new System.Drawing.Size(170, 531);
			this.sideBar.TabIndex = 10;
			this.sideBar.Visible = false;
			// 
			// btnCerrar
			// 
			this.btnCerrar.FlatAppearance.BorderSize = 0;
			this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCerrar.Font = new System.Drawing.Font("Gothic A1", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCerrar.Location = new System.Drawing.Point(26, 484);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(123, 35);
			this.btnCerrar.TabIndex = 20;
			this.btnCerrar.Text = "CERRAR SESION";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
			// 
			// usuario
			// 
			this.usuario.AutoSize = true;
			this.usuario.Depth = 0;
			this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.usuario.Location = new System.Drawing.Point(50, 146);
			this.usuario.MouseState = MaterialSkin.MouseState.HOVER;
			this.usuario.Name = "usuario";
			this.usuario.Size = new System.Drawing.Size(75, 18);
			this.usuario.TabIndex = 9;
			this.usuario.Text = "USUARIO";
			this.usuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.CadetBlue;
			this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
			this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel5.Location = new System.Drawing.Point(0, 371);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(39, 35);
			this.panel5.TabIndex = 12;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.CadetBlue;
			this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
			this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel6.Location = new System.Drawing.Point(0, 326);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(39, 35);
			this.panel6.TabIndex = 18;
			this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
			// 
			// reportes
			// 
			this.reportes.FlatAppearance.BorderSize = 0;
			this.reportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.reportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reportes.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.reportes.Location = new System.Drawing.Point(38, 371);
			this.reportes.Name = "reportes";
			this.reportes.Size = new System.Drawing.Size(138, 35);
			this.reportes.TabIndex = 15;
			this.reportes.Text = "PAGOS";
			this.reportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.reportes.UseVisualStyleBackColor = true;
			this.reportes.Click += new System.EventHandler(this.reportes_Click);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.CadetBlue;
			this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
			this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel4.Location = new System.Drawing.Point(0, 282);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(39, 35);
			this.panel4.TabIndex = 13;
			// 
			// trabajos
			// 
			this.trabajos.FlatAppearance.BorderSize = 0;
			this.trabajos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.trabajos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.trabajos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.trabajos.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.trabajos.Location = new System.Drawing.Point(38, 326);
			this.trabajos.Name = "trabajos";
			this.trabajos.Size = new System.Drawing.Size(138, 35);
			this.trabajos.TabIndex = 19;
			this.trabajos.Text = "TRABAJOS";
			this.trabajos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.trabajos.UseVisualStyleBackColor = true;
			this.trabajos.Click += new System.EventHandler(this.trabajos_Click);
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.CadetBlue;
			this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
			this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel8.Location = new System.Drawing.Point(0, 238);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(39, 35);
			this.panel8.TabIndex = 14;
			// 
			// proyectos
			// 
			this.proyectos.FlatAppearance.BorderSize = 0;
			this.proyectos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.proyectos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.proyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.proyectos.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.proyectos.Location = new System.Drawing.Point(38, 282);
			this.proyectos.Name = "proyectos";
			this.proyectos.Size = new System.Drawing.Size(138, 35);
			this.proyectos.TabIndex = 16;
			this.proyectos.Text = "PROYECTOS";
			this.proyectos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.proyectos.UseVisualStyleBackColor = true;
			this.proyectos.Click += new System.EventHandler(this.proyectos_Click);
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.CadetBlue;
			this.panel9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel9.BackgroundImage")));
			this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel9.Location = new System.Drawing.Point(0, 193);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(39, 35);
			this.panel9.TabIndex = 10;
			// 
			// empleados
			// 
			this.empleados.FlatAppearance.BorderSize = 0;
			this.empleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.empleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.empleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.empleados.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.empleados.Location = new System.Drawing.Point(38, 238);
			this.empleados.Name = "empleados";
			this.empleados.Size = new System.Drawing.Size(138, 35);
			this.empleados.TabIndex = 17;
			this.empleados.Text = "EMPLEADOS";
			this.empleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.empleados.UseVisualStyleBackColor = true;
			this.empleados.Click += new System.EventHandler(this.empleados_Click);
			// 
			// inicio
			// 
			this.inicio.FlatAppearance.BorderSize = 0;
			this.inicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.inicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(189)))), ((int)(((byte)(188)))));
			this.inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.inicio.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inicio.Location = new System.Drawing.Point(38, 193);
			this.inicio.Name = "inicio";
			this.inicio.Size = new System.Drawing.Size(138, 35);
			this.inicio.TabIndex = 11;
			this.inicio.Text = "INICIO";
			this.inicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.inicio.UseVisualStyleBackColor = true;
			this.inicio.Click += new System.EventHandler(this.inicio_Click);
			// 
			// panel7
			// 
			this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
			this.panel7.Controls.Add(this.pbCerrar);
			this.panel7.Controls.Add(this.pbMax);
			this.panel7.Controls.Add(this.pbMin);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(1034, 30);
			this.panel7.TabIndex = 9;
			this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
			this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
			// 
			// pbCerrar
			// 
			this.pbCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbCerrar.BackColor = System.Drawing.Color.Transparent;
			this.pbCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
			this.pbCerrar.Location = new System.Drawing.Point(1005, 2);
			this.pbCerrar.Name = "pbCerrar";
			this.pbCerrar.Size = new System.Drawing.Size(24, 24);
			this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbCerrar.TabIndex = 11;
			this.pbCerrar.TabStop = false;
			this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
			// 
			// pbMax
			// 
			this.pbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbMax.BackColor = System.Drawing.Color.Transparent;
			this.pbMax.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbMax.Image = ((System.Drawing.Image)(resources.GetObject("pbMax.Image")));
			this.pbMax.Location = new System.Drawing.Point(976, 2);
			this.pbMax.Name = "pbMax";
			this.pbMax.Size = new System.Drawing.Size(24, 24);
			this.pbMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbMax.TabIndex = 11;
			this.pbMax.TabStop = false;
			this.pbMax.Click += new System.EventHandler(this.pbMax_Click);
			// 
			// pbMin
			// 
			this.pbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbMin.BackColor = System.Drawing.Color.Transparent;
			this.pbMin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbMin.Image = ((System.Drawing.Image)(resources.GetObject("pbMin.Image")));
			this.pbMin.Location = new System.Drawing.Point(947, 2);
			this.pbMin.Name = "pbMin";
			this.pbMin.Size = new System.Drawing.Size(24, 24);
			this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbMin.TabIndex = 10;
			this.pbMin.TabStop = false;
			this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
			// 
			// circlePicture1
			// 
			this.circlePicture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.circlePicture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.circlePicture1.Image = ((System.Drawing.Image)(resources.GetObject("circlePicture1.Image")));
			this.circlePicture1.Location = new System.Drawing.Point(26, 21);
			this.circlePicture1.Name = "circlePicture1";
			this.circlePicture1.Size = new System.Drawing.Size(123, 122);
			this.circlePicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.circlePicture1.TabIndex = 0;
			this.circlePicture1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(1034, 561);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "Piedra";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.sideBar.ResumeLayout(false);
			this.sideBar.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.circlePicture1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbMax;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel lbTitulo;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Panel sideBar;
        private CirclePicture circlePicture1;
        private MaterialSkin.Controls.MaterialLabel usuario;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button reportes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button trabajos;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button proyectos;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button empleados;
        private System.Windows.Forms.Button inicio;
        private System.Windows.Forms.Button btnCerrar;
    }
}

