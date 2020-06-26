using NutritionApp.Base;
using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.ViewModels
{
    class GroceryListViewModel : BaseVM
    {
        //List<Ingredient> _groceryList;
        //public List<Ingredient> GroceryList
        //{
        //    get { return _groceryList; }
        //    set { SetProperty(ref _groceryList, value); }
        //}
        List<string> _groceryList;
        public List<string> GroceryList
        {
            get { return _groceryList; }
            set { SetProperty(ref _groceryList, value); }
        }

        public GroceryListViewModel()
        {
            //_groceryList = new List<Ingredient>();
            //GroceryList.Add(new Ingredient("Marchew", 12, Ingredient.Unit.g));
            //GroceryList.Add(new Ingredient("Ogórek", 15, Ingredient.Unit.g));
            _groceryList = new List<string>();
            _groceryList.Add("ass");
            _groceryList.Add("dd");
        }

        public string Test { get { return "ass"; } }
    }
}
