using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {

            context = dbContext;
      

        }

        public IActionResult Index()
        {

            IList<Menu> Menus = context.Menus.ToList();

            return View(Menus);

        }

        public IActionResult Add()
        {
            AddMenuViewModel newMenu = new AddMenuViewModel();

            return View(newMenu);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel AddMenuViewModel)
        {
            if (!ModelState.IsValid)
            {

                return View("Add");

            }

            Menu newMenu = new Menu
            {
                Name = AddMenuViewModel.Name
                
            };

            context.Menus.Add(newMenu);
            context.SaveChanges();


            return Redirect("Menu/ViewMenu/" + newMenu.MenuID);
        }
    }
}
