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
                new Coffee("Капучино", 80, "/Resources/Cappuccino.png"),
                new Coffee("Латте", 110, "/Resources/Latte.png"),
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
            TBCost.Text = Convert.ToString(selectedCoffee.Cost);
            ISelectedCoffee.Source = new BitmapImage(new Uri(selectedCoffee.Image, UriKind.RelativeOrAbsolute));
        }
    }
}
