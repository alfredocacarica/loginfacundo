namespace MiAplicacion
{
    partial class VerificationCodeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label lblCode;

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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtCode
            this.txtCode.Location = new System.Drawing.Point(100, 30);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 20);
            this.txtCode.TabIndex = 0;

            // btnVerify
            this.btnVerify.Location = new System.Drawing.Point(130, 70);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Verificar";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            // lblCode
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(40, 33);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(43, 13);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Código:";

            // VerificationCodeForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 120);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtCode);
            this.Name = "VerificationCodeForm";
            this.Text = "Verificar Código";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
