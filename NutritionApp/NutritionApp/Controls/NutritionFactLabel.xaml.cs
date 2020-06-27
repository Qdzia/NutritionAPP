using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NutritionApp.Controls
{
    /// <summary>
    /// Interaction logic for NutritionFactLabel.xaml
    /// </summary>
    public partial class NutritionFactLabel : UserControl
    {
        public NutritionFactLabel()
        {
            InitializeComponent();
            FactsLabel = new NutritionLabel(0, 0, 0, 0, 0, 0);
        }

        void UpdateCounters()
        {
            Calories.Number = FactsLabel.calories;
            Fat.Number = FactsLabel.fat;
            Sugar.Number = FactsLabel.sugar;
            Carbs.Number = FactsLabel.carbs;
            Fiber.Number = FactsLabel.fiber;
            Protein.Number = FactsLabel.protein;
        }
        public NutritionLabel FactsLabel
        {
            get { return (NutritionLabel)GetValue(FactsLabelProperty); }
            set { SetValue(FactsLabelProperty, value); UpdateCounters(); }
        }

        public static readonly DependencyProperty FactsLabelProperty =
            DependencyProperty.Register("FactsLabel", typeof(NutritionLabel), typeof(NutritionFactLabel), new PropertyMetadata(null));

    }
}
