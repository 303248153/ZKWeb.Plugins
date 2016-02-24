﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ZKWeb.Plugins.Common.Base.src.Model {
	/// <summary>
	/// 只读文本
	/// </summary>
	public class LabelFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		public LabelFieldAttribute(string name) {
			Name = name;
		}
	}

	/// <summary>
	/// 文本框
	/// </summary>
	public class TextBoxFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 预置文本
		/// </summary>
		public string PlaceHolder { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="placeHolder">预置文本</param>
		public TextBoxFieldAttribute(string name, string placeHolder = null) {
			Name = name;
			PlaceHolder = placeHolder;
		}
	}

	/// <summary>
	/// 密码框
	/// </summary>
	public class PasswordFieldAttribute : TextBoxFieldAttribute {
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="placeHolder">预置文本</param>
		public PasswordFieldAttribute(string name, string placeHolder = null)
			: base(name, placeHolder) { }
	}

	/// <summary>
	/// 多行文本框
	/// </summary>
	public class TextAreaFieldAttribute : TextBoxFieldAttribute {
		/// <summary>
		/// 行数
		/// </summary>
		public int Rows { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="rows">行数</param>
		/// <param name="placeHolder">预置文本</param>
		public TextAreaFieldAttribute(string name, int rows, string placeHolder = null)
			: base(name, placeHolder) {
			Rows = rows;
		}
	}

	/// <summary>
	/// 勾选框
	/// </summary>
	public class CheckBoxFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		public CheckBoxFieldAttribute(string name) {
			Name = name;
		}
	}

	/// <summary>
	/// 勾选框分组
	/// </summary>
	public class CheckBoxGroupFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 选项来源，必须继承IListItemProvider
		/// </summary>
		public Type Source { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="sources">选项来源，必须继承IListItemProvider</param>
		public CheckBoxGroupFieldAttribute(string name, Type source) {
			Name = name;
			Source = source;
		}
	}

	/// <summary>
	/// 勾选框分组列表
	/// </summary>
	public class CheckBoxGroupsFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 选项来源，必须继承IListItemGroupsProvider
		/// </summary>
		public Type Source { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="sources">选项来源，必须继承IListItemGroupsProvider</param>
		public CheckBoxGroupsFieldAttribute(string name, Type source) {
			Name = name;
			Source = source;
		}
	}

	/// <summary>
	/// 勾选框树
	/// </summary>
	public class CheckBoxTreeFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 选项来源，必须继承IListItemTreeProvider
		/// </summary>
		public Type Source { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="source">选项来源，必须继承IListItemProvider</param>
		public CheckBoxTreeFieldAttribute(string name, Type source) {
			Name = name;
			Source = source;
		}
	}

	/// <summary>
	/// 下拉列表
	/// </summary>
	public class DropdownListFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 选项来源，必须继承IListItemProvider
		/// </summary>
		public Type Source { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="source">选项来源，必须继承IListItemProvider</param>
		public DropdownListFieldAttribute(string name, Type source) {
			Name = name;
			Source = source;
		}
	}

	/// <summary>
	/// 单选按钮列表
	/// </summary>
	public class RadioButtonsFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 选项来源，必须继承IListItemProvider
		/// </summary>
		public Type Source { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="sources">选项来源，必须继承IListItemProvider</param>
		public RadioButtonsFieldAttribute(string name, Type sources) {
			Name = name;
			Source = sources;
		}
	}

	/// <summary>
	/// 图片验证码
	/// </summary>
	public class CaptchaFieldAttribute : TextBoxFieldAttribute {
		/// <summary>
		/// 用于区分各个验证码的键值
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="key">用于区分各个验证码的键值</param>
		/// <param name="placeHolder">预置文本</param>
		public CaptchaFieldAttribute(string name, string key, string placeHolder = null)
			: base(name, placeHolder) {
			Key = key;
		}
	}

	/// <summary>
	/// 文件上传
	/// </summary>
	public class FileUploaderFieldAttribute :
		FormFieldAttribute, IFormFieldRequireMultiPart, IFormFieldParseFromEnv {
		/// <summary>
		/// 允许的文件后缀
		/// </summary>
		public HashSet<string> Extensions { get; set; }
		/// <summary>
		/// 允许上传的最大长度，单位是字节
		/// </summary>
		public long MaxContentsLength { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段类型</param>
		/// <param name="extensions">允许的文件后缀，默认是图片后缀</param>
		/// <param name="maxContentsLength">允许上传的最大长度，单位是字节，默认是1MB</param>
		public FileUploaderFieldAttribute(
			string name, string extensions = "png,jpg,jpeg,gif", int maxContentsLength = 1048576) {
			Name = name;
			Extensions = new HashSet<string>(extensions.Split(','));
			MaxContentsLength = maxContentsLength;
		}
	}

	/// <summary>
	/// 隐藏字段
	/// </summary>
	public class HiddenFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		public HiddenFieldAttribute(string name) {
			Name = name;
		}
	}

	/// <summary>
	/// Json字段
	/// 这个字段储存的值会在绑定时序列化
	/// </summary>
	public class JsonFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 字段类型，序列化和反序列化时使用
		/// </summary>
		public Type FieldType { get; set; }

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称</param>
		/// <param name="name">字段类型，序列化和反序列化时使用</param>
		public JsonFieldAttribute(string name, Type fieldType) {
			Name = name;
			FieldType = fieldType;
		}
	}

	/// <summary>
	/// 直接显示Html内容的字段
	/// </summary>
	public class HtmlFieldAttribute : FormFieldAttribute {
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name">字段名称，目前不会用上但是需要预留</param>
		public HtmlFieldAttribute(string name) {
			Name = name;
		}
	}
}
