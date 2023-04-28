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
        Coffee contextCoffee;
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
            contextCoffee = (sender as Button).DataContext as Coffee;
            if (contextCoffee == null)
            {
                return;
            }
            TBName.Text = contextCoffee.Name;
            TBCost.Text = Convert.ToString(contextCoffee.Cost);
            ISelectedCoffee.Source = new BitmapImage(new Uri(contextCoffee.Image, UriKind.RelativeOrAbsolute));
            FullCost.Text = Convert.ToString(contextCoffee.Cost);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (contextCoffee == null)
            {
                MessageBox.Show("Select coffee");
                return;
            }
            if (TBCount.Text == "0")
            {
                return;
            }
            TBCount.Text = Convert.ToString(int.Parse(TBCount.Text) - 1);
            FullCost.Text = Convert.ToString(double.Parse(FullCost.Text) - 0.1);
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (contextCoffee == null)
            {
                MessageBox.Show("Select coffee");
                return;
            }
            TBCount.Text = Convert.ToString(int.Parse(TBCount.Text) + 1);
            FullCost.Text = Convert.ToString(double.Parse(FullCost.Text) + 0.1);
        }

        private void Minus1cent_Click(object sender, RoutedEventArgs e)
        {
            if (TBCount1cent.Text != "0" && !(double.Parse(TBYourMoney.Text) < 0.1))
            {
                TBCount1cent.Text = Convert.ToString(double.Parse(TBCount1cent.Text) - 1);
                TBYourMoney.Text = Convert.ToString(double.Parse(TBYourMoney.Text) - 0.1);
            }
            else
            {
                return;
            }
        }

        private void Plus1Cent_Click(object sender, RoutedEventArgs e)
        {
            TBCount1cent.Text = Convert.ToString(double.Parse(TBCount1cent.Text) + 1);
            TBYourMoney.Text = Convert.ToString(double.Parse(TBYourMoney.Text) + 0.1);
        }

        private void Minus5cent_Click(object sender, RoutedEventArgs e)
        {
            if (TBCount5cent.Text != "0" && !(double.Parse(TBYourMoney.Text) < 0.5))
            {
                TBCount5cent.Text = Convert.ToString(double.Parse(TBCount5cent.Text) - 1);
                TBYourMoney.Text = Convert.ToString(double.Parse(TBYourMoney.Text) - 0.5);
            }
            else
            {
                return;
            }
        }

        private void Plus5Cent_Click(object sender, RoutedEventArgs e)
        {
            TBCount5cent.Text = Convert.ToString(double.Parse(TBCount5cent.Text) + 1);
            TBYourMoney.Text = Convert.ToString(double.Parse(TBYourMoney.Text) + 0.5);
        }

        private void Minus25cent_Click(object sender, RoutedEventArgs e)
        {
            if (TBCount25cent.Text != "0" && !(double.Parse(TBYourMoney.Text) < 0.25))
            {
                TBCount25cent.Text = Convert.ToString(double.Parse(TBCount25cent.Text) - 1);
                TBYourMoney.Text = Convert.ToString(double.Parse(TBYourMoney.Text) - 0.25);
            }
            else
            {
                return;
            }
           
        }

        private void Plus25Cent_Click(object sender, RoutedEventArgs e)
        {
            TBCount25cent.Text = Convert.ToString(double.Parse(TBCount25cent.Text) + 1);
            TBYourMoney.Text = Convert.ToString(double.Parse(TBYourMoney.Text) + 0.25);
        }

        private void BBuyCoffee_Click(object sender, RoutedEventArgs e)
        {
            if (contextCoffee == null)
            {
                MessageBox.Show("Select coffee");
                return;
            }
            if (double.Parse(TBYourMoney.Text) < double.Parse(FullCost.Text))
            {
                MessageBox.Show("Not enough means");
                return;
            }
            else if (double.Parse(TBYourMoney.Text) == double.Parse(FullCost.Text))
            {
                MessageBox.Show("Enjoy your coffee");
            }
            else if (double.Parse(TBYourMoney.Text) > double.Parse(FullCost.Text))
            {
                MessageBox.Show($"Enjoy your coffee, your change ${double.Parse(TBYourMoney.Text)- double.Parse(FullCost.Text)}");
            }
            TBYourMoney.Text = "0";
            FullCost.Text = "0";
            TBCount1cent.Text = "0";
            TBCount5cent.Text = "0";
            TBCount25cent.Text = "0";
            TBCount.Text = "0";
            ISelectedCoffee.Source = ISelectedCoffee.Source = new BitmapImage(new Uri("/Resources/CoffeeBeans.png", UriKind.RelativeOrAbsolute));
            TBName.Text = "Select coffee";
            TBCost.Text = "";
        }
    }
}
