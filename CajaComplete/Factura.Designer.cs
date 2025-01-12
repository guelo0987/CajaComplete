namespace CajaComplete
{
    partial class Factura
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
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox5 = new TextBox();
            label9 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(269, 28);
            label1.Name = "label1";
            label1.Size = new Size(305, 41);
            label1.TabIndex = 1;
            label1.Text = "PAGOS DE SERVICIOS";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(133, 256);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 17;
            label6.Text = "Servicio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(133, 351);
            label7.Name = "label7";
            label7.Size = new Size(117, 20);
            label7.TabIndex = 16;
            label7.Text = "El Usuario pago:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(133, 181);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 15;
            label8.Text = "Sucursal";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(269, 348);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(133, 116);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 10;
            label9.Text = "Cliente";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(244, 108);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(374, 28);
            comboBox1.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(269, 181);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 19;
            label2.Text = "label2";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(225, 256);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(373, 28);
            comboBox2.TabIndex = 20;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(475, 337);
            button1.Name = "button1";
            button1.Size = new Size(143, 74);
            button1.TabIndex = 21;
            button1.Text = "Cobrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 289);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 22;
            label3.Text = "Precio :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 294);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 23;
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(textBox5);
            Controls.Add(label9);
            Controls.Add(label1);
            Name = "Factura";
            Text = "Factura";
            Load += Factura_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox5;
        private Label label9;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Button button1;
        private Label label3;
        private Label label4;
    }
}