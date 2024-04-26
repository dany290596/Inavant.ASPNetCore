using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System;
using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;

namespace Empresa.Proyecto.Web.Pages.Sistema
{
	public class CompleteEntityModel : BaseSystemPageModel<CompleteEntity>
	{
		public CompleteEntityModel(ILogger<BaseSystemPageModel<CompleteEntity>> logger, IAsyncRepository<CompleteEntity> repo, IAsyncRepository<SimpleEntity> simpleEntity) : base(logger, repo, simpleEntity)
		{
		}
    }
}