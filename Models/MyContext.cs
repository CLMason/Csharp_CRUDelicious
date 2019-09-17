using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
 
namespace CRUDelicious.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Dish> Dishes {get; set;}
        public void Create(Dish dish)
        {
            Dishes.Add(dish);
            SaveChanges();
        }
       
       public Dish FindOneDish(int DishId)
        {
            return Dishes.FirstOrDefault(d => d.DishId == DishId); 
        }

        public void Update(int DishId, Dish editedDish)
        {
            Dish dishToEdit = this.FindOneDish(DishId);
            dishToEdit.Name = editedDish.Name;
            dishToEdit.Chef = editedDish.Chef;
            dishToEdit.Calories = editedDish.Calories;
            dishToEdit.Tastiness = editedDish.Tastiness;
            dishToEdit.Description = editedDish.Description;
            dishToEdit.UpdatedAt= DateTime.Now;
            SaveChanges();
        } 
    }
}
