using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.Common.Configuration;
using GS.Common.Utility.Log;
using GS.Win;
using GS.Win.Forms.UserControls;
using System.Drawing;
using GS.IPO.Common;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace GS.IPO.KIS.Forms
{
	public partial class FullScreenForm : BaseForm
	{
		public FullScreenForm()
		{
			this.SetDoubleBuffered();

			InitializeComponent();
			Log = GS.Common.Utility.Log.LogLevelManager.Instance;
			Log.MakeDateFolder = true;
			Log.InsertDateTime = true;
			InitialiseControls();
		}

		private void InitialiseControls()
		{
			SuspendLayout();
			xpnlContainerBody.SetDoubleBuffered();

			var workTimer = new System.Timers.Timer(1000);

			workTimer.Elapsed += (sender, e) =>
			{
				Invoke(new MethodInvoker(() =>
				{
					tsTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
				}));
			};
			workTimer.Start();
		}

		private LogLevelManager Log
		{
			get;
			set;
		}

		private string Database { get; set; }

		private Color ConnectedColor
		{
			get
			{
				return Color.FromArgb(75, 146, 241);
			}
		}

		private Color DisconnectedColor
		{
			get
			{
				return Color.FromArgb(0xF9, 0x42, 0x33);
			}
		}

		private void ChangeStatusColor(ToolStripStatusLabel target, Color color, string message = "")
		{
			Invoke(new MethodInvoker(() =>
			{
				target.ForeColor = Color.White;
				target.BackColor = color;

				if (message != string.Empty)
				{
					target.Text = message;
				}
			}));
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			SetText();
#if !DEBUG
			WindowState = FormWindowState.Maximized;
#endif
			ResumeLayout();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			ShowProgress();
			RegisterEventHandlers();
			InitValuesAfterRegisterEventHandlers();

			try
			{
				ChangeStatusColor(tsFcsStatus, DisconnectedColor, "FCS [FAIL]");
				ChangeStatusColor(tsPlcStatus, DisconnectedColor, "PLC [FAIL]");
				ChangeStatusColor(tsIpsStatus, DisconnectedColor, "IPS [FAIL]");
				ChangeStatusColor(tsSimsStatus, DisconnectedColor, "SIMS [FAIL]");
				tsLocalIpAddress.Text = GS.Common.Net.IpManager.LocalIp;
			}
			catch (Exception ex)
			{
				Log.Error($"{ex.GetFlattenInnerMessages()}\r\n{ex.StackTrace.ToString()}");
			}

			HideProgress();
		}

		protected override void InitTextBox(TextBox textBox)
		{
		}

		public string LocalIp
		{
			get
			{
				//IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
				//string localIpAddress = string.Empty;

				//foreach (IPAddress ipAddr in ipEntry.AddressList)
				//{
				//	byte ipHeader = ipAddr.GetAddressBytes()[0];

				//	if (ipHeader == 0 || ipHeader == 127 || ipHeader == 169
				//		|| ipAddr.AddressFamily != AddressFamily.InterNetwork)
				//	{
				//		continue;
				//	}

				//	localIpAddress = Convert.ToString(ipAddr);

				//	if (localIpAddress != string.Empty)
				//	{
				//		break;
				//	}
				//}

				//return localIpAddress;
				//foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces().Where(x => x.OperationalStatus == OperationalStatus.Up))
				//{
				//	if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
				//	{
				//		Console.WriteLine(ni.Name);
				//		foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
				//		{
				//			if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				//			{
				//				Console.WriteLine(ip.Address.ToString());
				//			}
				//		}
				//	}
				//}

				return "";
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			try
			{

			}
			catch
			{
			}

			base.OnFormClosing(e);
		}

		private async void InitDatabase()
		{
			await Task.Run(() =>
			{

			});
		}

		private void HideProgress()
		{
			tsProgress.Visible = false;
		}

		private void ShowProgress()
		{
			tsProgress.Visible = true;
		}

		private void RegisterEventHandlers()
		{

		}

		private void InitValuesAfterRegisterEventHandlers()
		{
			Database = SettingKeys.Database.GetValue();
		}

		private void WriteLog(string log)
		{
			Invoke(new MethodInvoker(() =>
			{
				tsStatus.Text = log;
			}));
		}

		private void WriteLog(string message, LogLevels level = LogLevels.Info)
		{
			switch (level)
			{
				case LogLevels.Debug:
					Log.Debug(message);

					break;
				case LogLevels.Info:
					Log.Info(message);

					break;
				case LogLevels.Warn:
					Log.Warn(message);

					break;
				case LogLevels.Error:
					Log.Error(message);

					break;
				case LogLevels.Fatal:
					Log.Fatal(message);

					break;
			}
		}
	}
}
