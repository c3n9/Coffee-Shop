using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CoffeeShop.Model
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Image { get; set; }
        public Coffee(string name, double cost, string image)
        {
            Name = name;
            Cost = cost;
            Image = image;
        }
    }
}
