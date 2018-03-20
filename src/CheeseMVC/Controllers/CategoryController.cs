using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;
        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CheeseCategory>cheeseCategories = context.Categories.ToList();

            return View(cheeseCategories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel newCategory = new AddCategoryViewModel();
           

            return View(newCategory);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel formInput)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");

            }

            //if viewmodel passes validation create a new cheese category and add it to the datatbase context

            CheeseCategory newCategory = new CheeseCategory
            {
                Name = formInput.Name
            };

            context.Categories.Add(newCategory);
            context.SaveChanges();
            return Redirect("/Category");
        }
    }
}
