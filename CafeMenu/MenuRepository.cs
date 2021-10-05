using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu
{
    public class MenuRepository
    {
        private readonly List<MenuClass> _menu = new List<MenuClass>();

        //Crud

        //Create
        public bool AddMenuItem(MenuClass item)
        {
            int startingCount = _menu.Count;

            _menu.Add(item);

            bool wasAdded = (_menu.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //Read

        public List<MenuClass> GetContents()
        {
            return _menu;
        }

        //Update

        //Delete
        public bool DeleteMenuItem(MenuClass existingMenuItem)
        {
            bool result = _menu.Remove(existingMenuItem);
            return result;
        }
    }
}
