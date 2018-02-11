using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac
{
	/// <summary>
	/// IPO Context extensions
	/// </summary>
	public static class KatsContextExtentions
	{
		/// <summary>
		/// 현재 연결에서 database Transaction을 시작합니다.
		/// </summary>
		/// <param name="dbContext">The database context.</param>
		/// <returns>DbContextTransaction.</returns>
		public static DbContextTransaction BeginTransaction(this KatsContext dbContext)
		{
			return dbContext.Database.BeginTransaction();
		}

		/// <summary>
		/// 현재 연결에서 database Transaction을 시작합니다.
		/// </summary>
		/// <param name="dbContext">The database context.</param>
		/// <param name="isolationLevel">The database isolation level with which the underlying store transaction will be created.</param>
		/// <returns>DbContextTransaction.</returns>
		public static DbContextTransaction BeginTransaction(this KatsContext dbContext, IsolationLevel isolationLevel)
		{
			return dbContext.Database.BeginTransaction(isolationLevel);
		}

	}
}
