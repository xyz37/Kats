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
	/// 거래 종목
	/// </summary>
	/// <seealso cref="ZO.Kats.Dac.Entities.Base.EntityIdBase" />
	[System.Diagnostics.DebuggerDisplay("Code:{Code}, Name:{Name}, Priority:{Priority}, BuyAmount:{BuyAmount}, BuyPrice:{BuyPrice}, TargetPrice:{TargetPrice}, CutLossPrice:{CutLossPrice}, IsBuy:{IsBuy}, IsSell:{IsSell}, TxUserId:{TxUserId}, TxDate:{TxDate}, LastModifiedUserId:{LastModifiedUserId}, LastModified:{LastModified}", Name = "StockItem")]
	public class StockItem : EntityBase
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
		/// 종목 Code를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The code.
		/// </value>
		[Key]
		[Column(Order = 2, TypeName = "char"), MaxLength(6)]
		public string Code { get; set; }

		/// <summary>
		/// 종목명을 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Column(TypeName = "varchar"), MaxLength(150)]
		public string Name { get; set; }

		/// <summary>
		/// Priority를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The priority.
		/// </value>
		public int Priority { get; set; }

		/// <summary>
		/// 매수 금액을 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The buy amount.
		/// </value>
		public int BuyAmount { get; set; }

		/// <summary>
		/// 매수가를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The buy price.
		/// </value>
		public int BuyPrice { get; set; }

		/// <summary>
		/// 목표가를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The target price.
		/// </value>
		public int TargetPrice { get; set; }

		/// <summary>
		/// 손절가를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		/// The cut loss price.
		/// </value>
		public int CutLossPrice { get; set; }

		/// <summary>
		/// 매수 여부를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is buy; otherwise, <c>false</c>.
		/// </value>
		public bool IsBuy { get; set; }

		/// <summary>
		/// 매도 여부를 구하거나 설정합니다.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is sell; otherwise, <c>false</c>.
		/// </value>
		public bool IsSell { get; set; }

	}
}
