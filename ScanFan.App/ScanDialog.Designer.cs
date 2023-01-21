namespace ScanFan.App
{
    partial class ScanDiolog
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
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Label_ScanMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(143, 113);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 0;
            this.Button_Cancel.Text = "Отмена";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Label_ScanMessage
            // 
            this.Label_ScanMessage.AutoSize = true;
            this.Label_ScanMessage.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_ScanMessage.Location = new System.Drawing.Point(12, 37);
            this.Label_ScanMessage.Name = "Label_ScanMessage";
            this.Label_ScanMessage.Size = new System.Drawing.Size(222, 25);
            this.Label_ScanMessage.TabIndex = 1;
            this.Label_ScanMessage.Text = "Отсканируйте штрих-код!";
            // 
            // ScanDiolog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 148);
            this.Controls.Add(this.Label_ScanMessage);
            this.Controls.Add(this.Button_Cancel);
            this.Name = "ScanDiolog";
            this.Text = "ScanDiolog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Label Label_ScanMessage;
    }
}