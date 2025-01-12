namespace CajaComplete
{
    partial class Main
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            label3 = new Label();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(99, 33);
            label1.Name = "label1";
            label1.Size = new Size(118, 37);
            label1.TabIndex = 0;
            label1.Text = "VetsCaja";
            // 
            // button1
            // 
            button1.Location = new Point(99, 124);
            button1.Name = "button1";
            button1.Size = new Size(112, 71);
            button1.TabIndex = 1;
            button1.Text = "Pago De Servicios";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(99, 240);
            button2.Name = "button2";
            button2.Size = new Size(112, 66);
            button2.TabIndex = 2;
            button2.Text = "Ver Transacciones";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(99, 337);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "Ver Clientes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(99, 415);
            button4.Name = "button4";
            button4.Size = new Size(118, 60);
            button4.TabIndex = 4;
            button4.Text = "Cuadre de Caja";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(323, 50);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 49);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 6;
            label3.Text = "Fecha:";
            // 
            // button5
            // 
            button5.Location = new Point(267, 124);
            button5.Name = "button5";
            button5.Size = new Size(112, 71);
            button5.TabIndex = 7;
            button5.Text = "Nuevo Cliente";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Main
            // 
            ClientSize = new Size(437, 520);
            Controls.Add(button5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Main";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
       
        private Label lblInicio;
        private Label lblInicioMonto;
        private Button BtnClient;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label2;
        private Label label3;
        private Button button5;
    }
}