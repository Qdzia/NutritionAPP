using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    class Ingredient
    {
        public int count;
        public string name;
        public Unit unit;

        public enum Unit
        {
            g,
            dag,
            kg
        }

        public Ingredient(string name, int count, Unit unit)
        {
            this.count = count;
            this.name = name;
            this.unit = unit;
        }

        public override string ToString()
        {
            return $"{count} {unit.ToString()} {name}";
        }

        public void AddIngredient(Ingredient ing)
        {
            if (name == ing.name && unit == ing.unit)
            {
                count += ing.count;
            }
        }
    }
}
