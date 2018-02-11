using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZO.Kats.Common.Commands
{
	/// <summary>
	/// https://codereview.stackexchange.com/questions/134893/handling-keyboard-shortcuts-in-c-software
	/// </summary>
	/// <seealso cref="ZO.Kats.Common.Commands.ICommand" />
	public abstract class CommandBase : ICommand
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandBase"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		public CommandBase(Keys key)
		{
			Key = key;
		}

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		public Keys Key { get; set; }

		/// <summary>
		/// Executes this command.
		/// </summary>
		public abstract void Execute();
	}
}
