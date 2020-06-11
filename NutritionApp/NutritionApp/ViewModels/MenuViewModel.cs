using NutritionApp.Base;
using NutritionApp.Commands;
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

            _mainMenu.Add(new MenuItemViewModel("Planner",MenuCommands.GotoPlannerCommand));
            _mainMenu.Add(new MenuItemViewModel("Calories",MenuCommands.GotoStatisticsCommand));
            _mainMenu.Add(new MenuItemViewModel("Grocery List",MenuCommands.GotoGroceryListCommand));
            _mainMenu.Add(new MenuItemViewModel("Add Recepie"));
        }
    }
}
