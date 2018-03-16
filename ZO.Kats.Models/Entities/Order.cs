using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZO.Kats.Dac.Entities.Base;
using ZO.Kats.Models.Enums;

namespace ZO.Kats.Models.Entities
{
	/// <summary>
	/// 주문
	/// </summary>
	/// <seealso cref="ZO.Kats.Dac.Entities.Base.EntityIdBase" />
	[System.Diagnostics.DebuggerDisplay("UserId:{UserId}, AccountNo:{AccountNo}, ReferenceDate:{ReferenceDate}, StockItemCode:{StockItemCode}, StockItemName:{StockItemName}, OrderType:{OrderType}, No:{No}, Price:{Price}, StockCount:{StockCount}, Amount:{Amount}, RequestDate:{RequestDate}, TxUserId:{TxUserId}, TxDate:{TxDate}, LastModifiedUserId:{LastModifiedUserId}, LastModified:{LastModified}", Name = "Order")]
	public class Order : EntityIdBase
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
		/// 주문 구분를 구하거나 설정합니다.
		/// </summary>
		[Key]
		[Column(Order = 5)]
		public OrderTypes OrderType { get; set; }

		/// <summary>
		/// 원 주문번호를 구하거나 설정합니다.
		/// </summary>
		/// <value>No를 반환합니다.</value>
		[Key]
		[Column(Order = 6, TypeName = "char"), MaxLength(7)]
		public string No { get; set; }

		/// <summary>
		/// 주문가를 구하거나 설정합니다.
		/// </summary>
		/// <value>Price를 반환합니다.</value>
		public int Price { get; set; }

		/// <summary>
		/// 주문 주식수를 구하거나 설정합니다.
		/// </summary>
		/// <value>OrderStockCount를 반환합니다.</value>
		public int StockCount { get; set; }

		/// <summary>
		/// 주문 금액를 구하거나 설정합니다.
		/// </summary>
		/// <value>OrderAmount를 반환합니다.</value>
		public int Amount { get; set; }

		/// <summary>
		/// 주문 요청일시를 구하거나 설정합니다.
		/// </summary>
		/// <value>RequestDate를 반환합니다.</value>
		public DateTime RequestDate { get; set; }

	}
}
