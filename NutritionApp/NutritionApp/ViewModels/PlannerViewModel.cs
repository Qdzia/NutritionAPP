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
        public string TestString { get { return "Test string"; } }
        public PlannerViewModel()
        {
            PlanForWeek = new Recepie[7][];

            for (int i = 0; i < PlanForWeek.Length; i++)
            {
                PlanForWeek[i] = new Recepie[3];
            }

            _selectedRecepie = new Recepie("Kurczak w sosie", "Wlej Wode i gotowe", new List<string> { "Jajko", "Marchew", "Barszcz" }, new NutritionLabel(1, 2, 3, 4, 5, 6));
        }
        private Recepie _selectedRecepie;
        public Recepie SelectedRecepie
        {
            get { return _selectedRecepie; }
            set { SetProperty(ref _selectedRecepie, value); ChangeRecepie(); }
        }
        private int _selectedMeal;
        public int SelectedMeal
        {
            get { return _selectedMeal; }
            set { SetProperty(ref _selectedMeal, value);}
        }
        private List<Recepie> _recepieList;
        public List<Recepie> RecepieList
        {
            get { return _recepieList; }
            set { SetProperty(ref _recepieList, value); }
        }
        private int _selectedDay;
        public int SelectedDay
        {
            get { return _selectedDay; }
            set { SetProperty(ref _selectedDay, value); }
        }

        public Recepie[][] PlanForWeek;

        public void ChangeRecepie()
        {
            PlanForWeek[SelectedDay][SelectedMeal] = SelectedRecepie;
        }

    }
}
