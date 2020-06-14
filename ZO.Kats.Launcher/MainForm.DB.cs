using ZO.Kats.Common;
using ZO.Kats.Dac;
using ZO.Kats.Dac.Entities;
using GS.Win.Forms.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZO.Kats.Launcher
{
	partial class MainForm
	{
		private string Database { get; set; }

		private async void InitDatabase()
		{
			await Task.Run(() =>
			{
				ShowProgress();
				InitSettings();
				HideProgress();
			});
		}

		private void InitSettings()
		{
			List<Dac.Configurations.Setting> setting = null;

			using (var db = KatsContext.Create(true, true, true, server: Database))
			{
				setting = db.Settings.ToList();
			}

			if (setting == null || setting.Count == 0)
			{
				return;
			}
		}

		private string GetSettingValue(List<Dac.Configurations.Setting> setting, Dac.Configurations.SettingKeys key)
		{
			return setting.FirstOrDefault(x => x.Key == key)?.Value;
		}
	}
}
