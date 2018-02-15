using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZO.Kats.Interfaces
{
	/// <summary>
	/// Command for shortcut keys
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		Keys Key { get; set; }

		/// <summary>
		/// Executes this command.
		/// </summary>
		void Execute();
	}
}
