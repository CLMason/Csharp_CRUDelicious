using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext context; 
        public HomeController(MyContext mc)//dependency injection
        {
            context = mc;
        }

        [HttpGet ("")]
        public IActionResult Index()
        {
            ViewBag.Dishes = context.Dishes.OrderByDescending(d => d.CreatedAt).ToArray().Reverse(); //iterating through all the dishes and ordering it by createdAt and puts it into the array
            return View();
        }
        [HttpGet("new")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                context.Add(newDish);
                context.SaveChanges();
                Console.WriteLine(newDish);
                return Redirect("/");
            }
            ViewBag.Dishes = context.Dishes;
            return View("new");
        }
        [HttpGet("{DishId}")]
        public IActionResult ViewDish(int DishId)
        {
            Dish thisDish = context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            return View("Dish", thisDish);
        }
        
        [HttpPost("delete/{DishId}")]

        public IActionResult DeleteDish(int DishId)
        {
            Dish thisDish = context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            context.Dishes.Remove(thisDish);
            context.SaveChanges();
            return Redirect("/");
        }   

        [HttpGet("edit/{DishId}")]
        public IActionResult Edit (int DishId)
        {
            Dish dishToEdit = context.FindOneDish(DishId);
            return View("EditDish", dishToEdit);
        }
             
        [HttpPost("edit/{DishId}")]
        public IActionResult Update(int DishId, Dish editedDish)
        {
            if(ModelState.IsValid)
            {
                context.Update(DishId, editedDish);
                return Redirect("/");
            }
            return View("EditDish", editedDish);
        }

    }
}
