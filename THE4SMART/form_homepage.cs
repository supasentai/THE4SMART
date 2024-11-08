using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing.Printing;

namespace THE4SMART
{
    public partial class form_homepage : Form
    {
        private list_product ProductList;
        private list_Staff StaffList;
        static float totalPrice;
        public form_homepage()
        {
            InitializeComponent();
            ProductList = new list_product();
            StaffList = new list_Staff();

        }
        private void form_homepage_Load(object sender, EventArgs e)
        {
            string json_product = File.ReadAllText(@"productList.json");    //đọc DL sản phẩm
            ProductWrapper productWrapper = JsonConvert.DeserializeObject<ProductWrapper>(json_product);
            
            if (productWrapper == null || productWrapper.Products == null || productWrapper.Products.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm trống hoặc không thể đọc dữ liệu từ file JSON.");
                return;
            }
            dataGridView1.DataSource = ProductList.dataTableProduct(productWrapper.Products);

            updateCategory(@"productList.json");

            string json_staff = File.ReadAllText(@"staffList.json");    //đọc DL nhân viên
            StaffWrapper staffWrapper = JsonConvert.DeserializeObject<StaffWrapper>(json_staff);
            StaffList = new list_Staff();
            StaffList.Staffs = staffWrapper.Staffs;

            if (StaffList.Staffs != null)
            {
                dataGridViewStaff.DataSource = StaffList.dataTableStaff(StaffList.Staffs);
            }
            if(list_Manager.permission) panel_Permision.Visible = false;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tab_HomeButton.Visible = true;
        }
        private void btn_ProductAdd_Click(object sender, EventArgs e)
        {//string productId,string productName, int productQuantity, int productPrice, string productCategory, string productManufacturer
            try
            {
                if (ProductList.CheckProductNotExist(txt_ProductID.Text))
                {
                    Product newProduct = new Product(
                        txt_ProductID.Text,
                        txt_ProductName.Text,
                        int.Parse(txt_ProductQuantity.Text),
                        int.Parse(txt_ProductPrice.Text),
                        txt_ProductCategory.Text,
                        txt_ProductManu.Text);
                    ProductList.AddProductToFile(newProduct);
                }
                else
                {
                    ProductList.Add(txt_ProductID.Text, int.Parse(txt_ProductQuantity.Text));
                }

                RefreshDataGridView();
                MessageBox.Show("Successfully Added!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for Quantity and Price.");
            }
            updateCategory(@"productList.json");
        }
        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            txt_ProductName.Text = "";
            txt_ProductCategory.Text = "";
            txt_ProductManu.Text = "";
            txt_ProductID.Text = "";
            txt_ProductPrice.Text = null;
            txt_ProductQuantity.Text = null;
            txt_ProductName.ReadOnly = false;

            txt_ProductManu.ReadOnly = false;
        }
        private void btn_ProductCheck_Click(object sender, EventArgs e)
        {
            Product foundProduct = ProductList.CheckProduct(txt_ProductID.Text);

            if (foundProduct != null)
            {
                // Truy cập các thuộc tính của sản phẩm tìm thấy
                txt_ProductName.Text = foundProduct.ProductName;
                txt_ProductName.ReadOnly = true;
                txt_ProductManu.Text = foundProduct.ProductManufacturer;
                txt_ProductManu.ReadOnly = true;
                txt_ProductCategory.Text = foundProduct.ProductCategory;
                txt_ProductQuantity.Text = "0";
                txt_ProductPrice.Text = foundProduct.ProductPrice.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm với ID đã nhập.");
            }
        }
        private void btn_StaffAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (StaffList.CheckStaffNotExist(txt_StaffID.Text))
                {
                    Staff newStaff = new Staff(
                        txt_StaffID.Text,
                        txt_StaffPassword.Text,
                        txt_StaffName.Text,
                        txt_StaffPhone.Text,
                        txt_StaffAddress.Text,
                        txt_StaffShift.Text
                );
                    StaffList.AddStaffToFile(newStaff);
                    // Đọc dữ liệu từ file JSON và cập nhật lại DataGridView
                    string filePath = @"staffList.json";
                    StaffList = StaffList.LoadStaffsFromJson(filePath);

                    // Làm mới DataGridView với dữ liệu mới
                    dataGridViewStaff.DataSource = null;
                    dataGridViewStaff.DataSource = StaffList.Staffs.ToList();
                    MessageBox.Show("Successfully Added!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for Quantity and Price.");
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new form_policy().Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new form_aboutus().Show();
        }
        private void updateCategory(string filePath)
        {
            cbb_CartCategory.Items.Clear();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File productList.json không tồn tại.");
                return;
            }
            string jsonData = File.ReadAllText(filePath);
            ProductWrapper productsWrapper = JsonConvert.DeserializeObject<ProductWrapper>(jsonData);

            if (productsWrapper != null && productsWrapper.Products != null)
            {
                List<string> uniqueCategories = productsWrapper.Products
                    .Select(product => product.ProductCategory) // Sửa lại để lấy ProductCategory
                    .Distinct()
                    .ToList();

                cbb_CartCategory.Items.AddRange(uniqueCategories.ToArray());

                if (uniqueCategories.Count > 0)
                {
                    txt_ProductCategory.Text = uniqueCategories[0];
                }
            }
        }
        private void cbb_CartCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_CartName.Items.Clear();
            
            string json_product = File.ReadAllText(@"productList.json");    //đọc DL sản phẩm
            ProductWrapper productWrapper = JsonConvert.DeserializeObject<ProductWrapper>(json_product);
            string selectedCategory = cbb_CartCategory.SelectedItem.ToString();

            if (selectedCategory == null) return;

            List<string> filteredProducts = productWrapper.Products
                .Where(product => product.ProductCategory == selectedCategory)
                .Select(product => product.ProductName)
                .ToList();

            if (filteredProducts.Count > 0)
            {
                cbb_CartName.Items.AddRange(filteredProducts.ToArray());
                cbb_CartName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào trong danh mục đã chọn.");
            }
        }
        private void cbb_CartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbb_CartName.Text))
            {
                MessageBox.Show("Vui lòng chọn một tên sản phẩm.");
                return;
            }

            Product foundProduct = ProductList.CheckProduct(cbb_CartName.Text);

            if (foundProduct != null)
            {
                txt_CartManufacture.Text = foundProduct.ProductManufacturer;
                txt_CartPrice.Text = foundProduct.ProductPrice.ToString();
                txt_CartID.Text = foundProduct.ProductId;
                txt_CartQuantity.Text = foundProduct.ProductQuantity.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm với tên đã chọn.");
            }
        }
        private void RefreshDataGridView()
        {
            string filePath = @"productList.json";
            ProductList = ProductList.LoadProductsFromJson(filePath);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ProductList.dataTableProduct(ProductList.Products);
        }
        private DataTable dataTableCart(List<Product> products)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("N0");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Discount");
            dataTable.Columns.Add("Amount");

            int i = 1;
            foreach (Product product in products)
            {
                dataTable.Rows.Add(i, product.ProductId, product.ProductName, product.ProductPrice, txt_CartAmount.Text, cbb_Discount.Text, product.amountCal(product.ProductPrice, int.Parse(txt_CartAmount.Text), float.Parse(cbb_Discount.Text))); // Adjust properties accordingly
                i++;
            }
            return dataTable;
        }
        private void btn_CartAdd_Click(object sender, EventArgs e)
        {
            // Retrieve product by ID from the list
            Product selectedProduct = ProductList.CheckProduct(txt_CartID.Text); // use the entered Product ID
            int temporary;
            if (int.Parse(txt_CartQuantity.Text) > 0 && int.Parse(txt_CartQuantity.Text) >= int.Parse(txt_CartAmount.Text))
            {
                if (selectedProduct != null)
                {
                    // Parse quantity and discount inputs
                    int quantity;
                    float discount;
                    
                    if (!int.TryParse(txt_CartAmount.Text, out quantity) || quantity <= 0)
                    {
                        MessageBox.Show("Please enter a valid quantity.");
                        return;
                    }
                    if (!float.TryParse(cbb_Discount.Text, out discount))
                    {
                        MessageBox.Show("Please enter a valid discount.");
                        return;
                    }
                    // Calculate amount
                    float amount = selectedProduct.amountCal(selectedProduct.ProductPrice, quantity, discount);

                    // Check if the product is already in the cart
                    DataTable dataTable = (DataTable)dataGridViewCart.DataSource ?? dataTableCart(new List<Product>());
                    DataRow existingRow = dataTable.AsEnumerable()
                                                   .FirstOrDefault(row => row["Name"].ToString() == selectedProduct.ProductName);

                    if (existingRow != null)
                    {
                        // Update the quantity and amount if product is already in the cart
                        int existingQuantity = int.Parse(existingRow["Quantity"].ToString());
                        int newQuantity = existingQuantity + quantity;
                        existingRow["Quantity"] = newQuantity;
                        existingRow["Amount"] = selectedProduct.amountCal(selectedProduct.ProductPrice, newQuantity, discount);
                        temporary = newQuantity;
                    }
                    else
                    {
                        // Add new row for the product
                        dataTable.Rows.Add(dataTable.Rows.Count + 1, selectedProduct.ProductId, selectedProduct.ProductName, selectedProduct.ProductPrice, quantity, discount, amount);
                        temporary = quantity;
                    }
                    totalPrice += selectedProduct.amountCal(selectedProduct.ProductPrice, quantity, discount);
                    txt_TotalPrice.Text = totalPrice.ToString();

                    selectedProduct.ReduceStock(temporary);
                    txt_CartQuantity.Text = selectedProduct.ProductQuantity.ToString();
                    // Re-bind updated DataTable to DataGridView
                    dataGridViewCart.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Selected product not found.");
                }
            }
        }
        private void btn_CartRemove_Click(object sender, EventArgs e)
        {
            // Check if the "N0" text box has a value
            if (!string.IsNullOrWhiteSpace(txt_CartRemove.Text))
            {
                // Parse the "N0" value entered by the user
                if (int.TryParse(txt_CartRemove.Text, out int noToRemove))
                {
                    // Get the DataTable bound to the DataGridView
                    DataTable dataTable = (DataTable)dataGridViewCart.DataSource;

                    // Find the row with the matching "N0" value
                    DataRow rowToRemove = null;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (int.TryParse(row["N0"].ToString(), out int rowNo) && rowNo == noToRemove)
                        {
                            rowToRemove = row;
                            break;
                        }
                    }
                    // Re-bind the updated DataTable to the DataGridView
                    float price = Convert.ToSingle(rowToRemove["Price"]);
                    int quantity = Convert.ToInt32(rowToRemove["Quantity"]);
                    float discount = Convert.ToSingle(rowToRemove["Discount"]);

                    // Calculate the amount with the discount applied
                    float amount = price * quantity * (1 - discount / 100);
                    // Subtract the amount from totalPrice
                    totalPrice -= amount;
                    txt_TotalPrice.Text = totalPrice.ToString();

                    int temporary = int.Parse(txt_CartQuantity.Text);
                    temporary += quantity;
                    txt_CartQuantity.Text = temporary.ToString();
                    // Remove the row if found
                    if (rowToRemove != null)
                    {
                        dataTable.Rows.Remove(rowToRemove);
                        // Re-index the N0 column (optional, to maintain sequential numbering)
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataTable.Rows[i]["N0"] = i + 1;
                        }
                        MessageBox.Show("Product removed successfully.");
                    }
                    else MessageBox.Show("Product with the specified N0 not found in the cart.");
                }
                else MessageBox.Show("Please enter a valid N0 number.");
            }
            else MessageBox.Show("Please enter an N0 number.");
        }
        private void txt_CartAmount_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txt_CartAmount.Text) > int.Parse(txt_CartQuantity.Text))
            {
                MessageBox.Show("Không đủ số lượng!");
                txt_CartAmount.Text = txt_CartQuantity.Text;
            }
        }
        private void btn_CartPayment_Click(object sender, EventArgs e)
        {
            const string message = "Go to payment?";
            DialogResult result = MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Create PrintDocument object for printing
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(printCart_PrintPage);

                // Show PrintDialog and link it to PrintDocument
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument; // Link PrintDocument to PrintDialog

                // Show the PrintDialog and print if user clicks OK
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocument.Print(); // Trigger printing
                        UpdateProductQuantities();
                        ClearDataGridViewRows(dataGridViewCart);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while trying to print: " + ex.Message);
                    }
                }
            }
        }
        private void printCart_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define basic settings for printing
            float yPos = e.MarginBounds.Top; // Start printing from the top margin
            int rowHeight = 30; // Height of each row
            int columnWidth = 100; // Width of each column
            float totalPrice = 0; // Variable to accumulate total price

            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font contentFont = new Font("Arial", 10);
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Brush brush = Brushes.Black;

            // Print store title
            e.Graphics.DrawString("Welcome to THE4 SMART", titleFont, brush, e.MarginBounds.Left, yPos);
            yPos += rowHeight + 10; // Move down for the next row

            // Print date and time
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            e.Graphics.DrawString("Date: " + currentDate, headerFont, brush, e.MarginBounds.Left, yPos);
            yPos += rowHeight; // Move down for the next row

            // Print header row for the table
            e.Graphics.DrawString("N0", headerFont, brush, e.MarginBounds.Left, yPos);
            e.Graphics.DrawString("Name", headerFont, brush, e.MarginBounds.Left + columnWidth, yPos);
            e.Graphics.DrawString("Price", headerFont, brush, e.MarginBounds.Left + 2 * columnWidth, yPos);
            e.Graphics.DrawString("Quantity", headerFont, brush, e.MarginBounds.Left + 3 * columnWidth, yPos);
            e.Graphics.DrawString("Discount", headerFont, brush, e.MarginBounds.Left + 4 * columnWidth, yPos);
            e.Graphics.DrawString("Amount", headerFont, brush, e.MarginBounds.Left + 5 * columnWidth, yPos);

            yPos += rowHeight; // Move down for the next row

            // Loop through each row in the DataGridView and print the values
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder

                // Retrieve and print each cell in the row
                string no = row.Cells["N0"].Value?.ToString();
                string name = row.Cells["Name"].Value?.ToString();
                string price = row.Cells["Price"].Value?.ToString();
                string quantity = row.Cells["Quantity"].Value?.ToString();
                string discount = row.Cells["Discount"].Value?.ToString();
                string amount = row.Cells["Amount"].Value?.ToString();

                e.Graphics.DrawString(no, contentFont, brush, e.MarginBounds.Left, yPos);
                e.Graphics.DrawString(name, contentFont, brush, e.MarginBounds.Left + columnWidth, yPos);
                e.Graphics.DrawString(price, contentFont, brush, e.MarginBounds.Left + 2 * columnWidth, yPos);
                e.Graphics.DrawString(quantity, contentFont, brush, e.MarginBounds.Left + 3 * columnWidth, yPos);
                e.Graphics.DrawString(discount, contentFont, brush, e.MarginBounds.Left + 4 * columnWidth, yPos);
                e.Graphics.DrawString(amount, contentFont, brush, e.MarginBounds.Left + 5 * columnWidth, yPos);

                // Update the total price
                if (float.TryParse(amount, out float parsedAmount))
                {
                    totalPrice += parsedAmount;
                }

                yPos += rowHeight; // Move down for the next row
            }

            // Print total price at the bottom
            yPos += rowHeight; // Space before total
            e.Graphics.DrawString("Total Price: " + totalPrice.ToString("C"), headerFont, brush, e.MarginBounds.Left, yPos);
        }
        private void UpdateProductQuantities()
        {
            try
            {
                // Load the product list from the JSON file
                string filePath = "productList.json";
                string jsonData = File.ReadAllText(filePath);
                var productsWrapper = JsonConvert.DeserializeObject<ProductWrapper>(jsonData);

                // Loop through each item in the cart and update the original product quantities
                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    if (row.IsNewRow) continue;

                    string productId = row.Cells["Id"].Value.ToString();
                    int quantityPurchased = Convert.ToInt32(row.Cells["Quantity"].Value);

                    // Find the matching product in the original product list
                    var product = productsWrapper.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (product != null)
                    {
                        // Update the quantity by subtracting the quantity purchased
                        product.ProductQuantity -= quantityPurchased;
                    }
                }

                // Save the updated product list back to the JSON file
                string updatedJsonData = JsonConvert.SerializeObject(productsWrapper, Formatting.Indented);
                File.WriteAllText(filePath, updatedJsonData);

                MessageBox.Show("Product quantities updated successfully in the file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating quantities: " + ex.Message);
            }
            RefreshDataGridView();
        }
        private void ClearDataGridViewRows(DataGridView dataGridView)
        {
            // Commit dòng mới nếu có (để tránh lỗi)
            dataGridView.EndEdit();

            // Kiểm tra xem DataGridView có hàng nào không
            if (dataGridView.Rows.Count > 1) // Chỉ chạy khi có hơn 1 dòng (để giữ lại dòng mới trống)
            {
                // Xóa từ dưới lên để tránh lỗi
                for (int i = dataGridView.Rows.Count - 2; i >= 0; i--)
                {
                    dataGridView.Rows.RemoveAt(i);
                }

                // Hiển thị thông báo thành công (nếu cần)
                MessageBox.Show("All rows have been cleared from the cart.");
            }
            else
            {
                MessageBox.Show("No rows to clear.");
            }
            txt_TotalPrice.Text = string.Empty;
        }
        private void btn_Sack_Click(object sender, EventArgs e)
        {
            string filePath = @"staffList.json"; // Path to your JSON file
            string staffIdToRemove = txt_SackID.Text; // Get the ID to remove from the text box

            // Load the staff list from the JSON file
            StaffWrapper staffWrapper;
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                staffWrapper = JsonConvert.DeserializeObject<StaffWrapper>(jsonData) ?? new StaffWrapper();
            }
            else
            {
                MessageBox.Show("Staff file not found.");
                return;
            }

            // Check if the staff list is null or empty
            if (staffWrapper.Staffs == null || staffWrapper.Staffs.Count == 0)
            {
                MessageBox.Show("No staff members found.");
                return;
            }

            // Find and remove the staff member with the specified ID
            var staffToRemove = staffWrapper.Staffs.FirstOrDefault(s => s.User_id == staffIdToRemove);
            if (staffToRemove != null)
            {
                staffWrapper.Staffs.Remove(staffToRemove);

                // Save the updated staff list back to the JSON file
                File.WriteAllText(filePath, JsonConvert.SerializeObject(staffWrapper, Formatting.Indented));

                MessageBox.Show("Staff member removed successfully.");

                // Refresh the DataGridView
                dataGridViewStaff.DataSource = null;
                dataGridViewStaff.DataSource = StaffList.dataTableStaff(staffWrapper.Staffs);
            }
            else
            {
                MessageBox.Show("Staff member with the specified ID not found.");
            }
        }
    }
}