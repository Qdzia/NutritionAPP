using NutritionApp.Models;
using System.Collections.ObjectModel;
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
        //Klasa która głownie umożliwia dostęp innym klasą do jednej instanci PlanForWeek dzieki zastosoawaniu wzorca Singleton
        //Zawiera ona odczyt i zapis z pliku w formacie JSON 

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
        public ObservableCollection<Recepie> Recepies { get; set; }
        public RecepieBase()
        {
            PlanForWeek = new Recepie[7][];
            for (int i = 0; i < PlanForWeek.Length; i++)
            {
                PlanForWeek[i] = new Recepie[3];
            }
            Recepies = new ObservableCollection<Recepie>();


            LoadRecepiesFromFile();
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
            File.WriteAllText("../../"+fileName, rawJson);
        }        
        public void LoadRecepiesFromFile()
        {
            string filename = "RecipesBase.json";

            if (!File.Exists("../../" + filename))
                File.WriteAllText("../../" + filename, String.Empty);

            string text = File.ReadAllText("../../" + filename);          
            Recepies = JsonConvert.DeserializeObject<ObservableCollection<Recepie>>(text);
            //if(Recepies.Count < 2)
            //{
            //    //Add default recepies
            //}
            
        }
    }
}
