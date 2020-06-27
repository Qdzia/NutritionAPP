using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    public class Recepie
    {
        public string recepieName;
        public string instruction;
        public List<Ingredient> ingredients;
        public NutritionLabel label;

        public Recepie(string recepieName,string instruction, List<Ingredient> ingredients, NutritionLabel label)
        {
            this.recepieName = recepieName;
            this.instruction = instruction;
            this.ingredients = ingredients;
            this.label = label;
        }

        public override string ToString()
        {
            return recepieName;
        }

    }
}
