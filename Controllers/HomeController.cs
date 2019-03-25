using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishContext dbContext;
        public HomeController(DishContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Dish> model = dbContext.Dishes.ToList();
            
            return View(model);
        }

        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View();
        }

        [HttpGet("edit/{dishID}")]
        public IActionResult Dishedit(int dishId)
        {
            Dish model = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishId);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet("{dishID}")]
        public IActionResult DishDescription(int dishId)
        {
            Dish model = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishId);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost("add")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("NewDish");
        }

        [HttpGet("delete/{dishID}")]
        public IActionResult DeleteDish(int dishId)
        {

            Dish toDelete = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishId);
            if(toDelete == null)
                return RedirectToAction("Index");
            
            dbContext.Dishes.Remove(toDelete);
            dbContext.SaveChanges();
    
            return RedirectToAction("Index");
            
        }

        [HttpPost("update/{dishID}")]
        public IActionResult Update(Dish udish, int dishID)
        {
            Dish toUpdate = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishID);
            if(ModelState.IsValid)
            {
                toUpdate.ChefName = udish.ChefName;
                toUpdate.DishName = udish.DishName;
                toUpdate.Calories = udish.Calories;
                toUpdate.Tastiness = udish.Tastiness;
                toUpdate.Description = udish.Description;
                toUpdate.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Dishedit",udish);
        }
    }
}
