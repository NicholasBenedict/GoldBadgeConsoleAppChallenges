using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu
{
    public class MenuUI
    {
        private MenuRepository _menu = new MenuRepository();

        public void Run()
        {
            SeedData();
            RunMenu();    
        }
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Cafe\n");

                Console.WriteLine("What would you like to do (please enter the number of the option you want)\n" +
                    "1. Add a menu Item\n" +
                    "2. Delete a menu Item\n" +
                    "3. List all menu Items\n" +
                    "4. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        DisplayMenu();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry that is not an option");
                        break;
                }
            }
        }
        private void AddNewMenuItem()
        {
            Console.Clear();
            MenuClass menu = new MenuClass();

            Console.WriteLine("Please enter the meal number: ");
            menu.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the name of the meal: ");
            menu.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a description of the meal: ");
            menu.MealDescription = Console.ReadLine();

            Console.WriteLine("Please enter the price of the meal: ");
            menu.Price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("How many different ingredients are in the item?: ");
            int counter = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= counter; i++)
            {
                Console.WriteLine($"Please enter the {i} ingredient: ");
                string holder = Console.ReadLine();
                menu.Ingredients.Add(holder);
            }

            _menu.AddMenuItem(menu);
        }
        private void DisplayMenu()
        {
            Console.Clear();
            List<MenuClass> menus = _menu.GetContents();

            foreach (MenuClass menu in menus)
            {
                DisplayContent(menu);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void RemoveMenuItem()
        {
            List<MenuClass> menuList = _menu.GetContents();
            int index = 1;
            foreach(MenuClass menu in menuList)
            {
                Console.WriteLine($"{index}. {menu.MealName}");
                index++;
            }
            Console.WriteLine("Select the number of the menu item you want to remove: ");
            int targetID = Convert.ToInt32(Console.ReadLine());
            int targetIndex = targetID - 1;

            if (targetIndex >= 0 && targetIndex < menuList.Count)
            {
                MenuClass targetMenu = menuList[targetIndex];

                if (_menu.DeleteMenuItem(targetMenu))
                {
                    Console.WriteLine($"{targetMenu.MealName} was successfully deleted");
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                }
            }
            else
            {
                Console.WriteLine("Sorry that is not a valid selection");
            }
        }
        private void DisplayContent(MenuClass menu)
        {
            Console.WriteLine
                ($"Item Number: {menu.MealNumber}\n" +
                $"Meal Name: {menu.MealName}\n" +
                $"Meal Description: {menu.MealDescription}\n" +
                $"Meal Price: {menu.Price}\n" +
                $"The ingredients are as follows");
            int holder = menu.Ingredients.Count();
            for (int i = 1; i < holder; i++)
            {
                Console.WriteLine(menu.Ingredients[i]);
            }

        }

        private void SeedData()
        {
            List<string> burger = new List<string>();
            burger.Add("bun");
            burger.Add("patty");
            burger.Add("cheese");
            burger.Add("lettuce");
            MenuClass hamburger = new MenuClass(1, "hamburger", "its a hamburger",burger, 6.99m);
            MenuClass cheeseburger = new MenuClass(2, "cheeseburger", "its a cheeseburger", burger, 7.99m);
            MenuClass fancyCheeseBurger = new MenuClass(3, "fancy cheeseburger", "its like the regular cheeseburger but fancy", burger, 10m);

            _menu.AddMenuItem(hamburger);
            _menu.AddMenuItem(cheeseburger);
            _menu.AddMenuItem(fancyCheeseBurger);
        }

    }
}
