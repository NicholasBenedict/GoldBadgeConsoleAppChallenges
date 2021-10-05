using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu
{
    public class MenuClass
    {
        public MenuClass() { }
        public MenuClass(int mealNumber, string mealName, string mealDescription, List<string> ingredients, decimal price) 
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();

        public decimal Price { get; set; }
    }
}
