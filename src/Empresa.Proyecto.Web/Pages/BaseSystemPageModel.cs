using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Proyecto.Web.Pages
{
    public class BaseSystemPageModel<T> : PageModel where T : BaseEntity
    {
        private readonly IAsyncRepository<CompleteEntity> Repo;
        private readonly IAsyncRepository<SimpleEntity> _simpleEntity;
        private readonly ILogger<BaseSystemPageModel<T>> Logger;
        [BindProperty]
        public CompleteEntity? CompleteEntity { get; set; }

        public IReadOnlyList<T> Entidades { get; set; } = null!;

        public BaseSystemPageModel(
            ILogger<BaseSystemPageModel<T>> logger,
            IAsyncRepository<CompleteEntity> repo,
            IAsyncRepository<SimpleEntity> simpleEntity
        )
        {
            Repo = repo;
            Logger = logger;
            _simpleEntity = simpleEntity;

        }

        public void OnGet()
        {
            var simpleEntity = _simpleEntity.GetAll().ToList();
            var items = simpleEntity.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();

            ViewData["VDSimpleEntity"] = items;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (CompleteEntity.Name == "")
            {
                return Page();
            }
            if (CompleteEntity.SimpleEntityId == null)
            {
                return Page();
            }
            if (CompleteEntity.Created == null)
            {
                return Page();
            }
            if (CompleteEntity.Modified == null)
            {
                return Page();
            }

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            await Repo.AddAsync(CompleteEntity);

            return RedirectToPage("/Sistema/CompleteEntityIndex");
        }

        public async Task<JsonResult> OnPostCatalog()
        {
            var list = Repo.GetAll().OrderBy(x => x.Name).ToList();
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
            List<CompleteEntity> listOrder = new List<CompleteEntity>();
            foreach (var item in list)
            {
                listOrder.Add(item);
            }

            return new JsonResult(new { data = listOrder });
        }
    }
}