using ZO.Kats.Dac.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac.Configurations
{
	/// <summary>
	/// FCS 전체 설정
	/// </summary>
	/// <seealso cref="ZO.Kats.Dac.Entities.Base.EntityIdBase" />
	public class Setting : EntityIdBase
	{
		/// <summary>
		/// 설정 키를 구하거나 설정합니다.
		/// </summary>
		/// <value>Settings를 반환합니다.</value>
		public SettingKeys Key { get; set; }

		/// <summary>
		/// 설정 값을 구하거나 설정합니다.
		/// </summary>
		/// <remarks>키에 따라서 적절한 값으로 casting 하여 사용 한다.</remarks>
		/// <value>Value를 반환합니다.</value>
		public string Value { get; set; }
	}
}
