using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    public class Ingredient
    {
        public double Count { get; set; }
        public string Name { get; set; }
        public Unit Units { get; set; }

        public enum Unit
        {
            g,
            dag,
            kg,
            ml,
            tbsp,
            tsp,
            none
        }

        public Ingredient(string name, double count, Unit unit)
        {
            this.Count = count;
            this.Name = name;
            this.Units = unit;
        }

        public override string ToString()
        {
            if (Count == 0) return $"{Name}";
            if (Units==Unit.none) return $"{Count} {Name}";
            else return $"{Count} {Units.ToString()} {Name}";
        }

        public void SumIngredient(Ingredient ing)
        {
            if (Name == ing.Name && Units == ing.Units)
            {
                Count += ing.Count;
            }
        }
    }
}
