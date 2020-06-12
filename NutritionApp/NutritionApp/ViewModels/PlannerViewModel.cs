using NutritionApp.Base;
using NutritionApp.Models;
using System;
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
        private List<string> _recepieIngredients;
        private string _recepieLabel;

        //Create Week Plan 
        public RelayCommand<string> ChangeDayCommand { get; set; }
        public Recepie[][] PlanForWeek;
        private Recepie _selectedRecepie;
        private List<Recepie> _recepieList;
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

        public List<string> RecepieIngredients
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

        public List<Recepie> RecepieList
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
            PlanForWeek = new Recepie[7][];
            for (int i = 0; i < PlanForWeek.Length; i++)
            {
                PlanForWeek[i] = new Recepie[3];
            }

            ChangeMealCommand = new RelayCommand<string>(ChangeMeal);
            ChangeDayCommand = new RelayCommand<string>(ChangeDay);

            _recepieList = new List<Recepie>();
            //Will be chnage with load Recepie data base
            _recepieList.Add(new Recepie("Kurczak w sosie", "Wlej Wode i gotowe", new List<string> { "Jajko", "Marchew", "Barszcz" }, new NutritionLabel(1, 2, 3, 4, 5, 6)));
            _recepieList.Add(new Recepie("Marynowane Jajka", "Staranie stłuc i wlać", new List<string> { "Jajko", "Jajko", "Czarne Jajko" }, new NutritionLabel(500, 2, 2, 234, 34, 6)));
            _recepieList.Add(new Recepie("Majonezowa zapiekanka", "Polej kepuczem", new List<string> { "Kepucz", "kanapka", "JSON" }, new NutritionLabel(2220, 21, 33, 44, 85, 61)));

            _selectedRecepie = _recepieList[1];
            ChangeDay("0");
        }
        #endregion

        #region Methods
        public void ChangeRecepie(Recepie rec)
        {
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
        #endregion
    }
}
