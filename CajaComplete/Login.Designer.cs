namespace CajaComplete
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {



            label2 = new Label();
            username = new TextBox();
            password = new TextBox();
            btnlogin = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 56);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 0;
            label2.Text = "login";
            // 
            // username
            // 
            username.Location = new Point(336, 116);
            username.Name = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 1;
            // 
            // password
            // 
            password.Location = new Point(336, 179);
            password.Name = "password";
            password.Size = new Size(125, 27);
            password.TabIndex = 2;
            
            // btnlogin
            btnlogin.Location = new Point(343, 242);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(94, 29);
            btnlogin.TabIndex = 3;
            btnlogin.Text = "Log in";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += new EventHandler(BtnLogin_Click);
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnlogin);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(label2);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox username;
        private TextBox password;
        private Button btnlogin;
    }
}
