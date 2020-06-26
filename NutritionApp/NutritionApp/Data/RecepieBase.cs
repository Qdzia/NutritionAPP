using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace NutritionApp.Data
{
    public sealed class RecepieBase
    {
        #region Singleton
        private static readonly object padlock = new object();
        private static RecepieBase _instance = null;
        public static RecepieBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RecepieBase();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        public Recepie[][] PlanForWeek { get; set; }
        public List<Recepie> Recepies { get; set; }

        public RecepieBase()
        {
            PlanForWeek = new Recepie[7][];
            for (int i = 0; i < PlanForWeek.Length; i++)
            {
                PlanForWeek[i] = new Recepie[3];
            }
            Recepies = new List<Recepie>();

            Ingredient i1 = new Ingredient("Marchew", 1, Ingredient.Unit.g);
            Ingredient i2 = new Ingredient("Banan", 1, Ingredient.Unit.g);
            Ingredient i3 = new Ingredient("Gruszka", 1, Ingredient.Unit.g);
            Ingredient i4 = new Ingredient("Jagoda", 1, Ingredient.Unit.g);

            List<Ingredient> l1 = new List<Ingredient>() { i1, i2 };
            List<Ingredient> l2 = new List<Ingredient>() { i3, i4 };
            List<Ingredient> l3 = new List<Ingredient>() { i2, i3 };

            Recepies.Add(new Recepie("Kurczak w sosie", "Wlej Wode i gotowe", l1, new NutritionLabel(1, 2, 3, 4, 5, 6)));
            Recepies.Add(new Recepie("Marynowane Jajka", "Staranie stłuc i wlać", l2, new NutritionLabel(500, 2, 2, 234, 34, 6)));
            Recepies.Add(new Recepie("Majonezowa zapiekanka", "Polej kepuczem", l3, new NutritionLabel(2220, 21, 33, 44, 85, 61)));
        }
        
        public void SaveRecepiesToFile()
        {
            string fileName = "RecipesBase.json";
            List<Recepie> recepiesToSave = new List<Recepie>();

            foreach (var r in Recepies)
            {
                recepiesToSave.Add(r); 
            }

            string rawJson = JsonConvert.SerializeObject(recepiesToSave);
            File.WriteAllText(fileName, rawJson);
        }
        
        public void LoadRecepiesFromFile()
        {
            string filename = "RecipesBase.json";

            if (!File.Exists(filename))
                return;

            Recepies = JsonConvert.DeserializeObject<List<Recepie>>(File.ReadAllText(filename));
            
        }
    }
}
