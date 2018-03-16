using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZO.Kats.Dac.Entities.Base;

namespace ZO.Kats.Models.Entities
{
	/// <summary>
	/// 계좌
	/// </summary>
	/// <seealso cref="ZO.Kats.Dac.Entities.Base.EntityBase" />
	[System.Diagnostics.DebuggerDisplay("UserId:{UserId}, AccountNo:{AccountNo}, ReferenceDate:{ReferenceDate}, BuyableAmount:{BuyableAmount}, TxUserId:{TxUserId}, TxDate:{TxDate}, LastModifiedUserId:{LastModifiedUserId}, LastModified:{LastModified}", Name = "Account")]
	public class Account : EntityBase
	{
		/// <summary>
		/// UserId를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		[Key]
		[Column(Order = 1, TypeName = "varchar"), MaxLength(8)]
		public string UserId { get; set; }

		/// <summary>
		/// AccountNo를 구하거나 설정합니다.
		/// </summary>
		/// <value>AccountNo를 반환합니다.</value>
		[Key]
		[Column(Order = 2, TypeName = "char"), MaxLength(10)]
		public string AccountNo { get; set; }

		/// <summary>
		/// 해당 계좌의 기준일자를 구하거나 설정합니다.
		/// </summary>
		/// <value>ReferenceDate를 반환합니다.</value>
		[Key]
		[Column(Order = 3, TypeName = "char"), MaxLength(8)]
		public string ReferenceDate { get; set; }

		/// <summary>
		/// 매수 가능 금액을 구하거나 설정합니다.
		/// </summary>
		/// <value>BuyableAmount를 반환합니다.</value>
		public int BuyableAmount { get; set; }

	}
}
