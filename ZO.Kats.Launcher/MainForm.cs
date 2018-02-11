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
using ZO.Kats.Common;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace ZO.Kats.Launcher
{
	public partial class MainForm : BaseForm
	{
		public MainForm()
		{
			this.SetDoubleBuffered();

			InitializeComponent();

			SuspendLayout();
			Log = GS.Common.Utility.Log.LogLevelManager.Instance;
			Log.MakeDateFolder = true;
			Log.InsertDateTime = true;
			InitialiseControls();
		}

		private void InitialiseControls()
		{
			xpnlContainerBody.SetDoubleBuffered();
			tlpMain.SetDoubleBuffered();

			var workTimer = new System.Timers.Timer(1000);

			workTimer.Elapsed += (sender, e) =>
			{
			};
			workTimer.Start();
		}

		private LogLevelManager Log
		{
			get;
			set;
		}

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
		}

		protected override void OnShown(EventArgs e)
		{
			base.CenterToScreen();
			ResumeLayout();

			base.OnShown(e);
			ShowProgress();
			RegisterEventHandlers();
			InitValuesAfterRegisterEventHandlers();
			InitDatabase();

			try
			{
				ChangeStatusColor(tsSimsStatus, DisconnectedColor, "SIMS [FAIL]");
				tsLocalIpAddress.Text = GS.Common.Net.IpManager.LocalIp;
			}
			catch (Exception ex)
			{
				Log.Error($"{ex.GetFlattenInnerMessages()}\r\n{ex.StackTrace.ToString()}");
			}

			HideProgress();

#if DEV
			//SelectTab(TabControlNames.PMS);
#endif
		}

		protected override void InitTextBox(TextBox textBox)
		{
		}

		private string _workDate;
		private string WorkDate
		{
			get
			{
				if (string.IsNullOrEmpty(_workDate) == true)
				{
					_workDate = DateTime.Today.GetInterfaceDate();
				}

				return _workDate;
			}
			set
			{
				if (_workDate != value)
				{
					_workDate = value;
				}
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			//if (MessageBox.Show(
			//		"프로그램을 종료하면 구분 계획이 변경되지 않습니다.\r\n종료하시겠습니까?",
			//		Text,
			//		MessageBoxButtons.YesNo,
			//		MessageBoxIcon.Question,
			//		MessageBoxDefaultButton.Button2) == DialogResult.No)
			//{
			//	e.Cancel = true;

			//	return;
			//}

			try
			{
			}
			catch
			{
			}

			base.OnFormClosing(e);
		}

		private void HideProgress()
		{
			Invoke(new MethodInvoker(() =>
			{
				tsProgress.Visible = false;
			}));
		}

		private void ShowProgress()
		{
			Invoke(new MethodInvoker(() =>
			{
				tsProgress.Visible = true;
			}));
		}

		private void InitValuesAfterRegisterEventHandlers()
		{
			Database = SettingKeys.Database.GetValue();

			_speechSynthesizer = new Microsoft.Speech.Synthesis.SpeechSynthesizer();

			try
			{
				_speechSynthesizer.SetOutputToDefaultAudioDevice();
				TTSEnabled = true;
			}
			catch
			{
				if (MessageBox.Show(
					"오디오 장치가 연결되어 있지 않습니다.\r\n스피커를 연결 하셨습니까?",
					Text,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{
						_speechSynthesizer.SetOutputToDefaultAudioDevice();
						TTSEnabled = true;
					}
					catch
					{
					}
				}
			}

			_prormptBuilder = new Microsoft.Speech.Synthesis.PromptBuilder();

			SetTabPageTag(tpMonitoring, TabControlNames.Monitoring);
			SetTabPageTag(tpStatistics, TabControlNames.Statistics);
			SetTabPageTag(tpSettings, TabControlNames.Settings);

			tcMain.Controls.Remove(tpSettings);

			// 자동으로 안되서 수동일 일단 할당
			// by GS_DEV\xyz37(김기원) in 2017년 12월 22일 금요일 12:33
			//var tabPages = tcMain.Controls.Cast<TabPage>().ToList();
			//var tabs = Enum.GetNames(typeof(TabControlNames));

			//foreach (string tab in tabs)
			//{
			//	if (Enum.IsDefined(typeof(TabControlNames), tab) == true)
			//	{
			//		SetTabPageTag(tabPages, (TabControlNames)Enum.Parse(typeof(TabControlNames), tab));
			//	}
			//}

			//if (tcMain.TabPages.Count > 0)
			//{
			//	lbTitle.InvokeText(tcMain.TabPages[0].Text);
			//}
		}

		private void SetTabPageTag(TabPage tabPage, TabControlNames tabControlNames)
		{
			tabPage.Tag = tabControlNames;
			// Argument 오류 발생
			//tabPage.Text = tabControlNames.GetDescription();
		}

		private void SetTabPageTag(List<TabPage> tabPages, TabControlNames tab)
		{
			int index = (int)tab;

			tcMain.TabPages[index].Tag = tab;
			tcMain.TabPages[index].Text = tab.GetDescription();
		}

		private void WriteLog(string message, LogLevels level = LogLevels.Info)
		{
			Invoke(new MethodInvoker(() =>
			{
				tsStatus.Text = message;
			}));

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
