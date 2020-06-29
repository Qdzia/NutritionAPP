using NutritionApp.Base;
using NutritionApp.Data;
using NutritionApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.ViewModels
{
    class AddRecepieViewModel : BaseVM
    {
        private Recepie _newRecepie;

        private Recepie[][] PlanForWeek;
        public Recepie NewRecepie
        {
            get { return _newRecepie; }
            set { SetProperty(ref _newRecepie, value); }
        }
        public string Name { get { return NewRecepie.recepieName; } set { NewRecepie.recepieName = value; } }
        public string Instruction { get { return NewRecepie.instruction; } set { NewRecepie.instruction = value; } }
        public ObservableCollection<Ingredient> Ingredients { get { return NewRecepie.ingredients; } set { NewRecepie.ingredients = value; } }
        //public List<Ingredient> Ingredients { get { return NewRecepie.ingredients; } set {SetProperty(ref NewRecepie.ingredients, value); } }

        #region NutritionLabel Binding
        public int Calories { get { return NewRecepie.label.calories; } set { NewRecepie.label.calories = value; } }
        public int Fat { get { return NewRecepie.label.fat; } set { NewRecepie.label.fat = value; } }
        public int Carbs { get { return NewRecepie.label.carbs; } set { NewRecepie.label.carbs = value; } }
        public int Fiber { get { return NewRecepie.label.fiber; } set { NewRecepie.label.fiber = value; } }
        public int Sugar { get { return NewRecepie.label.sugar; } set { NewRecepie.label.sugar = value; } }
        public int Protein { get { return NewRecepie.label.protein; } set { NewRecepie.label.protein = value; } }
        #endregion
        public List<string> UnitList { get; set; }
        private string _selectedUnit;
        public string SelectedUnit
        {
            get { return _selectedUnit; }
            set { SetProperty(ref _selectedUnit, value); }
        }


        public int Count { get; set; }
        public string IngName { get; set; }
        public Ingredient SelectedIngredient { get; set; }
        public RelayCommand AddToList { get; set; }
        public RelayCommand AddRecepiesToBase { get; set; }
        public RelayCommand DeleteIng { get; set; }


        public AddRecepieViewModel()
        {
            AddToList = new RelayCommand(AddIngredient, CanAddIngredient);
            AddRecepiesToBase = new RelayCommand(AddRecepies, CanAddRecepies);
            DeleteIng = new RelayCommand(DeleteIngredient, CanDeleteIngredient);

            PlanForWeek = RecepieBase.Instance.PlanForWeek;
            NewRecepie = new Recepie("Wpisz nazwe","Instrukcja tutaj",new ObservableCollection<Ingredient>(),new NutritionLabel(1,2,3,4,5,6));
            UnitList = new List<string>();
            UnitList.Add("kg");
            UnitList.Add("dag");
            UnitList.Add("g");
            Count = 10;
            IngName = "Marchew";
            Ingredients.Add(new Ingredient(IngName, 5, (Ingredient.Unit)Enum.Parse(typeof(Ingredient.Unit), "g")));
        }

        public bool CanAddRecepies(object param)
        {
            if (Name != null && Instruction != null && Ingredients != null)
                return true;
            else
                return false;
        }

        public void AddRecepies()
        {
            RecepieBase.Instance.Recepies.Add(NewRecepie);
            RecepieBase.Instance.SaveRecepiesToFile();
        }

        public void AddIngredient()
        {
            Ingredients.Add(new Ingredient(IngName, Count, (Ingredient.Unit)Enum.Parse(typeof(Ingredient.Unit), SelectedUnit)));
        }

        public bool CanAddIngredient(object param)
        {
            if (Count != 0 && IngName != null)
                return true;
            else
                return false;
        }

        public bool CanDeleteIngredient(object param)
        {
            if (SelectedIngredient != null)
                return true;

            return false;
        }
        public void DeleteIngredient()
        {
            Ingredients.Remove(SelectedIngredient);
        }

    }
}
