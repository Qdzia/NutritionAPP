using NutritionApp.Base;
using NutritionApp.Data;
using NutritionApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NutritionApp.ViewModels
{
    class AddRecepieViewModel : BaseVM
    {
        //Tutaj znajduje się prosty formularz sprawdzający dane nowych przepisów w celu ich dodanie
        //Bindujemy kazde pole
        // Poniżej znajduje się logika plikacji czyli utowrzenie obiektu recepie i dodaniu do na pliku
        //Na uwage zasługuje też AddIngidient gdzie dodajemy składnik do listy 
        private Recepie _newRecepie;

        private Recepie[][] PlanForWeek;
        public Recepie NewRecepie
        {
            get { return _newRecepie; }
            set { SetProperty(ref _newRecepie, value); }
        }
        public string Name { get { return NewRecepie.RecepieName; } set { NewRecepie.RecepieName = value; } }
        public string Instruction { get { return NewRecepie.Instruction; } set { NewRecepie.Instruction = value; } }
        public ObservableCollection<Ingredient> Ingredients { get { return NewRecepie.Ingredients; } set { NewRecepie.Ingredients = value; } }

        #region NutritionLabel Binding
        public int Calories { get { return NewRecepie.Label.Calories; } set { NewRecepie.Label.Calories = value; } }
        public int Fat { get { return NewRecepie.Label.Fat; } set { NewRecepie.Label.Fat = value; } }
        public int Carbs { get { return NewRecepie.Label.Carbs; } set { NewRecepie.Label.Carbs = value; } }
        public int Fiber { get { return NewRecepie.Label.Fiber; } set { NewRecepie.Label.Fiber = value; } }
        public int Sugar { get { return NewRecepie.Label.Sugar; } set { NewRecepie.Label.Sugar = value; } }
        public int Protein { get { return NewRecepie.Label.Protein; } set { NewRecepie.Label.Protein = value; } }
        #endregion
        public List<string> UnitList { get; set; }
        private string _selectedUnit;
        public string SelectedUnit
        {
            get { return _selectedUnit; }
            set { SetProperty(ref _selectedUnit, value); }
        }


        public double Count { get; set; }
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
            NewRecepie = new Recepie("","",new ObservableCollection<Ingredient>(),new NutritionLabel(0,0,0,0,0,0));
            UnitList = new List<string>() { "-","g","dag","kg","ml","tbsp","tsp"};
            SelectedUnit = UnitList[0];
            
        }

        public bool CanAddRecepies(object param)
        {
            if (Name.Trim() != "" && Instruction.Trim() != "" && Ingredients.Count > 0 && 
                (Calories != 0 || Fat != 0 || Carbs != 0 || Fiber != 0 || Sugar != 0 || Protein != 0))
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
            if(SelectedUnit == "-") 
                Ingredients.Add(new Ingredient(IngName, Count, Ingredient.Unit.none));
            else
                Ingredients.Add(new Ingredient(IngName, Count, (Ingredient.Unit)Enum.Parse(typeof(Ingredient.Unit), SelectedUnit)));
        }

        public bool CanAddIngredient(object param)
        {
            if (Count >=0 && IngName != null && SelectedUnit != null)
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
