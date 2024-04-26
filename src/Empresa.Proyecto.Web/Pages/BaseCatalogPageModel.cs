using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;

namespace Empresa.Proyecto.Web.Pages
{
    public class BaseCatalogPageModel<T>: PageModel where T : BaseEntity
    {
        private readonly IAsyncRepository<SimpleEntity> Repo;
        private readonly ILogger<BaseCatalogPageModel<T>> Logger;

        public IReadOnlyList<T> Entidades { get; set; } = null!;

        public BaseCatalogPageModel(ILogger<BaseCatalogPageModel<T>> logger, IAsyncRepository<SimpleEntity> repo)
        {
            Repo = repo;
            Logger = logger;
        }

        public async Task<JsonResult> OnPostCatalog()
        {
            var list = Repo.GetAll().OrderBy(x => x.Name).ToList();
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
            List<SimpleEntity> listOrder = new List<SimpleEntity>();
            foreach (var item in list)
            {
                listOrder.Add(item);
            }

            return new JsonResult(new { data = listOrder });
        }
    }
}
