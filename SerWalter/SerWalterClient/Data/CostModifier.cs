﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace SerWalterClient.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class CostModifier : DBObject
	{
		public virtual decimal modifierFixed
		{
			get;
			set;
		}

		public virtual double modifierPercent
		{
			get;
			set;
		}
	}
}

