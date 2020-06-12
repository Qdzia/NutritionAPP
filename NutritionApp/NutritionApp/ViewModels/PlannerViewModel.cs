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
        private string _recepieName;
        private string _recepieInstruction;
        private List<string> _recepieIngredients;
        private string _recepieLabel;

        private Recepie _selectedRecepie;
        private List<Recepie> _recepieList;
        private int _selectedMeal;
        private int _selectedDay;

        public string TestString { get { return "Nutrition facts"; } }
        public string RecepieName { get { return _recepieName; } set { SetProperty(ref _recepieName, value); } }
        public string RecepieInstruction { get { return _recepieInstruction; } set { SetProperty(ref _recepieInstruction, value); } }
        public List<string> RecepieIngredients { get { return _recepieIngredients; } set { SetProperty(ref _recepieIngredients, value); } }
        public string RecepieLabel { get { return _recepieLabel; } set { SetProperty(ref _recepieLabel, value); } }

        public Recepie SelectedRecepie
        {
            get { return _selectedRecepie; }
            set { SetProperty(ref _selectedRecepie, value); ChangeRecepie(value); }
        }

        public int SelectedMeal
        {
            get { return _selectedMeal; }
            set { SetProperty(ref _selectedMeal, value); }
        }

        public List<Recepie> RecepieList
        {
            get { return _recepieList; }
            set { SetProperty(ref _recepieList, value); }
        }

        public int SelectedDay
        {
            get { return _selectedDay; }
            set { SetProperty(ref _selectedDay, value); }
        }

        public Recepie[][] PlanForWeek;
        public PlannerViewModel()
        {
            //PlanForWeek = new Recepie[7][];

            //for (int i = 0; i < PlanForWeek.Length; i++)
            //{
            //    PlanForWeek[i] = new Recepie[3];
            //}
            _recepieList = new List<Recepie>();
            _recepieList.Add(new Recepie("Kurczak w sosie", "Wlej Wode i gotowe", new List<string> { "Jajko", "Marchew", "Barszcz" }, new NutritionLabel(1, 2, 3, 4, 5, 6)));
            _recepieList.Add(new Recepie("Marynowane Jajka", "Staranie stłuc i wlać", new List<string> { "Jajko", "Jajko", "Czarne Jajko" }, new NutritionLabel(500, 2, 2, 234, 34, 6)));
            _recepieList.Add(new Recepie("Majonezowa zapiekanka", "Polej kepuczem", new List<string> { "Kepucz", "kanapka", "JSON" }, new NutritionLabel(2220, 21, 33, 44, 85, 61)));

            _selectedRecepie = _recepieList[1];
        }
       

        public void ChangeRecepie(Recepie rec)
        {
            RecepieName = rec.recepieName;
            RecepieInstruction = rec.instruction;
            RecepieIngredients = rec.ingredients;
            RecepieLabel = rec.label.ToString();
            //PlanForWeek[SelectedDay][SelectedMeal] = SelectedRecepie;
        }

    }
}
