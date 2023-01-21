using ScanFun.BL.Interfaces;
using ScanFun.BL.Models;
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
        private ITicketService _ticketService;
        private string _scannedData;
        private ScanDiolog _formPopup;
        private TicketRequest _ticketRequest;

        public Form1()
        {
            _ticketService = new TicketService();
            _scanHandler = GetScanHandler();

            InitializeComponent();
            ListBox_Initialize();
        }

        private void FormPopupClose(object sender, System.EventArgs e)
        {
            this.Enabled = true;
            _scannedData = string.Empty;
            _scanHandler.StopScanHandle();
            ListBox_Log.Items.Add("Сканирование отменено");
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            ListBox_Log.Items.Add("Ожидание сканирования");

            _scanHandler.StartScanHandle();

            this.Enabled = false;
            _formPopup = new ScanDiolog("Отсканируйте штрих-код", "Отмена");
            _formPopup.Button_Cancel.Click += FormPopupClose;
            _formPopup.Show();

            if (!string.IsNullOrEmpty(_scannedData))
            {
                _ticketRequest = new TicketRequest()
                {
                    Type = (sender as Button).Name,
                    Ticket = _scannedData,
                    Pc = SystemInformation.ComputerName,
                    Pass = "later",
                    Hash = "late too"
                };                
            }            
        }

        private void ListBox_Initialize()
        {
            ListBox_Log.Items.Add("Получение допускаемых типов");
            var types = _ticketService.GetTicketTypes();
            var buttons = new Control[types.Count];
            var i = 0;

            foreach (var type in types)
            {
                var btn = new Button();
                btn.Name = type.Id;
                btn.Size = new Size(ListView_Types.ClientSize.Width, 30);
                btn.Cursor = Cursors.Default;
                btn.Text = type.Caption;
                btn.Font = new Font("Arial", 14);
                btn.Click += Buttons_Click;
                btn.Location = new Point(0, btn.Height * i);
                ListView_Types.Controls.Add(btn);
                i++;
            }
        }

        private void HandleScan(string outputData)
        {
            _scannedData = outputData;

            ListBox_Log.Invoke(new Action(() => ListBox_Log.Items.Add("Отправка результата на сервер")));
            var response = _ticketService.SendTicket(_ticketRequest);

            if (response.Type == "OK")
            {
                _scanHandler.StopScanHandle();
                this.Invoke(new Action(() => this.Enabled = true));
                ListBox_Log.Invoke(new Action(() => ListBox_Log.Items.Add("Обработка ответа")));
                _scannedData = String.Empty;
                _formPopup.Invoke(new Action(() => _formPopup.Close()));
            }
            MessageBox.Show(response.Mess, "Сканер");
        }

        private ScanHandler GetScanHandler()
        {
            try
            {
                _scanHandler = new ScanHandler(HandleScan);
                ListBox_Log.Items.Add("Сканер запущен");
            }
            catch (Exception)
            {
                ListBox_Log.Items.Add("Проверьте сканер");
            }
            return _scanHandler;
        }
    }
}
