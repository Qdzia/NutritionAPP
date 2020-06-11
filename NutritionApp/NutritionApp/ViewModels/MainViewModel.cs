using NutritionApp.Base;
using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.ViewModels
{
    class MainViewModel : BaseVM
    {
        private MenuViewModel _menuViewModel;
        public List<MenuItemViewModel> MainMenu
        {
            get { return _menuViewModel.MainMenu; }
        }
        public MainViewModel()
        {
            _menuViewModel = new MenuViewModel();

            UpdateViewCommand = new RelayCommand<object>(UpdateView, CanUpdateView);
            _selectedViewModel = new PlannerViewModel();
        }
        public PlannerViewModel Planner { get; set; }


        public RelayCommand<object> UpdateViewCommand { get; set; }

        private BaseVM _selectedViewModel;

        public BaseVM SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { SetProperty(ref _selectedViewModel, value); }
        }

        public void UpdateView(object param)
        {

            if (param.ToString() == "StartMenu")
            {
                SelectedViewModel = new PlannerViewModel();
            }
            else if (param.ToString() == "Application")
            {
                SelectedViewModel = new PlannerViewModel();
            }
        }
        public bool CanUpdateView(object param)
        {
            return true;
        }

    }
}
