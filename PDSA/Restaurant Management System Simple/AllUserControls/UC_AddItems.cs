using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System_Simple.AllUserControls
{
  
    public partial class UC_AddItems : UserControl
    {
        LinkedList<Item> itemsList = new LinkedList<Item>();
        string connectionString = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=restro;Integrated Security=True;Encrypt=True"; // Update with your actual connection string
        DatabaseConnection dbConnection = new DatabaseConnection();

        public UC_AddItems()
        {
            InitializeComponent();
            itemsList = new LinkedList<Item>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                Item newItem = new Item(txtItemName.Text, txtCatergory.Text, price);
                itemsList.AddLast(newItem);

                SaveItemToDatabase(newItem); // Save to database

                MessageBox.Show("Item added successfully!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clearAll();
            }
            else
            {
                MessageBox.Show("Invalid price entered. Please enter a valid number.");
                txtPrice.Focus();
            }

        }
        private void SaveItemToDatabase(Item item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO items (name, catergory, price) VALUES (@name, @catergory, @price)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", item.Name);
                    command.Parameters.AddWithValue("@catergory", item.Category);
                    command.Parameters.AddWithValue("@price", item.Price);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void clearAll()
        {
            txtCatergory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }

        private void UC_AddItems_Leave(object sender, EventArgs e)
        {
         clearAll();
        }
    }
}
