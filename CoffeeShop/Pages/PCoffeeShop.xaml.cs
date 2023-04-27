using CoffeeShop.Model;
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

namespace CoffeeShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PCoffeeShop.xaml
    /// </summary>
    public partial class PCoffeeShop : Page
    {
        public PCoffeeShop()
        {
            InitializeComponent();
            List<Coffee> contextCoffee = new List<Coffee>()
            {
                new Coffee("Cappuccino", 0.80, "/Resources/Cappuccino.png"),
                new Coffee("Latte", 0.61, "/Resources/Latte.png"),
                new Coffee("Americano", 0.25, "/Resources/Americano.png"),
                new Coffee("Expresso", 0.46, "/Resources/Espresso.png"),
                new Coffee("Glace", 0.54, "/Resources/Glace.png"),
                new Coffee("Mocha", 0.32, "/Resources/Mocha.png"),
            };
           
            ListServices.ItemsSource = contextCoffee.ToList();
        }

        private void BBuy_Click(object sender, RoutedEventArgs e)
        {
            var selectedCoffee = (sender as Button).DataContext as Coffee;
            if (selectedCoffee == null)
            {
                return;
            }
            TBName.Text = selectedCoffee.Name;
            TBCost.Text = "$"+Convert.ToString(selectedCoffee.Cost);
            ISelectedCoffee.Source = new BitmapImage(new Uri(selectedCoffee.Image, UriKind.RelativeOrAbsolute));
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if(TBCount.Text == "0")
            {
                return;
            }
            TBCount.Text = Convert.ToString(int.Parse(TBCount.Text) - 1);
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            TBCount.Text = Convert.ToString(int.Parse(TBCount.Text) + 1);
        }
    }
}
