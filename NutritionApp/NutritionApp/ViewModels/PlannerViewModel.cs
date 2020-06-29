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
    class PlannerViewModel : BaseVM
    {
        #region Variables
        //Display Recepie
        private string _recepieName;
        private string _recepieInstruction;
        private ObservableCollection<Ingredient> _recepieIngredients;
        private string _recepieLabel;

        //Create Week Plan 
        public RelayCommand<string> ChangeDayCommand { get; set; }
        public RelayCommand DeleteRecepieCommand { get; set; }
        public Recepie[][] PlanForWeek;
        private Recepie _selectedRecepie;
        private ObservableCollection<Recepie> _recepieList;
        private int _curDay = 0;

        //Manage Buttoms for Meals
        public RelayCommand<string> ChangeMealCommand { get; set; }
        private string _breakfast;
        private string _dinner;
        private string _supper;


        public string RecepieName
        {
            get { return _recepieName; }
            set { SetProperty(ref _recepieName, value); }
        }

        public string RecepieInstruction
        {
            get { return _recepieInstruction; }
            set { SetProperty(ref _recepieInstruction, value); }
        }

        public ObservableCollection<Ingredient> RecepieIngredients
        {
            
            get { return _recepieIngredients; }
            
            set { SetProperty(ref _recepieIngredients, value); }
        }

        public string RecepieLabel
        {
            get { return _recepieLabel; }
            set { SetProperty(ref _recepieLabel, value); }
        }

        public Recepie SelectedRecepie
        {
            get { return _selectedRecepie; }
            set { SetProperty(ref _selectedRecepie, value); ChangeRecepie(value); }
        }

        public ObservableCollection<Recepie> RecepieList
        {
            get { return _recepieList; }
            set { SetProperty(ref _recepieList, value); }
        }

        public string Breakfast
        {
            get { return _breakfast; }
            set { SetProperty(ref _breakfast, value); }
        }

        public string Dinner
        {
            get { return _dinner; }
            set { SetProperty(ref _dinner, value); }
        }

        public string Supper
        {
            get { return _supper; }
            set { SetProperty(ref _supper, value); }
        }

        #endregion

        #region Constructor
        public PlannerViewModel()
        {
            PlanForWeek = RecepieBase.Instance.PlanForWeek;

            ChangeMealCommand = new RelayCommand<string>(ChangeMeal);
            ChangeDayCommand = new RelayCommand<string>(ChangeDay);
            DeleteRecepieCommand = new RelayCommand(DeleteRecepie);

            _recepieList = RecepieBase.Instance.Recepies;
            
            ChangeDay("0");
        }
        #endregion

        #region Methods
        public void ChangeRecepie(Recepie rec)
        {
            if (rec == null)
                return;
            RecepieName = rec.recepieName;
            RecepieInstruction = rec.instruction;
            RecepieIngredients = rec.ingredients;
            RecepieLabel = rec.label.ToString();

        }

        void ChangeMeal(string choice)
        {
            if (SelectedRecepie == null) return;
            
            string name = SelectedRecepie.recepieName;
            int num = -1;

            if (choice == "Breakfast")  { Breakfast = name; num = 0; }
            if (choice == "Dinner")     { Dinner = name;    num = 1; }
            if (choice == "Supper")     { Supper = name;    num = 2; }

            if(num != -1) PlanForWeek[_curDay][num] = SelectedRecepie;
        }

        void ChangeDay(string day)
        {
            _curDay = Convert.ToInt32(day);

            if (PlanForWeek[_curDay][0] != null) Breakfast = PlanForWeek[_curDay][0].recepieName;
            else Breakfast = "Breakfast";

            if (PlanForWeek[_curDay][1] != null) Dinner = PlanForWeek[_curDay][1].recepieName;
            else Dinner = "Dinner";

            if (PlanForWeek[_curDay][2] != null) Supper = PlanForWeek[_curDay][2].recepieName;
            else Supper = "Supper";
        }

        void DeleteRecepie()
        {
            RecepieBase.Instance.Recepies.Remove(SelectedRecepie);
            SelectedRecepie = null;
            RecepieBase.Instance.SaveRecepiesToFile();
        }
        #endregion
    }
}
