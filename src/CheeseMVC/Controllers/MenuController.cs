using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        [Route("/Menu/ViewMenu/id= {0}")]
        public IActionResult ViewMenu(int id)
        {
            Menu targetMenu = context.Menus.Single(tm => tm.MenuID == id);

            List<CheeseMenu> items = context
            .CheeseMenus
            .Include(item => item.Cheese)
            .Where(cm => cm.MenuID == id)
            .ToList();

            ViewMenuViewModel menuView = new ViewMenuViewModel
            {
                Menu = targetMenu,
                Items = items


            };

            return View(menuView);

        }


        public IActionResult AddItem(int id)
        {
            Menu getMenu = context.Menus.Single(gm => gm.MenuID == id);


        }
    }

}
