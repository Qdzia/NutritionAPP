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
    //Klasa sumuje wszystkie Nutrition Label z PlanForWeek w ujęciu ogólnym na cały tydzień 
    //i na każdy dzień z osobna wyświetlając je w formie tekstowe
    class StatisticsViewModel: BaseVM
    {
        public List<string> DailyIncome { get; set; }

        List<string> Days;
        List<NutritionLabel> LabelsOfWeek;
        public NutritionLabel TotalAmount { get; set; }

        #region NutritionLabel Binding
        public int Calories { get { return TotalAmount.Calories; } set { TotalAmount.Calories = value; } }
        public int Fat { get { return TotalAmount.Fat; } set { TotalAmount.Fat = value; } }
        public int Carbs { get { return TotalAmount.Carbs; } set { TotalAmount.Carbs = value; } }
        public int Fiber { get { return TotalAmount.Fiber; } set { TotalAmount.Fiber = value; } }
        public int Sugar { get { return TotalAmount.Sugar; } set { TotalAmount.Sugar = value; } }
        public int Protein { get { return TotalAmount.Protein; } set { TotalAmount.Protein = value; } }
        #endregion

        public StatisticsViewModel()
        {
            Days = new List<string>() { "Monday   ", "Tuesday  " , "Wednesday", "Thursday ", "Friday   ", "Saturday ", "Sunday   "};
            LabelsOfWeek = new List<NutritionLabel>();
            

            UpdateLabelsOfWeek();     
            UpdateView();
        }

        void UpdateView()
        {
            DailyIncome = new List<string>();
            DailyIncome.Add("| Calories |  Fat  | Carbs | Fiber | Sugar | Protein | Day");
            for (int i = 0; i < Days.Count; i++)
            {
                DailyIncome.Add(String.Format("{1} {0}", Days[i], LabelsOfWeek[i].StatisticView()));
            }
        }

        void UpdateLabelsOfWeek()
        {
            LabelsOfWeek.Clear();

            Recepie[][] planOfWeek = RecepieBase.Instance.PlanForWeek;

            for (int i = 0; i < planOfWeek.Length; i++)
            {
                List<NutritionLabel> labels = new List<NutritionLabel>();
                for (int j = 0; j < planOfWeek[0].Length; j++)
                {
                    if (planOfWeek[i][j] == null)
                        continue;
                    labels.Add(planOfWeek[i][j].Label);
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
