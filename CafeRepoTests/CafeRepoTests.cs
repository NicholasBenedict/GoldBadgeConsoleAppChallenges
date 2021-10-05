using CafeMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeRepoTests
{
    [TestClass]
    public class CafeRepoTests
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBool()
        {
            //Arrange

            MenuClass menu = new MenuClass();
            MenuRepository repo = new MenuRepository();

            bool success = repo.AddMenuItem(menu);

            //assert

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetMenuItems_ShouldReturnListofMenuItems()
        {
            List<string> newItem = new List<string>();
            newItem.Add("patty");
            newItem.Add("bun");

            MenuClass menu = new MenuClass(1, "hamburger", "its a hamburger", newItem, 5.00m);
            MenuRepository repo = new MenuRepository();
            repo.AddMenuItem(menu);

            List<MenuClass> menuList = repo.GetContents();
            bool success = menuList.Contains(menu);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange 

            List<string> newItem = new List<string>();
            newItem.Add("patty");
            newItem.Add("bun");

            MenuClass menu = new MenuClass(1, "hamburger", "its a hamburger", newItem, 5.00m);
            
            MenuRepository repo = new MenuRepository();

            repo.AddMenuItem(menu);
            
            bool result = repo.DeleteMenuItem(menu);

            Assert.IsTrue(result);
        }
    }
}
