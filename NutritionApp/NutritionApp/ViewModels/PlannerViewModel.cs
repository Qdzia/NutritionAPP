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
        public PlannerViewModel()
        {
            _selectedRecepie = new Recepie("Kurczak w sosie", "Wlej Wode i gotowe", new List<string> { "Jajko", "Marchew", "Barszcz" }, new NutritionLabel(1, 2, 3, 4, 5, 6));
        }
        private Recepie _selectedRecepie;
        public Recepie SelectedRecepie
        {
            get { return _selectedRecepie; }
            set { SetProperty(ref _selectedRecepie, value); }
        }
    }
}
