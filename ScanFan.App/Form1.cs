using ScanFun.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanFan.App
{
    public partial class Form1 : Form
    {
        private ScanHandler _scanHandler;
        public Form1()
        {
            InitializeComponent();
            try
            {
                _scanHandler = new ScanHandler(GetScanedData);
            }
            catch(Exception)
            {
                textBox1.Text = "Сканер не подключен";
            }
        }

        public void GetScanedData(string outputData)
        {
            textBox1.Invoke(new Action(() => textBox1.Text = outputData));

        }
    }
}
