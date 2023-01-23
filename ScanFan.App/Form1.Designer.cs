namespace ScanFan.App
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.ListView_Types = new System.Windows.Forms.ListView();
            this.ListBox_Log = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(12, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(460, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListView_Types
            // 
            this.ListView_Types.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListView_Types.HideSelection = false;
            this.ListView_Types.Location = new System.Drawing.Point(12, 12);
            this.ListView_Types.Name = "ListView_Types";
            this.ListView_Types.Size = new System.Drawing.Size(460, 379);
            this.ListView_Types.TabIndex = 2;
            this.ListView_Types.UseCompatibleStateImageBehavior = false;
            // 
            // ListBox_Log
            // 
            this.ListBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Log.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListBox_Log.FormattingEnabled = true;
            this.ListBox_Log.ItemHeight = 25;
            this.ListBox_Log.Location = new System.Drawing.Point(494, 12);
            this.ListBox_Log.Name = "ListBox_Log";
            this.ListBox_Log.Size = new System.Drawing.Size(294, 379);
            this.ListBox_Log.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListBox_Log);
            this.Controls.Add(this.ListView_Types);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ListView_Types;
        private System.Windows.Forms.ListBox ListBox_Log;
    }
}
