using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Launcher
{
	/// <summary>
	/// DefaultValue는 full screen 상태
	/// </summary>
	enum TabControlNames
	{
		[Description(" 구분기 상태 ")]
		[DefaultValue(false)]
		Monitoring = 0,
		[Description(" 통    계 ")]
		[DefaultValue(true)]
		Statistics,
		[Description(" 설    정 ")]
		[DefaultValue(true)]
		Settings,
	}
}
