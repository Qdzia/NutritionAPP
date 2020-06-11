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
    /// Interaction logic for Counter.xaml
    /// </summary>
    public partial class Counter : UserControl
    {
        public Counter()
        {
            InitializeComponent();
        }

        public string CounterName
        {
            get { return (string)GetValue(CounterNameProperty); }
            set { SetValue(CounterNameProperty, value); }
        }

        public static readonly DependencyProperty CounterNameProperty =
            DependencyProperty.Register("CounterName", typeof(string), typeof(Counter), new PropertyMetadata(null));

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(Counter), new PropertyMetadata(null));

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(Counter), new PropertyMetadata(null));
    }
}
