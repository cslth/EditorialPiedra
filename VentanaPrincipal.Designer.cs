namespace Inicio
{
    partial class VentanaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.buttonProyectos = new System.Windows.Forms.Button();
            this.buttonTrabajos = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFLP1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFLP2 = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelDias = new System.Windows.Forms.Label();
            this.labelEncargados = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.labelProy = new System.Windows.Forms.Label();
            this.labelFechas = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.buttonDwn = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDer = new System.Windows.Forms.Button();
            this.buttonIzq = new System.Windows.Forms.Button();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.panelFLP1.SuspendLayout();
            this.panelFLP2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonProyectos
            // 
            this.buttonProyectos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonProyectos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(136)))), ((int)(((byte)(143)))));
            this.buttonProyectos.FlatAppearance.BorderSize = 0;
            this.buttonProyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProyectos.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProyectos.Location = new System.Drawing.Point(6, 191);
            this.buttonProyectos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonProyectos.Name = "buttonProyectos";
            this.buttonProyectos.Size = new System.Drawing.Size(137, 59);
            this.buttonProyectos.TabIndex = 4;
            this.buttonProyectos.Text = "Proyectos";
            this.buttonProyectos.UseVisualStyleBackColor = false;
            this.buttonProyectos.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonTrabajos
            // 
            this.buttonTrabajos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTrabajos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(136)))), ((int)(((byte)(143)))));
            this.buttonTrabajos.FlatAppearance.BorderSize = 0;
            this.buttonTrabajos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrabajos.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrabajos.Location = new System.Drawing.Point(147, 191);
            this.buttonTrabajos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrabajos.Name = "buttonTrabajos";
            this.buttonTrabajos.Size = new System.Drawing.Size(137, 59);
            this.buttonTrabajos.TabIndex = 5;
            this.buttonTrabajos.Text = "Trabajos";
            this.buttonTrabajos.UseVisualStyleBackColor = false;
            this.buttonTrabajos.Click += new System.EventHandler(this.buttonTrabajos_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.ForeColor = System.Drawing.Color.Chocolate;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(301, 225);
            this.flowLayoutPanel2.TabIndex = 8;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // panelFLP1
            // 
            this.panelFLP1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelFLP1.Controls.Add(this.flowLayoutPanel1);
            this.panelFLP1.Location = new System.Drawing.Point(64, 6);
            this.panelFLP1.Margin = new System.Windows.Forms.Padding(2);
            this.panelFLP1.Name = "panelFLP1";
            this.panelFLP1.Size = new System.Drawing.Size(735, 158);
            this.panelFLP1.TabIndex = 9;
            this.panelFLP1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_2);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.Chocolate;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(739, 181);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panelFLP2
            // 
            this.panelFLP2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelFLP2.Controls.Add(this.flowLayoutPanel2);
            this.panelFLP2.Location = new System.Drawing.Point(6, 255);
            this.panelFLP2.Margin = new System.Windows.Forms.Padding(2);
            this.panelFLP2.Name = "panelFLP2";
            this.panelFLP2.Size = new System.Drawing.Size(251, 206);
            this.panelFLP2.TabIndex = 10;
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Controls.Add(this.labelDias);
            this.panelInfo.Controls.Add(this.labelEncargados);
            this.panelInfo.Controls.Add(this.labelDescripcion);
            this.panelInfo.Controls.Add(this.labelProy);
            this.panelInfo.Controls.Add(this.labelFechas);
            this.panelInfo.Controls.Add(this.labelNombre);
            this.panelInfo.Location = new System.Drawing.Point(289, 191);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(2);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(570, 270);
            this.panelInfo.TabIndex = 13;
            this.panelInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel16_Paint_1);
            // 
            // labelDias
            // 
            this.labelDias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDias.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDias.Location = new System.Drawing.Point(208, 55);
            this.labelDias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDias.Name = "labelDias";
            this.labelDias.Size = new System.Drawing.Size(138, 36);
            this.labelDias.TabIndex = 6;
            this.labelDias.Click += new System.EventHandler(this.labelDias_Click);
            // 
            // labelEncargados
            // 
            this.labelEncargados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEncargados.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncargados.Location = new System.Drawing.Point(350, 55);
            this.labelEncargados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEncargados.Name = "labelEncargados";
            this.labelEncargados.Size = new System.Drawing.Size(214, 212);
            this.labelEncargados.TabIndex = 1;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDescripcion.Font = new System.Drawing.Font("Gothic A1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.Location = new System.Drawing.Point(6, 140);
            this.labelDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(340, 127);
            this.labelDescripcion.TabIndex = 5;
            // 
            // labelProy
            // 
            this.labelProy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelProy.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProy.Location = new System.Drawing.Point(6, 98);
            this.labelProy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProy.Name = "labelProy";
            this.labelProy.Size = new System.Drawing.Size(340, 36);
            this.labelProy.TabIndex = 3;
            // 
            // labelFechas
            // 
            this.labelFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFechas.Font = new System.Drawing.Font("Gothic A1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechas.Location = new System.Drawing.Point(6, 55);
            this.labelFechas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFechas.Name = "labelFechas";
            this.labelFechas.Size = new System.Drawing.Size(198, 36);
            this.labelFechas.TabIndex = 2;
            this.labelFechas.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNombre.Font = new System.Drawing.Font("Gothic A1", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(6, 6);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(558, 41);
            this.labelNombre.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 10;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // buttonDwn
            // 
            this.buttonDwn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDwn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.buttonDwn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDwn.FlatAppearance.BorderSize = 0;
            this.buttonDwn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDwn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDwn.Location = new System.Drawing.Point(261, 358);
            this.buttonDwn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDwn.Name = "buttonDwn";
            this.buttonDwn.Size = new System.Drawing.Size(23, 103);
            this.buttonDwn.TabIndex = 17;
            this.buttonDwn.UseVisualStyleBackColor = false;
            this.buttonDwn.Click += new System.EventHandler(this.button6_Click);
            this.buttonDwn.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            this.buttonDwn.MouseHover += new System.EventHandler(this.button6_MouseHover);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUp.FlatAppearance.BorderSize = 0;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUp.Location = new System.Drawing.Point(261, 255);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(23, 103);
            this.buttonUp.TabIndex = 16;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button5_MouseClick);
            this.buttonUp.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            this.buttonUp.MouseHover += new System.EventHandler(this.button5_MouseHover);
            // 
            // buttonDer
            // 
            this.buttonDer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.buttonDer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDer.FlatAppearance.BorderSize = 0;
            this.buttonDer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDer.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDer.Location = new System.Drawing.Point(809, 11);
            this.buttonDer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDer.Name = "buttonDer";
            this.buttonDer.Size = new System.Drawing.Size(44, 149);
            this.buttonDer.TabIndex = 15;
            this.buttonDer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDer.UseVisualStyleBackColor = false;
            this.buttonDer.Click += new System.EventHandler(this.button4_Click);
            this.buttonDer.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            this.buttonDer.MouseHover += new System.EventHandler(this.button4_MouseHover);
            // 
            // buttonIzq
            // 
            this.buttonIzq.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonIzq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.buttonIzq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonIzq.FlatAppearance.BorderSize = 0;
            this.buttonIzq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIzq.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIzq.Location = new System.Drawing.Point(8, 11);
            this.buttonIzq.Margin = new System.Windows.Forms.Padding(2);
            this.buttonIzq.Name = "buttonIzq";
            this.buttonIzq.Size = new System.Drawing.Size(44, 149);
            this.buttonIzq.TabIndex = 14;
            this.buttonIzq.UseVisualStyleBackColor = false;
            this.buttonIzq.Click += new System.EventHandler(this.button3_Click);
            this.buttonIzq.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.buttonIzq.MouseHover += new System.EventHandler(this.button3_MouseHover);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(864, 472);
            this.Controls.Add(this.buttonDwn);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDer);
            this.Controls.Add(this.buttonIzq);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelFLP2);
            this.Controls.Add(this.panelFLP1);
            this.Controls.Add(this.buttonTrabajos);
            this.Controls.Add(this.buttonProyectos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VentanaPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.VentanaPrincipal_SizeChanged);
            this.panelFLP1.ResumeLayout(false);
            this.panelFLP2.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.Button buttonProyectos;
        private System.Windows.Forms.Button buttonTrabajos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panelFLP1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelFLP2;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonIzq;
        private System.Windows.Forms.Button buttonDer;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDwn;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Label labelFechas;
        private System.Windows.Forms.Label labelEncargados;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label labelProy;
        private System.Windows.Forms.Label labelDias;
    }
}

