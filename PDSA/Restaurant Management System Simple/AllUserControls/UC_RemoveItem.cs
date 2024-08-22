using System;
using System.Collections;
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
    public partial class UC_RemoveItem : UserControl
    {
        LinkedList<Item> itemsList;
        string connectionString = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=restro;Integrated Security=True;Encrypt=True";
        DatabaseConnection dbConnection = new DatabaseConnection();
        public UC_RemoveItem()
        {
            InitializeComponent();
            itemsList = new LinkedList<Item>();

        }

        private void UC_RemoveItem_Load(object sender, EventArgs e)
        {
            Dellabel.Text = "How to DELETE?";
            Dellabel.ForeColor = Color.Blue;
            loadData();
        }
        public void loadData()
        {


            itemsList = new LinkedList<Item>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT iid, name, catergory, price FROM items"; // Update column names as per your schema

                using (SqlCommand command = new SqlCommand(query, connection))
                {

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

            BindDataToGrid();
        }
        private void BindDataToGrid()
        {
            try
            {
                if (itemsList.Count() > 0)
                {
                    var itemsData = new List<object>(); // Use List<object> for DataGridView binding

                    var current = itemsList.Head;

                    while (current != null)
                    {
                        // Ensure that current.Data is not null before accessing its properties
                        var item = current.Data as Item;
                        if (item != null)
                        {
                            itemsData.Add(new
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Category = item.Category,
                                Price = item.Price
                            });
                        }
                        current = current.Next;
                    }

                    // Bind the data to the DataGridView
                    dataGridView1.DataSource = itemsData;
                }
                else
                {
                    MessageBox.Show("No items to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(NullReferenceException ex) 
            
            {
                MessageBox.Show("Error" + ex);
            }

        }


        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (itemsList != null && itemsList.Count() > 0)
            {
                string searchQuery = guna2TextBox1.Text.ToLower();
                var filteredItems = new ArrayList();
                var current = itemsList.Head;

                while (current != null)
                {
                    var item = (Item)current.Data;
                    if (item.Name.ToLower().Contains(searchQuery))
                    {
                        filteredItems.Add(new
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Category = item.Category,
                            Price = item.Price
                        });
                    }
                    current = current.Next;
                }

                dataGridView1.DataSource = filteredItems;
            }
            else
            {
                MessageBox.Show("No items found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UC_RemoveItem_Load(this, null);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (MessageBox.Show("Delete item?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    var nodeToRemove = itemsList.Find(i => ((Item)i).Id == id);
                    if (nodeToRemove != null)
                    {
                        RemoveItemFromDatabase(id);  // Remove the item from the database
                        itemsList.Remove(nodeToRemove.Data);  // Remove the item from the LinkedList
                        loadData();  // Refresh the data grid
                    }
                }
            }
        }
        private void RemoveItemFromDatabase(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM items WHERE iid = @id"; // Ensure the column name 'Id' matches your database schema

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private void Dellabel_Click(object sender, EventArgs e)
        {
            Dellabel.ForeColor = Color.Red;
            Dellabel.Text = "Click on Rows to Delete the Items";
        }

        private void UC_RemoveItem_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_RemoveItem_Load(this, null);
        }
    }
}
