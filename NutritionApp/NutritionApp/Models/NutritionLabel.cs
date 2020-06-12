using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    public class NutritionLabel
    {
        public int calories;
        public int fat;
        public int carbs;
        public int fiber;
        public int sugar;
        public int protein;

        public NutritionLabel(int calories, int fat, int carbs, int fiber, int sugar, int protein)
        {
            this.calories = calories;
            this.fat = fat;
            this.carbs = carbs;
            this.fiber = fiber;
            this.sugar = sugar;
            this.protein = protein;

        }

        public override string ToString()
        {
            return $"Calories {calories}kcal Fat {fat}g Carbs {carbs}g Fiber {fiber}g Sugar {sugar}g Protein {protein}g";
        }
    }
}
