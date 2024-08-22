using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System_Simple
{
    public class cartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        // Constructor
        public cartItem(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Total = price * quantity;
        }
    }
}
