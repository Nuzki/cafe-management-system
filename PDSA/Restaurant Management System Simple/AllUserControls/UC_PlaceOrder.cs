using DGVPrinterHelper;
using Restaurant_Management_System_Simple.AllUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;


namespace Restaurant_Management_System_Simple
{
    public partial class UC_PlaceOrder : UserControl
    {
        LinkedList<Item> itemsList = new LinkedList<Item>();
        LinkedList<cartItem> cartItems = new LinkedList<cartItem>();
        DatabaseConnection dbConnection = new DatabaseConnection();
        string connectionString = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=restro;Integrated Security=True;Encrypt=True";

        decimal total = 0;
        public UC_PlaceOrder()
        {
            InitializeComponent();
            LoadItemsFromDatabase();
            
        }
        
    

    private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboCatergory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                string category = comboCatergory.Text;
                var filteredItems = itemsList.ToList().Where(i => i.Category == category).ToList();

                foreach (var item in filteredItems)
                {
                    listBox1.Items.Add(item.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string category = comboCatergory.Text;
                string searchQuery = txtSearch.Text.ToLower();
                var filteredItems = itemsList.ToList().Where(i => i.Category == category && i.Name.ToLower().Contains(searchQuery)).ToList();

                listBox1.Items.Clear();
                foreach (var item in filteredItems)
                {
                    listBox1.Items.Add(item.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtQuantityUpDown.ResetText();
                txtTotal.Clear();

                string selectedItemName = listBox1.GetItemText(listBox1.SelectedItem);
                txtItemName.Text = selectedItemName;

                var selectedItem = itemsList.ToList().FirstOrDefault(i => i.Name == selectedItemName);
                if (selectedItem != null)
                {
                    txtPrice.Text = selectedItem.Price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting an item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtPrice.Text, out decimal price) && int.TryParse(txtQuantityUpDown.Value.ToString(), out int quantity))
                {
                    txtTotal.Text = (price * quantity).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        protected int n;
        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()); 
                
            }
            catch { }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    string itemName = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
                    var itemToRemove = cartItems.ToList().FirstOrDefault(c => c.Name == itemName);

                    if (itemToRemove != null)
                    {
                        total -= itemToRemove.Total;
                        cartItems.Remove(itemToRemove);
                        dataGridView1.Rows.RemoveAt(selectedIndex);
                        labelTotalAmount.Text = "Rs. " + total;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Data: (0)", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount :"+labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            total = 0;
            dataGridView1.Rows.Clear();
            labelTotalAmount.Text = "Rs." + total;
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTotal.Text) && decimal.Parse(txtTotal.Text) > 0)
                {
                    cartItem cartItem = new cartItem(txtItemName.Text, decimal.Parse(txtPrice.Text), (int)txtQuantityUpDown.Value);
                    cartItems.AddLast(cartItem);

                    dataGridView1.Rows.Add(cartItem.Name, cartItem.Price, cartItem.Quantity, cartItem.Total);
                    total += cartItem.Total;
                    labelTotalAmount.Text = "Rs. " + total;
                }
                else
                {
                    MessageBox.Show("Minimum Quantity needs to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item to the cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItemsFromDatabase()
        {
            itemsList = new LinkedList<Item>(); // Clear existing list

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT iid, name, catergory, price FROM items";

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

                // Update UI controls after loading data
                UpdateCategoryComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCategoryComboBox()
        {
            comboCatergory.Items.Clear();

            var categories = itemsList.ToList()
                .Select(i => i.Category)
                .Distinct()
                .ToList();

            comboCatergory.Items.AddRange(categories.ToArray());
        }
    }

    }


