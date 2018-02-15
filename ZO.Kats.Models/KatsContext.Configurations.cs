using ZO.Kats.Dac.Configurations;
using ZO.Kats.Dac.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac
{
	partial class KatsContext
	{
		/// <summary>
		/// 설정 테이블을 구하거나 설정합니다.
		/// </summary>
		/// <value>Setting를 반환합니다.</value>
		public DbSet<Setting> Settings { get; set; }

	}
}
