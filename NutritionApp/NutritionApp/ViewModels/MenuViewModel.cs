using NutritionApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.ViewModels
{
    class MenuViewModel : BaseVM
    {
        private List<MenuItemViewModel> _mainMenu;
        public List<MenuItemViewModel> MainMenu
        {
            get { return _mainMenu; }
        }

        public MenuViewModel()
        {
            _mainMenu = new List<MenuItemViewModel>();

            _mainMenu.Add(new MenuItemViewModel("Planner"));
            _mainMenu.Add(new MenuItemViewModel("Calories"));
            _mainMenu.Add(new MenuItemViewModel("Grocery List"));
            _mainMenu.Add(new MenuItemViewModel("Add Recepie"));
        }
    }
}
