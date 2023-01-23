using ScanFun.BL;
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
using System.Security.Cryptography;

namespace ScanFan.App
{
    public partial class Form1 : Form
    {
        private ScanHandler _scanHandler;
        private ITicketService _ticketService;
        private string _scannedData;
        private ScanDiolog _formPopup;
        private TicketRequest _ticketRequest;
        private string _pass;

        public Form1()
        {
            InitializeComponent();

            _ticketService = new TicketService();
            _scanHandler = GetScanHandler();
            _pass = (string)Properties.Settings.Default[Constants.Pass];

            ListBox_Initialize();
        }

        private void FormPopupClose(object sender, System.EventArgs e)
        {
            this.Enabled = true;
            _scannedData = string.Empty;
            _scanHandler.StopScanHandle();
            ListBox_Log.Items.Add(Constants.ScanCancelld);
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            try
            {
                ListBox_Log.Items.Add(Constants.WaitingScan);
                _scanHandler.StartScanHandle();

                this.Enabled = false;
                _formPopup = new ScanDiolog(Constants.ScanDialogMessage, Constants.ScanDialogButton);
                _formPopup.Button_Cancel.Click += FormPopupClose;
                _formPopup.Show();

                _ticketRequest = new TicketRequest()
                {
                    Type = (sender as Button).Name,
                    Pc = SystemInformation.ComputerName,
                    Pass = _pass
                };
            }
            catch (Exception)
            {
                ListBox_Log.Items.Add(Constants.CheckScaner);
                ListView_Types.Enabled = false;
            }          
        }

        private void ListBox_Initialize()
        {
            ListBox_Log.Items.Add(Constants.GetTypes);
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
                btn.Font = new Font(Constants.BaseFont, 14);
                btn.Click += Buttons_Click;
                btn.Location = new Point(0, btn.Height * i);
                ListView_Types.Controls.Add(btn);
                i++;
            }
        }

        private void HandleScan(string outputData)
        {
            _scannedData = outputData;

            var sault = (string)Properties.Settings.Default[Constants.Sault];
            var secondSault = (string)Properties.Settings.Default[Constants.SecondSault];
            var toHash = $"{_pass}{sault}{_scannedData}{secondSault}{_ticketRequest.Pc}";

            _ticketRequest.Ticket = _scannedData;
            _ticketRequest.Hash = Convert
                .ToBase64String(MD5
                .Create()
                .ComputeHash(Encoding.UTF8
                .GetBytes(toHash)
                ));

            ListBox_Log.Invoke(new Action(() => ListBox_Log.Items.Add(Constants.SendRequest)));
            ListBox_Log.Invoke(new Action(() => ListBox_Log.Items.Add(_ticketRequest.Ticket)));

            var response = _ticketService.SendTicket(_ticketRequest);

            if (response.Type == Constants.ResponseType)
            {
                _scanHandler.StopScanHandle();
                this.Invoke(new Action(() => this.Enabled = true));
                ListBox_Log.Invoke(new Action(() => ListBox_Log.Items.Add(Constants.Processing)));
                _scannedData = String.Empty;
                _formPopup.Invoke(new Action(() => _formPopup.Close()));
            }
            MessageBox.Show(response.Mess, Constants.ScanDialogName);
        }

        private ScanHandler GetScanHandler()
        {
            try
            {
                _scanHandler = new ScanHandler(HandleScan);
                ListBox_Log.Items.Add(Constants.ScanerWorks);
                ListView_Types.Enabled = true;
            }
            catch (Exception)
            {
                ListBox_Log.Items.Add(Constants.CheckScaner);
                ListView_Types.Enabled = false;
            }
            return _scanHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scanHandler = GetScanHandler();
        }
    }
}
