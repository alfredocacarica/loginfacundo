namespace MiAplicacion
{
    partial class ResetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNewPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 0;

            // txtNewPassword
            this.txtNewPassword.Location = new System.Drawing.Point(120, 70);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 20);
            this.txtNewPassword.TabIndex = 1;

            // btnResetPassword
            this.btnResetPassword.Location = new System.Drawing.Point(160, 110);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(100, 30);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "Resetear Contraseña";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(40, 33);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";

            // lblNewPassword
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(40, 73);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(83, 13);
            this.lblNewPassword.TabIndex = 4;
            this.lblNewPassword.Text = "Nueva Contraseña:";

            // ResetPasswordForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtEmail);
            this.Name = "ResetPasswordForm";
            this.Text = "Resetear Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
