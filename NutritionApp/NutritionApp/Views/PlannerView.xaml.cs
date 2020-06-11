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

namespace NutritionApp.Views
{
    /// <summary>
    /// Interaction logic for PlannerView.xaml
    /// </summary>
    public partial class PlannerView : UserControl
    {
        public PlannerView()
        {
            InitializeComponent();
        }

        public List<Recepie> RecepieList
        {
            get { return (List<Recepie>)GetValue(RecepieListProperty); }
            set { SetValue(RecepieListProperty, value); }
        }

        public static readonly DependencyProperty RecepieListProperty =
            DependencyProperty.Register("RecepieList", typeof(List<Recepie>), typeof(PlannerView), new PropertyMetadata(null));

        public int SelectedDay
        {
            get { return (int)GetValue(SelectedDayProperty); }
            set { SetValue(SelectedDayProperty, value); }
        }

        public static readonly DependencyProperty SelectedDayProperty =
            DependencyProperty.Register("SelectedDay", typeof(int), typeof(PlannerView), new PropertyMetadata(null));

        public int SelectedMeal
        {
            get { return (int)GetValue(SelectedMealProperty); }
            set { SetValue(SelectedMealProperty, value); }
        }

        public static readonly DependencyProperty SelectedMealProperty =
            DependencyProperty.Register("SelectedMeal", typeof(Recepie), typeof(PlannerView), new PropertyMetadata(null));

        public Recepie SelectedRecepie
        {
            get { return (Recepie)GetValue(SelectedRecepieProperty); }
            set { SetValue(SelectedRecepieProperty, value); }
        }

        public static readonly DependencyProperty SelectedRecepieProperty =
            DependencyProperty.Register("SelectedRecepie", typeof(Recepie), typeof(PlannerView), new PropertyMetadata(null));

        private void Monday(object sender, RoutedEventArgs e) => SelectedDay = 0;
        private void Tuesday(object sender, RoutedEventArgs e) => SelectedDay = 1;
        private void Wednesday(object sender, RoutedEventArgs e) => SelectedDay = 2;
        private void Thursday(object sender, RoutedEventArgs e) => SelectedDay = 3;
        private void Friday(object sender, RoutedEventArgs e) => SelectedDay = 4;
        private void Saturday(object sender, RoutedEventArgs e) => SelectedDay = 5;
        private void Sunday(object sender, RoutedEventArgs e) => SelectedDay = 6;

        private void Breakfast(object sender, RoutedEventArgs e) => SelectedMeal = 0;
        private void Dinner(object sender, RoutedEventArgs e) => SelectedMeal = 1;
        private void Supper(object sender, RoutedEventArgs e) => SelectedMeal = 2;
    }
}
