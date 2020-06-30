using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    public class Ingredient
    {
        public double count;
        public string name;
        public Unit unit;

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
            this.count = count;
            this.name = name;
            this.unit = unit;
        }

        public override string ToString()
        {
            if (count == 0) return $"{name}";
            if (unit==Unit.none) return $"{count} {name}";
            else return $"{count} {unit.ToString()} {name}";
        }

        public void SumIngredient(Ingredient ing)
        {
            if (name == ing.name && unit == ing.unit)
            {
                count += ing.count;
            }
        }
    }
}
