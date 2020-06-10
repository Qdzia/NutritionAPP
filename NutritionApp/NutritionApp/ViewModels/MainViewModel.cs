﻿using NutritionApp.Base;
using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.ViewModels
{
    class MainViewModel : BaseVM
    {
        public MainViewModel()
        {
            Planner = new PlannerViewModel();
        }
        public PlannerViewModel Planner { get; set; }

        private string _test = "Binding Test";
        public string BindingTest
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
        }

    }
}
