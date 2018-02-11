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
	/// ID 컬럼을 갖는 Entity의 기본 기능을 제공 합니다.
	/// </summary>
	public abstract partial class EntityIdBase : EntityBase
	{
		/// <summary>
		/// EntityIdBase class의 새 인스턴스를 초기화 합니다.
		/// </summary>
		public EntityIdBase()
		{
			Updated = Now;
		}

		/// <summary>
		/// Id를 구하거나 설정합니다.
		/// </summary>
		/// <value>The identifier.</value>
		[Key]
		[Column(Order = 0)]
		public virtual int Id
		{
			get;
			set;
		}

		/// <summary>
		/// 수정 시간을 구하거나 설정합니다.
		/// </summary>
		[Editable(false)]
		[Display(Name = "수정 시간")]
		[DataType(DataType.DateTime)]
		public virtual DateTime Updated
		{
			get;
			set;
		}
	}
}
