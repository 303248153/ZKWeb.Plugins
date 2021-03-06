﻿using System;
using System.Collections.Generic;
using System.Linq;
using ZKWeb.Plugins.Common.Admin.src.Controllers;
using ZKWeb.Plugins.Common.Admin.src.Domain.Entities;
using ZKWeb.Plugins.Common.Base.src.Domain.Repositories.Interfaces;
using ZKWeb.Plugins.Common.Base.src.UIComponents.AjaxTable;
using ZKWeb.Plugins.Common.Base.src.UIComponents.AjaxTable.Extensions;
using ZKWeb.Plugins.Common.Base.src.UIComponents.AjaxTable.Interfaces;
using ZKWeb.Plugins.Common.Base.src.UIComponents.BaseTable;
using ZKWeb.Plugins.Common.Base.src.UIComponents.Forms;
using ZKWeb.Plugins.Common.Base.src.UIComponents.Forms.Attributes;
using ZKWeb.Plugins.Common.UserContact.src.Domain.Services;
using ZKWebStandard.Extensions;
using ZKWebStandard.Ioc;

namespace ZKWeb.Plugins.Common.UserContact.src.Components.AjaxTableHandlers {
	/// <summary>
	/// 添加以下列到用户管理
	/// - 电话
	/// - 手机
	/// </summary>
	[ExportMany]
	public class AddColumnsToUserManageApp :
		IAjaxTableExtraHandler<User, Guid, UserCrudController.TableHandler> {
		public void BuildTable(AjaxTableBuilder table, AjaxTableSearchBarBuilder searchBar) {
			searchBar.Conditions.Add(new FormField(new TextBoxFieldAttribute("Contact Information")));
		}

		public Func<TResult> WrapQueryMethod<TResult>(
			AjaxTableSearchRequest request, Func<TResult> queryMethod) { return queryMethod; }

		public void OnQuery(AjaxTableSearchRequest request, ref IQueryable<User> query) {
			var contact = request.Conditions.GetOrDefault<string>("Contact Information");
			if (!string.IsNullOrEmpty(contact)) {
				var contactRepository = Application.Ioc.Resolve<IRepository<Domain.Entities.UserContact, Guid>>();
				var contactQuery = contactRepository.Query();
				query = query.Join(contactQuery, u => u.Id, c => c.User.Id, (u, c) => new { u, c })
					.Where(p =>
						p.c.Email.Contains(contact) ||
						p.c.Mobile.Contains(contact) ||
						p.c.Tel.Contains(contact) ||
						p.c.Address.Contains(contact) ||
						p.c.QQ.Contains(contact))
					.Select(p => p.u);
			}
		}

		public void OnSort(AjaxTableSearchRequest request, ref IQueryable<User> query) { }

		public void OnSelect(AjaxTableSearchRequest request, IList<EntityToTableRow<User>> pairs) {
			var userContactManager = Application.Ioc.Resolve<UserContactManager>();
			var contacts = userContactManager.GetContacts(pairs.Select(p => p.Entity.Id).ToList());
			foreach (var pair in pairs) {
				var contact = contacts.GetOrDefault(pair.Entity.Id) ??
					new Domain.Entities.UserContact();
				pair.Row["Tel"] = contact.Tel;
				pair.Row["Mobile"] = contact.Mobile;
			}
		}

		public void OnResponse(AjaxTableSearchRequest request, AjaxTableSearchResponse response) {
			var usernameColumn = response.Columns.FirstOrDefault(c => c.Key == "Username");
			if (usernameColumn != null) {
				usernameColumn.Width = "35%";
			}
			response.Columns.MoveAfter(response.Columns.AddMemberColumn("Tel"), "Username");
			response.Columns.MoveAfter(response.Columns.AddMemberColumn("Mobile"), "Tel");
		}
	}
}
