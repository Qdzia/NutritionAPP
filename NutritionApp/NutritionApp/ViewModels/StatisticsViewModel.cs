using NutritionApp.Base;
using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionApp.Data;

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
            Days = new List<string>() { "Monday ", "Tuesday " , "Wednesday ", "Thursday ", "Friday ", "Saturday ", "Sunday "};
            LabelsOfWeek = new List<NutritionLabel>();

            LabelsOfWeek.Add(new NutritionLabel(1,2,3,4,5,6));
            LabelsOfWeek.Add(new NutritionLabel(6,5,4,3,2,1));

            TotalAmount = new NutritionLabel(6, 5, 4, 3, 2, 1);
            UpdateLabelsOfWeek();
            
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

        void UpdateLabelsOfWeek()
        {
            //Clear Labels 
            LabelsOfWeek.Clear();

            Recepie[][] planOfWeek = RecepieBase.Instance.PlanForWeek;

            for (int i = 0; i < planOfWeek.Length; i++)
            {
                List<NutritionLabel> labels = new List<NutritionLabel>();
                for (int j = 0; j < planOfWeek[0].Length; j++)
                {
                    labels.Add(planOfWeek[i][j].label);
                }
                NutritionLabel n1 = new NutritionLabel();
                n1.UpdateNurtions(labels);
                LabelsOfWeek.Add(n1);
            }
            NutritionLabel n2 = new NutritionLabel();
            n2.UpdateNurtions(LabelsOfWeek);
            TotalAmount = n2;
        }
    }
}
