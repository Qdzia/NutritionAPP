using NutritionApp.Base;
using NutritionApp.Data;
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
        public Recepie[][] PlanForWeek;

        List<string> inList;

        List<Ingredient> _groceryList;
        public List<Ingredient> GroceryList
        {
            get { return _groceryList; }
            set { SetProperty(ref _groceryList, value); }
        }

        public GroceryListViewModel()
        {
            _groceryList = new List<Ingredient>();
            inList = new List<string>();
            PlanForWeek = RecepieBase.Instance.PlanForWeek;
            SumItUp();
        }

        public void SumItUp()
        {
            GroceryList = new List<Ingredient>();
            inList = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    AddRecepieToGroceryList(PlanForWeek[i][j]);
                }
            }
        }

        void AddRecepieToGroceryList(Recepie rec)
        {
            if (rec == null) return;
            
            foreach (Ingredient ing in rec.ingredients)
            {
                if (!inList.Contains(ing.name))
                {
                    inList.Add(ing.name);
                    GroceryList.Add(new Ingredient(ing.name, ing.count, ing.unit));
                }
                else
                {
                    for (int k = 0; k < GroceryList.Count; k++)
                    {
                        if (GroceryList[k].name == ing.name)
                        {
                            GroceryList[k].SumIngredient(ing);
                            k = GroceryList.Count;
                        }
                    }
                }
            }
        }
        
    }
}
