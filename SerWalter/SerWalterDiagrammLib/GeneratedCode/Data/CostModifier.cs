﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class CostModifier : DBObject
	{
		public virtual Decimal increaseFixed
		{
			get;
			set;
		}

		public virtual Double increasePercent
		{
			get;
			set;
		}

		public virtual Decimal decreaseFixed
		{
			get;
			set;
		}

		public virtual Double decreasePercent
		{
			get;
			set;
		}

	}
}

