using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarrenLee.Bluetooth;


namespace BLE_try
{
	public partial class Form1 : Form
	{
		Bluetooth_Server bleServer = new Bluetooth_Server();
		public Form1()
		{
			InitializeComponent();
			textStatus.Text = "-----";
		}
		private void BtnStart_Click(object sender, EventArgs e)
		{
			textStatus.Text = "Waiting......";
			bleServer.Start();
			bleServer.IsConnected += bleServer_IsConnected;
			bleServer.DataReceived += bleServer_DataReceived;
		}

		private void bleServer_IsConnected(object sender,EventArgs e)
		{
			MessageBox.Show("Bluetooth Connection Established!");
			if(InvokeRequired)
			{
				this.Invoke(new Action(() =>
				{
					textStatus.Text = "Connected";
				}));
			}
		}

		private void bleServer_DataReceived(object sender,BluetoothServerEventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke(new Action(() =>
				{
					textReceive.AppendText(e.Message);
				}));
			}
		}
	}
}
