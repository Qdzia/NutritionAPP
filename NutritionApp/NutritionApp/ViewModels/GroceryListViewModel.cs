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
        private Ingredient _selectedIngredient;
        private List<string> inList;
        private List<Ingredient> _groceryList;

        public Recepie[][] PlanForWeek;
        public RelayCommand DeleteIngredientCommand { get; set; }

        public List<Ingredient> GroceryList
        {
            get { return _groceryList; }
            set { SetProperty(ref _groceryList, value); }
        }
        
        public Ingredient SelectedIngredient
        {
            get { return _selectedIngredient; }
            set { SetProperty(ref _selectedIngredient, value); }
        }
        
        public GroceryListViewModel()
        {
            _groceryList = new List<Ingredient>();
            inList = new List<string>();
            PlanForWeek = RecepieBase.Instance.PlanForWeek;
            SumItUp();
            DeleteIngredientCommand = new RelayCommand(DeleteIngredient);
        }

        public void DeleteIngredient()
        {
            List<Ingredient> list = new List<Ingredient>();
            GroceryList.Remove(SelectedIngredient);
            foreach (var ing in GroceryList)
            {
                list.Add(ing);
            }
            GroceryList = list;
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
