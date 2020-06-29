﻿using System;
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

        public NutritionLabel()
        {

        }

        public NutritionLabel(int calories, int fat, int carbs, int fiber, int sugar, int protein)
        {
            this.calories = calories;
            this.fat = fat;
            this.carbs = carbs;
            this.fiber = fiber;
            this.sugar = sugar;
            this.protein = protein;

        }

        public void UpdateNurtions(List<NutritionLabel> nutritionLabels)
        {
            foreach (var nut in nutritionLabels)
            {
                this.calories += nut.calories;
                this.fat += nut.fat;
                this.carbs += nut.carbs;
                this.fiber += nut.fiber;
                this.sugar += nut.sugar;
                this.protein += nut.protein;
            }
        }

        public override string ToString()
        {
            return $"Calories {calories}kcal Fat {fat}g Carbs {carbs}g Fiber {fiber}g Sugar {sugar}g Protein {protein}g";
        }

        public string StatisticView()
        { 
            return $"{calories,5}kcal  {fat,5}g {carbs,5}g {fiber,5}g {sugar,5}g {protein,5}g ";

        }
    }
}
