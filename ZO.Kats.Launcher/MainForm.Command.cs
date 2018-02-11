using ZO.Kats.Common.Commands;
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
		private static IEnumerable<ICommand> Commands { get; set; }

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			const int WM_KEYDOWN = 0x100;
			const int WM_SYSKEYDOWN = 0x104;

			if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
			{
				var command = Commands?.SingleOrDefault(c => c.Key == keyData);

				command?.Execute();

				switch (keyData)
				{
					case Keys.Q | Keys.Control:
						Close();

						return false;
					case Keys.D1 | Keys.Control:

						return false;
					case Keys.D2 | Keys.Control:

						return false;
				}
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
