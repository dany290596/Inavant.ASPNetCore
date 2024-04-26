using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Empresa.Proyecto.Web.Pages.Sistema
{
    public class CompleteEntityIndexModel : BaseSystemPageModel<CompleteEntity>
    {
        public CompleteEntityIndexModel(ILogger<BaseSystemPageModel<CompleteEntity>> logger, IAsyncRepository<CompleteEntity> repo, IAsyncRepository<SimpleEntity> simpleEntity) : base(logger, repo, simpleEntity)
        {
        }
    }
}