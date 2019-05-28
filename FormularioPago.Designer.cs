namespace AppProyectoBD
{
    partial class FormularioPago
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
            this.cerrar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.labTrabajo = new System.Windows.Forms.Label();
            this.labEmpleado = new System.Windows.Forms.Label();
            this.pagosrestantes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PagoGasto = new System.Windows.Forms.ComboBox();
            this.labConcepto = new System.Windows.Forms.Label();
            this.textConcepto = new System.Windows.Forms.TextBox();
            this.monto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.metodoPago = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.eliminar = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.trabajo = new System.Windows.Forms.TextBox();
            this.empleado = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // cerrar
            // 
            this.cerrar.BackColor = System.Drawing.Color.Transparent;
            this.cerrar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrar.Location = new System.Drawing.Point(19, 334);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(72, 34);
            this.cerrar.TabIndex = 29;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.Transparent;
            this.aceptar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.Location = new System.Drawing.Point(292, 334);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(72, 34);
            this.aceptar.TabIndex = 28;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // labTrabajo
            // 
            this.labTrabajo.AutoSize = true;
            this.labTrabajo.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTrabajo.Location = new System.Drawing.Point(15, 128);
            this.labTrabajo.Name = "labTrabajo";
            this.labTrabajo.Size = new System.Drawing.Size(54, 21);
            this.labTrabajo.TabIndex = 27;
            this.labTrabajo.Text = "Trabajo";
            // 
            // labEmpleado
            // 
            this.labEmpleado.AutoSize = true;
            this.labEmpleado.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEmpleado.Location = new System.Drawing.Point(15, 88);
            this.labEmpleado.Name = "labEmpleado";
            this.labEmpleado.Size = new System.Drawing.Size(69, 21);
            this.labEmpleado.TabIndex = 25;
            this.labEmpleado.Text = "Empleado";
            // 
            // pagosrestantes
            // 
            this.pagosrestantes.AutoSize = true;
            this.pagosrestantes.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagosrestantes.Location = new System.Drawing.Point(132, 172);
            this.pagosrestantes.Name = "pagosrestantes";
            this.pagosrestantes.Size = new System.Drawing.Size(97, 21);
            this.pagosrestantes.TabIndex = 31;
            this.pagosrestantes.Text = "Pagos totales : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 21);
            this.label4.TabIndex = 33;
            this.label4.Text = "Tipo";
            // 
            // PagoGasto
            // 
            this.PagoGasto.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PagoGasto.FormattingEnabled = true;
            this.PagoGasto.Items.AddRange(new object[] {
            "Pago programado",
            "Gasto"});
            this.PagoGasto.Location = new System.Drawing.Point(136, 43);
            this.PagoGasto.Name = "PagoGasto";
            this.PagoGasto.Size = new System.Drawing.Size(228, 29);
            this.PagoGasto.TabIndex = 32;
            this.PagoGasto.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // labConcepto
            // 
            this.labConcepto.AutoSize = true;
            this.labConcepto.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConcepto.Location = new System.Drawing.Point(15, 205);
            this.labConcepto.Name = "labConcepto";
            this.labConcepto.Size = new System.Drawing.Size(66, 21);
            this.labConcepto.TabIndex = 35;
            this.labConcepto.Text = "Concepto";
            // 
            // textConcepto
            // 
            this.textConcepto.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConcepto.Location = new System.Drawing.Point(136, 203);
            this.textConcepto.Multiline = true;
            this.textConcepto.Name = "textConcepto";
            this.textConcepto.Size = new System.Drawing.Size(228, 30);
            this.textConcepto.TabIndex = 36;
            // 
            // monto
            // 
            this.monto.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monto.Location = new System.Drawing.Point(136, 287);
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(102, 24);
            this.monto.TabIndex = 38;
            this.monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.monto_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "Monto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(114, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 21);
            this.label8.TabIndex = 39;
            this.label8.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 21);
            this.label9.TabIndex = 41;
            this.label9.Text = "Método";
            // 
            // metodoPago
            // 
            this.metodoPago.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metodoPago.FormattingEnabled = true;
            this.metodoPago.Location = new System.Drawing.Point(136, 243);
            this.metodoPago.Name = "metodoPago";
            this.metodoPago.Size = new System.Drawing.Size(228, 29);
            this.metodoPago.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.eliminar);
            this.panel1.Controls.Add(this.editar);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.trabajo);
            this.panel1.Controls.Add(this.metodoPago);
            this.panel1.Controls.Add(this.empleado);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.monto);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textConcepto);
            this.panel1.Controls.Add(this.labConcepto);
            this.panel1.Controls.Add(this.cerrar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.aceptar);
            this.panel1.Controls.Add(this.PagoGasto);
            this.panel1.Controls.Add(this.labEmpleado);
            this.panel1.Controls.Add(this.pagosrestantes);
            this.panel1.Controls.Add(this.labTrabajo);
            this.panel1.Controls.Add(this.guardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 381);
            this.panel1.TabIndex = 42;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // eliminar
            // 
            this.eliminar.BackColor = System.Drawing.Color.Transparent;
            this.eliminar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminar.Location = new System.Drawing.Point(97, 334);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(72, 34);
            this.eliminar.TabIndex = 43;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseVisualStyleBackColor = false;
            this.eliminar.Click += new System.EventHandler(this.eiminar_Click);
            // 
            // editar
            // 
            this.editar.BackColor = System.Drawing.Color.Transparent;
            this.editar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editar.Location = new System.Drawing.Point(175, 334);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(72, 34);
            this.editar.TabIndex = 42;
            this.editar.Text = "Editar";
            this.editar.UseVisualStyleBackColor = false;
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // trabajo
            // 
            this.trabajo.Location = new System.Drawing.Point(136, 131);
            this.trabajo.Name = "trabajo";
            this.trabajo.Size = new System.Drawing.Size(228, 20);
            this.trabajo.TabIndex = 34;
            // 
            // empleado
            // 
            this.empleado.Location = new System.Drawing.Point(136, 89);
            this.empleado.Name = "empleado";
            this.empleado.Size = new System.Drawing.Size(228, 20);
            this.empleado.TabIndex = 33;
            // 
            // panel7
            // 
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(385, 30);
            this.panel7.TabIndex = 32;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown_1);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Gothic A1", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 30);
            this.label1.TabIndex = 33;
            this.label1.Text = "PAGO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // guardar
            // 
            this.guardar.BackColor = System.Drawing.Color.Transparent;
            this.guardar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardar.Font = new System.Drawing.Font("Gothic A1", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardar.Location = new System.Drawing.Point(175, 334);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(72, 34);
            this.guardar.TabIndex = 44;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = false;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // FormularioPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 381);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioPago";
            this.Text = "FormularioPago";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormularioPago_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormularioPago_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label labTrabajo;
        private System.Windows.Forms.Label labEmpleado;
        private System.Windows.Forms.Label pagosrestantes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PagoGasto;
        private System.Windows.Forms.Label labConcepto;
        private System.Windows.Forms.TextBox textConcepto;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox metodoPago;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox trabajo;
        private System.Windows.Forms.TextBox empleado;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button editar;
        private System.Windows.Forms.Button guardar;
    }
}