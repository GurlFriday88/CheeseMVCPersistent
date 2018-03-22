using CheeseMVC.Data;
using CheeseMVC.Models;
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
    }
}
