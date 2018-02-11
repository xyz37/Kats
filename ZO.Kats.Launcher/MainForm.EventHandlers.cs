using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.Common.Utility.Log;
using GS.Win.Forms.UserControls;
using ZO.Kats.Common;
using ZO.Kats.Dac.Entities;

namespace ZO.Kats.Launcher
{
	partial class MainForm
	{
		private void RegisterEventHandlers()
		{
			tcMain.Selecting += (sender, e) =>
			{
				if (sender is TabControl tabControl)
				{
					var currentTab = tabControl.SelectedTab;

					if (currentTab.Tag != null)
					{
						var cancel = false;

						switch ((TabControlNames)currentTab.Tag)
						{
							case TabControlNames.Settings:
								SaveSettings();

								cancel = true;

								break;
						}

						e.Cancel = cancel;
					}
				}
			};
			tcMain.SelectedIndexChanged += (sender, e) =>
			{
				if (sender is TabControl tcMain)
				{
					var selectedTab = tcMain.SelectedTab;

					if (selectedTab != null)
					{
						this.InvokeText($"{OriginalText} [{selectedTab.Text.Trim()}]");

						if (selectedTab.Tag != null)
						{
							var tabName = (TabControlNames)selectedTab.Tag;
							var isFullScreen = Convert.ToBoolean(tabName.GetDefaultValue());

							SetTabFullscreen(isFullScreen);

							switch (tabName)
							{
								case TabControlNames.Monitoring:

									break;
								case TabControlNames.Statistics:

									break;
								case TabControlNames.Settings:

									//SelectTab(PreviousSelectedTab);
									break;
							}
						}
					}
				}
			};
		}

		private void SelectTab(TabControlNames tabControlName)
		{
			foreach (TabPage tp in tcMain.TabPages)
			{
				if (tp.Tag != null && tp.Tag.ToString() == tabControlName.ToString())
				{
					Invoke(new MethodInvoker(() =>
					{
						tcMain.SelectedTab = tp;
					}));

					break;
				}
			}
		}

		private void SetTabFullscreen(bool isFullScreen)
		{
			tlpMain.SuspendLayout();

			if (isFullScreen == true)
			{
				tlpMain.RowStyles[0].Height = 0f;
				tlpMain.RowStyles[1].Height = 0f;
			}
			else
			{
				tlpMain.RowStyles[0].Height = 118f;
				tlpMain.RowStyles[1].Height = 118f;
			}

			tlpMain.ResumeLayout();
		}
		
		private void SaveSettings()
		{
			//var form = new SettingForm(WriteLog, Database;

			//if (form.ShowDialog() == DialogResult.OK)
			//{
			//	SendSettingChanged();
			//}
		}
	}
}
