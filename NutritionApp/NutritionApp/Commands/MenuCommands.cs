using NutritionApp.Base;
using NutritionApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Commands
{
    class MenuCommands
    {
        //Znajdują się tu komendy które przekierowują nas do poszczególnych view z użyciem Relay Command
        public static void GotoPlanner(object param)
        {
            MainViewModel mvm = param as MainViewModel;
            mvm.SelectedViewModel = new PlannerViewModel();
        }
        public static void GotoGroceryList(object param)
        {
            MainViewModel mvm = param as MainViewModel;
            mvm.SelectedViewModel = new GroceryListViewModel();
        }
        public static void GotoStatistics(object param)
        {
            MainViewModel mvm = param as MainViewModel;
            mvm.SelectedViewModel = new StatisticsViewModel();
        }
        public static void GotoAddRecepie(object param)
        {
            MainViewModel mvm = param as MainViewModel;
            mvm.SelectedViewModel = new AddRecepieViewModel();
        }
        public static bool CanUpdateView(object param)
        {
            return true;
        }
        public static RelayCommand<object> GotoGroceryListCommand
        {
            get {return new RelayCommand<object>(GotoGroceryList);}
        }
        public static RelayCommand<object> GotoPlannerCommand
        {
            get { return new RelayCommand<object>(GotoPlanner); }
        }
        public static RelayCommand<object> GotoStatisticsCommand
        {
            get { return new RelayCommand<object>(GotoStatistics); }
        }
        public static RelayCommand<object> GotoAddRecepieCommand
        {
            get { return new RelayCommand<object>(GotoAddRecepie); }
        }
    }
}
