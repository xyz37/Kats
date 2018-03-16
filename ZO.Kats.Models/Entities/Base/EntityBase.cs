using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac.Entities.Base
{
	/// <summary>
	/// Entity의 기본 기능을 제공합니다.
	/// </summary>
	[Serializable]
	public abstract partial class EntityBase
	{
		/// <summary>
		/// 처리한 사용자 Id를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The tx user identifier.
		/// </value>
		[Column(TypeName = "varchar"), MaxLength(8)]
		public string TxUserId { get; set; }

		/// <summary>
		/// 처리한 일시를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The tx date.
		/// </value>
		public DateTime TxDate { get; set; }

		/// <summary>
		/// 마지막 수정한 사용자 Id를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The last modified user identifier.
		/// </value>
		[Column(TypeName = "varchar"), MaxLength(8)]
		public string LastModifiedUserId { get; set; }

		/// <summary>
		/// 마지막 수정 일시를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The last modified date.
		/// </value>
		public DateTime LastModified { get; set; }

		/// <summary>
		/// Gets the current datetime.
		/// </summary>
		[NotMapped]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		protected DateTime Now
		{
			get
			{
				return DateTime.Now;
			}
		}

		/// <summary>
		/// Gets the today datetime.
		/// </summary>
		[NotMapped]
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		protected DateTime Today
		{
			get
			{
				return DateTime.Today;
			}
		}

		/// <summary>
		/// 새로운 <seealso cref="KatsContext" />를 생성하여 반환합니다.
		/// </summary>
		/// <param name="autoDetectChangesEnabled"><seealso cref="System.Data.Entity.Infrastructure.DbChangeTracker.DetectChanges" /> 메서드가 <see cref="System.Data.Entity.DbContext" />
		/// 및 관련 클래스의 메서드에 의해 자동으로 호출되는지 여부를 나타내는 값을 가져오거나 설정합니다.
		/// <remarks>데이터 추적이 필요하지 않은 Read 작업 등에서는 false로 하면 성능이 향상 됩니다.</remarks></param>
		/// <param name="proxyCreationEnabled">Proxy creation enabled.(virtual 선언한 멤버가 나오게 하려면 Proxy와 Lazy load을 true로 해야 한다.</param>
		/// <param name="lazyLoadingEnabled">The lazy loading enabled.</param>
		/// <param name="validateOnSaveEnabled">Validate on save enabled</param>
		/// <param name="server">The server.</param>
		/// <returns>
		/// KatsContext.
		/// </returns>
		protected static KatsContext CreateContext(
			bool autoDetectChangesEnabled = true,
			bool proxyCreationEnabled = false,
			bool lazyLoadingEnabled = false,
			bool validateOnSaveEnabled = false,
			string server = "localhost")
		{
			return KatsContext.Create(autoDetectChangesEnabled, proxyCreationEnabled, lazyLoadingEnabled, validateOnSaveEnabled, server: server);
		}

		/// <summary>
		/// 새로운 읽기 전용 <seealso cref="KatsContext" />를 생성하여 반환합니다.
		/// </summary>
		/// <param name="server">The server.</param>
		protected static KatsContext Readable(string server)
		{
			return CreateContext(false, server: server);
		}

		/// <summary>
		/// 새로운 쓰기 전용 <seealso cref="KatsContext" />를 생성하여 반환합니다.
		/// </summary>
		/// <param name="server">The server.</param>
		protected static KatsContext Writable(string server)
		{
			return CreateContext(true, false, false, true, server: server);
		}
	}
}
