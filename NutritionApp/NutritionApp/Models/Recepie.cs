using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Models
{
    public class Recepie
    {
        public string RecepieName { get; set; }
        public string Instruction { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public NutritionLabel Label { get; set; }

        public Recepie(string recepieName,string instruction, ObservableCollection<Ingredient> ingredients, NutritionLabel label)
        {
            this.RecepieName = recepieName;
            this.Instruction = instruction;
            this.Ingredients = ingredients;
            this.Label = label;
        }

        public override string ToString()
        {
            return RecepieName;
        }

    }
}
