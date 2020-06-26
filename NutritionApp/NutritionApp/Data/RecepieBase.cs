using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

    }
}
