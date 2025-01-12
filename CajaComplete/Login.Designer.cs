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
            label2.Font = new Font("Segoe UI", 32F);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(205, 36);
            label2.Name = "label2";
            label2.Size = new Size(214, 72);
            label2.TabIndex = 0;
            label2.Text = "VetCare";
            // 
            // username
            // 
            username.Location = new Point(249, 157);
            username.Name = "username";
            username.PlaceholderText = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 1;
            // 
            // password
            // 
            password.Location = new Point(246, 221);
            password.Name = "password";
            password.PlaceholderText = "password";
            password.Size = new Size(125, 27);
            password.TabIndex = 2;
            // 
            // btnlogin
            // 
            btnlogin.Font = new Font("Segoe UI", 14F);
            btnlogin.Location = new Point(249, 284);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(110, 57);
            btnlogin.TabIndex = 3;
            btnlogin.Text = "Log in";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += BtnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(647, 422);
            Controls.Add(btnlogin);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(label2);
            Name = "Login";
            Text = "Log In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox username;
        private TextBox password;
        private Button btnlogin;
    }
}
