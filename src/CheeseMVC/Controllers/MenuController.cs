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


            return Redirect("/ViewMenu/" + newMenu.MenuID);
        }

        //[HttpGet]
        //public IActionResult ViewMenu(int id)
        //{
        //    Menu targetMenu = context.Menus.Single(tm => tm.MenuID == id);

        //    return View("Index");

        //}

        [HttpGet]
        //[Route("/ViewMenu/id= {0}")]
        public IActionResult ViewMenu(int id)
        {
            Menu targetMenu = context.Menus.Single(tm => tm.MenuID == id);

            //List<CheeseMenu> items = context
            //.CheeseMenus
            //.Include(item => item.Cheese)
            //.Where(cm => cm.MenuID == id)
            //.ToList();

            ViewMenuViewModel menuView = new ViewMenuViewModel
            {
                Menu = targetMenu,
                //Items = items


            };

            return View(menuView);

        }


        public IActionResult AddItem(int id)
        {
            Menu getMenu = context.Menus.Single(gm => gm.MenuID == id);
            List<Cheese> allCheese = context.Cheeses.ToList();

            AddMenuItemViewModel addMenuItemView = new AddMenuItemViewModel(getMenu,allCheese );

            return View(addMenuItemView);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemView)
        {
            

            if (ModelState.IsValid)
            {
                IList<CheeseMenu> existingItems = context.CheeseMenus
                .Where(cm => cm.CheeseID == addMenuItemView.cheeseID)
                .Where(cm => cm.MenuID == addMenuItemView.menuID).ToList();
                if (existingItems == null)
                {

                    CheeseMenu newCheeseMenu = new CheeseMenu
                    {
                        CheeseID = addMenuItemView.cheeseID,
                        MenuID = addMenuItemView.menuID

                    };
                    context.CheeseMenus.Add(newCheeseMenu);
                    context.SaveChanges();

                    return Redirect("Menu/ViewMenu/ " + newCheeseMenu.MenuID);
                }


            }
            
            

            return View("AddItem");






        }
    }

}
