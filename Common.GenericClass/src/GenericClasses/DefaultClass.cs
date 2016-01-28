﻿using DryIocAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKWeb.Plugins.Common.GenericClass.src.GenericClasses {
	/// <summary>
	/// 默认分类
	/// </summary>
	[ExportMany]
	public class DefaultClass : GenericClassBuilder {
		public override string Name { get { return "DefaultClass"; } }
	}
}
