using NutritionApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionApp.Models;
using NutritionApp.Data;

namespace NutritionApp.ViewModels
{
    class StatisticsViewModel: BaseVM
    {
        public string Test { get { return "test Binding"; } }

        //public NutritionLabel Monday { get; set; }
        //public NutritionLabel Tuesday { get; set; }
        //public NutritionLabel Wednesfay { get; set; }
        //public NutritionLabel Thursday { get; set; }
        //public NutritionLabel Friday { get; set; }
        //public NutritionLabel Saturday { get; set; }
        //public NutritionLabel Sunday { get; set; }

        public List<NutritionLabel> Days { get; set; }
        
        public void UpdateNurtion()
        {
            for (int i = 0; i < RecepieBase.Instance.PlanForWeek.Length; i++)
            {                
                for (int j = 0; j < RecepieBase.Instance.PlanForWeek[0].Length; j++)
                {
                    
                }
            }
        }
    }
}
