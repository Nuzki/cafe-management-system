using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;



namespace Restaurant_Management_System_Simple.AllUserControls
{
    public partial class UC_UpdateItems : UserControl
    {
        LinkedList<Item> itemsList = new LinkedList<Item>();
        string connectionString = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=restro;Integrated Security=True;Encrypt=True";
        DatabaseConnection dbConnection = new DatabaseConnection();
        DataSet ds = new DataSet();
        int id;

        public UC_UpdateItems()
        {
            InitializeComponent();
            itemsList = new LinkedList<Item>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_UpdateItems_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            try
            {
                itemsList = new LinkedList<Item>(); // Clear the existing list

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT iid, name, catergory, price FROM items"; // Fixed typo in 'category'

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int Id = Convert.ToInt32(row["iid"]);
                            string Name = row["name"].ToString();
                            string Category = row["catergory"].ToString();
                            decimal Price = Convert.ToDecimal(row["price"]);

                            Item item = new Item(Id, Name, Category, Price);
                            itemsList.AddLast(item);
                        }
                    }
                }

                // Bind data to DataGridView
                var items = itemsList.ToList()
                    .Select(i => new { i.Id, i.Name, i.Category, i.Price })
                    .ToList();

                dataGridView1.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearchItem.Text.ToLower();

            var filteredItems = itemsList.ToList()
                .Where(item => item.Name.ToLower().Contains(searchQuery))
                .Select(item => new
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Price = item.Price
                })
                .ToList();

            if (filteredItems.Count > 0)
            {
                dataGridView1.DataSource = filteredItems;
            }
            else
            {
                MessageBox.Show("No items found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UC_UpdateItems_Load(this, null); // Reload the data to show all items if nothing matches the search
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                var idValue = selectedRow.Cells["iid"].Value;
                var nameValue = selectedRow.Cells["name"].Value;
                var categoryValue = selectedRow.Cells["catergory"].Value;
                var priceValue = selectedRow.Cells["price"].Value;

                try
                {

                    id = Convert.ToInt32(idValue);
                    string name = nameValue.ToString();
                    string category = categoryValue.ToString();
                    decimal price = Convert.ToDecimal(priceValue);


                    txtName.Text = name;
                    txtCatergory.Text = category;
                    txtPrice.Text = price.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
                //if (ds.Tables[0].Rows.Count != 0)
                //{
                // txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                //txtCatergory.Text = ds.Tables[0].Rows[0]["catergory"].ToString();
                //txtPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
                //}
            }
            else
            {
                MessageBox.Show("data is not found","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                UC_UpdateItems_Load(this, null);
            }
        }


            private void btnUpdate_Click(object sender, EventArgs e)
            {
                var itemToUpdate = itemsList.ToList().FirstOrDefault(i => i.Id == id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = txtName.Text;
                    itemToUpdate.Category = txtCatergory.Text;


                    if (decimal.TryParse(txtPrice.Text, out decimal price))
                    {
                        itemToUpdate.Price = price;
                        UpdateItemInDatabase(itemToUpdate);
                        loadData();

                        // Clear input fields
                        txtName.Clear();
                        txtCatergory.Clear();
                        txtPrice.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Invalid price entered. Please enter a valid number.");
                        txtPrice.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Item not found. Please select an item from the list.");
                }
            }
            private void UpdateItemInDatabase(Item item)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE items SET name = @name, catergory = @catergory, price = @price WHERE iid = @iid";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", item.Name);
                        command.Parameters.AddWithValue("@catergory", item.Category);
                        command.Parameters.AddWithValue("@price", item.Price);
                        command.Parameters.AddWithValue("@iid", item.Id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }


            private void btnUpdate_Click_1(object sender, EventArgs e)
            {
                btnUpdate_Click(sender, e);
            }
        }
    }


