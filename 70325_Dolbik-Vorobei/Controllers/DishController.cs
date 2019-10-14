using _70325_Dolbik_Vorobei.DAL;
using _70325_Dolbik_Vorobei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _70325_Dolbik_Vorobei.Controllers
{
    public class DishController : Controller
    {
        int pageSize = 3;

        IRepository<Dish> repository;
        public DishController(IRepository<Dish> repo)
        {
            repository = repo;
        }
        // GET: Dish
        public ActionResult List(string group, int page = 1)
        {
            var lst = repository.GetAll()
                .Where(d => group == null
                || d.GroupName.Equals(group))
                .OrderBy(d => d.Calories);
            var model = PageListViewModel<Dish>
                .CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);
        }
        public async Task<FileResult> GetImage(int id)
        {
            var dish = await repository.GetAsync(id);
            if (dish != null)
            {
                return new FileContentResult(dish.Image, dish.MimeType);
            }
            else return null;
        }

    }
}