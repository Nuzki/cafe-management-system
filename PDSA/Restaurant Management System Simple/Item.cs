using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System_Simple
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }


        // Constructor for creating an item with an ID
        public Item(int id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }
        public Item(string name, string category, decimal price)
        {
            Id = GenerateUniqueId();  // Automatically generate the ID
            Name = name;
            Category = category;
            Price = price;
        }

        private int GenerateUniqueId()
        {
            // Your logic to generate a unique ID
            return new Random().Next(1, 1000); // Example: random ID generation
        }
    }

}
