namespace CajaComplete
{
    partial class CuadreCaja
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(240, 26);
            label1.Name = "label1";
            label1.Size = new Size(334, 54);
            label1.TabIndex = 0;
            label1.Text = "CUADRE DE CAJA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 134);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 1;
            label2.Text = "Monto Inicial";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 39);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 39);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(164, 169);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 4;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(392, 134);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 5;
            label6.Text = "Cajer@";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(399, 169);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 6;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(605, 134);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 7;
            label8.Text = "Sucursal";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(605, 169);
            label9.Name = "label9";
            label9.Size = new Size(50, 20);
            label9.TabIndex = 8;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(147, 276);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 10;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(135, 241);
            label11.Name = "label11";
            label11.Size = new Size(60, 20);
            label11.TabIndex = 9;
            label11.Text = "Entrada";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(319, 276);
            label12.Name = "label12";
            label12.Size = new Size(58, 20);
            label12.TabIndex = 12;
            label12.Text = "label12";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(307, 241);
            label13.Name = "label13";
            label13.Size = new Size(50, 20);
            label13.TabIndex = 11;
            label13.Text = "Salida";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(533, 241);
            label14.Name = "label14";
            label14.Size = new Size(100, 20);
            label14.TabIndex = 13;
            label14.Text = "Total_De_Hoy";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(549, 276);
            label15.Name = "label15";
            label15.Size = new Size(58, 20);
            label15.TabIndex = 14;
            label15.Text = "label15";
            // 
            // button1
            // 
            button1.Location = new Point(314, 353);
            button1.Name = "button1";
            button1.Size = new Size(172, 73);
            button1.TabIndex = 15;
            button1.Text = "Cuadrar y Generar Reporte";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CuadreCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CuadreCaja";
            Text = "CuadreCaja";
            Load += CuadreCaja_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Button button1;
    }
}