using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    public class NutritionLabel
    {
        public int Calories { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
        public int Fiber { get; set; }
        public int Sugar { get; set; }
        public int Protein { get; set; }

        public NutritionLabel()
        {

        }

        public NutritionLabel(int calories, int fat, int carbs, int fiber, int sugar, int protein)
        {
            this.Calories = calories;
            this.Fat = fat;
            this.Carbs = carbs;
            this.Fiber = fiber;
            this.Sugar = sugar;
            this.Protein = protein;

        }

        public void UpdateNurtions(List<NutritionLabel> nutritionLabels)
        {
            foreach (var nut in nutritionLabels)
            {
                this.Calories += nut.Calories;
                this.Fat += nut.Fat;
                this.Carbs += nut.Carbs;
                this.Fiber += nut.Fiber;
                this.Sugar += nut.Sugar;
                this.Protein += nut.Protein;
            }
        }

        public override string ToString()
        {
            return $"Calories {Calories}kcal Fat {Fat}g Carbs {Carbs}g Fiber {Fiber}g Sugar {Sugar}g Protein {Protein}g";
        }

        public string StatisticView()
        { 
            return $"{Calories,5}kcal  {Fat,5}g {Carbs,5}g {Fiber,5}g {Sugar,5}g {Protein,5}g ";

        }
    }
}
