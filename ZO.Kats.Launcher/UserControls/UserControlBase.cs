using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZO.Kats.Common.Interfaces;

namespace GS.IPO.Common.KIS.UserControls
{
	public class UserControlBase : Win.Forms.UserControls.UcBase
	{
		#region Constructor
		/// <summary>
		/// UserControlBase class의 새 인스턴스를 초기화 합니다.
		/// </summary>
		public UserControlBase()
		{
			Database = ConfigurationManager.AppSettings["Database"];
		}
		#endregion

		/// <summary>
		/// 연결할 Database host를 구합니다.
		/// </summary>
		protected string Database { get; }

		/// <summary>
		/// Gets the ITTS.
		/// </summary>
		/// <value>
		protected ITTS TTS
		{
			get
			{
				return FindForm() as ITTS;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			ToolbarVisible = true;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			ToolbarVisible = false;
		}
	}
}
