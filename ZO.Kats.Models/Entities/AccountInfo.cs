using Castle.MicroKernel.SubSystems.Conversion;
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
	/// 계좌 정보
	/// </summary>
	/// <seealso cref="ZO.Kats.Dac.Entities.Base.EntityBase" />
	[System.Diagnostics.DebuggerDisplay("UserId:{UserId}, AccountNo:{AccountNo}, ReferenceDate:{ReferenceDate}, StockItemCode:{StockItemCode}, StockItemName:{StockItemName}, BuyPrice:{BuyPrice}, OwnStockCount:{OwnStockCount}, OwnAmount:{OwnAmount}, TxUserId:{TxUserId}, TxDate:{TxDate}, LastModifiedUserId:{LastModifiedUserId}, LastModified:{LastModified}", Name = "AccountInfo")]
	public class AccountInfo : EntityBase
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
		/// 종목 코드를 구하거나 설정합니다.
		/// </summary>
		/// <value>StockItemCode를 반환합니다.</value>
		[Key]
		[Column(Order = 4, TypeName = "char"), MaxLength(6)]
		public string StockItemCode { get; set; }

		/// <summary>
		/// 종목명을 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Column(TypeName = "varchar"), MaxLength(150)]
		public string StockItemName { get; set; }

		/// <summary>
		/// 매수가를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The buy price.
		/// </value>
		public int BuyPrice { get; set; }

		/// <summary>
		/// 보유 주식 수를 구하거나 설정합니다.
		/// </summary>
		/// <value>OwnStockCount를 반환합니다.</value>
		public int OwnStockCount { get; set; }

		/// <summary>
		/// 보유 금액를 구하거나 설정합니다.
		/// </summary>
		/// <value>OwnAmount를 반환합니다.</value>
		public int OwnAmount { get; set; }

	}
}
