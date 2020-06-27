using NutritionApp.Base;
using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.ViewModels
{
    class StatisticsViewModel: BaseVM
    {
        public List<string> DailyIncome { get; set; }

        List<string> Days;
        List<NutritionLabel> LabelsOfWeek;
        public NutritionLabel TotalAmount { get; set; }

        public StatisticsViewModel()
        {
            Days = new List<string>() { "Monday ", "Tuesday " };
            LabelsOfWeek = new List<NutritionLabel>();

            LabelsOfWeek.Add(new NutritionLabel(1,2,3,4,5,6));
            LabelsOfWeek.Add(new NutritionLabel(6,5,4,3,2,1));

            TotalAmount = new NutritionLabel(6, 5, 4, 3, 2, 1);
            UpdateView();
        }

        void UpdateView()
        {
            DailyIncome = new List<string>();
            for (int i = 0; i < Days.Count; i++)
            {
                DailyIncome.Add(Days[i] + LabelsOfWeek[i].ToString());
            }
        }
    }
}
