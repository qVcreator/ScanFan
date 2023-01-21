using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScanFan.App
{
    public partial class ScanDiolog : Form
    {
        public ScanDiolog(string text, string button_text)
        {
            InitializeComponent();
            Label_ScanMessage.Text = text;
            Button_Cancel.Text = button_text;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
