using _70325_Dolbik_Vorobei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70325_Dolbik_Vorobei.Controllers;
using _70325_Dolbik_Vorobei.DAL;

namespace _70325_Dolbik_Vorobei.Controllers
{
    public class MenuController : Controller
    {
        IRepository<Dish> repository;

        public MenuController(IRepository<Dish> repo)
        {
            repository = repo;
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            var mi = items.FirstOrDefault(m => m.Controller == c);
            if(mi!=null)
                mi.Active = "active";
            return PartialView(items);
        }
        public PartialViewResult UserInfo()
        {
            return PartialView(items);
        }
        public PartialViewResult Side()
        {
            var groups = repository
                .GetAll()
                .Select(d => d.GroupName)
                .Distinct();
            return PartialView(groups);
        }
        public PartialViewResult Map()
        {
            return PartialView(items);
        }

        List<MenuItem> items = new List<MenuItem>()
        {
            new MenuItem{Name ="Домой", Controller="Home", Action="Index", Active=string.Empty},
            new MenuItem{Name="Каталог", Controller="Dish", Action="List", Active=string.Empty},
            new MenuItem{Name="Администрирование", Controller="Admin",Action="Index", Active=string.Empty},
        };
    }
}