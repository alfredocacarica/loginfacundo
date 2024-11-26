namespace MiAplicacion
{
    partial class VerificationCodeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnEnableCode; // Declarar el botón

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
            this.btnEnableCode = new System.Windows.Forms.Button(); // Declarar el botón
            this.lblCode = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtCode
            this.txtCode.Location = new System.Drawing.Point(130, 27);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 20);
            this.txtCode.TabIndex = 1;

            // btnVerify
            this.btnVerify.Location = new System.Drawing.Point(105, 70);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(100, 30);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verificar Código";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            // btnEnableCode
            this.btnEnableCode.Location = new System.Drawing.Point(130, 60);
            this.btnEnableCode.Name = "btnEnableCode";
            this.btnEnableCode.Size = new System.Drawing.Size(100, 23);
            this.btnEnableCode.TabIndex = 3;
            this.btnEnableCode.Text = "Habilitar Código";
            this.btnEnableCode.UseVisualStyleBackColor = true;
            this.btnEnableCode.Click += new System.EventHandler(this.btnEnableCode_Click);

            // lblCode
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(30, 30);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(94, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Código de Verificación:";

            // VerificationCodeForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 120);
            this.Controls.Add(this.btnEnableCode);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Name = "VerificationCodeForm";
            this.Text = "Verificación de Código";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
