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
            startScanHandle("Сканер не подключен", "сканер подключен");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            startScanHandle("Ошибка подключения сканера", "сканер подключен");
        }

        public void GetScanedData(string outputData)
        {
            textBox1.Invoke(new Action(() => textBox1.Text = outputData));

        }

        private void startScanHandle(string exceptionMessage, string succesMessage)
        {
            try
            {
                _scanHandler = new ScanHandler(GetScanedData);
                textBox1.Text = succesMessage;
            }
            catch (Exception)
            {
                textBox1.Text = exceptionMessage;
            }
        }
    }
}
