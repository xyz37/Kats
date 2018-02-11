using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZO.Kats.Launcher
{
	public enum SettingKeys
	{
		/// <summary>
		/// The database host
		/// </summary>
		Database,
		/// <summary>
		/// The FCS ip address
		/// </summary>
		FCSIpAddress,
		/// <summary>
		/// The FCS port
		/// </summary>
		FCSPort,
		/// <summary>
		/// The sort plan path
		/// </summary>
		SortPlanPath,
		/// <summary>
		/// The ftp ip
		/// </summary>
		FtpIp,
		/// <summary>
		/// The ftp port
		/// </summary>
		FtpPort,
		/// <summary>
		/// The update notify ip
		/// </summary>
		UpdateNotifyIp,
		/// <summary>
		/// The update notify port
		/// </summary>
		UpdateNotifyPort,
		/// <summary>
		/// The update notify FTP timeout
		/// </summary>
		UpdateNotifyFtpTimeout,
		/// <summary>
		/// 집중국 이름
		/// </summary>
		PostalCenter,
		/// <summary>
		/// 구분기 번호
		/// </summary>
		SorterId,
	}
}
