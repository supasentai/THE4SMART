using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                    //deserialized
                    string filePath = @"staffList.json";
                    StaffList = StaffList.LoadStaffsFromJson(filePath);

                    //chạylaij DataGridView
                    dataGridViewStaff.DataSource = null;
                    List<Staff> staffListForGridView = new List<Staff>();
                    foreach (Staff staff in StaffList.Staffs)
                    {
                        staffListForGridView.Add(staff);
                    }
                    dataGridViewStaff.DataSource = staffListForGridView;
                    MessageBox.Show("Successfully Added!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid information.");
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
            //deserialized
            string jsonData = File.ReadAllText(filePath);
            ProductWrapper productsWrapper = JsonConvert.DeserializeObject<ProductWrapper>(jsonData);

            if (productsWrapper != null && productsWrapper.Products != null)
            {
                List<string> uniqueCategories = new List<string>();
                foreach (Product product in productsWrapper.Products)
                {
                    if (!uniqueCategories.Contains(product.ProductCategory))
                    {
                        uniqueCategories.Add(product.ProductCategory);
                    }
                }

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

            List<string> filteredProducts = new List<string>();
            foreach (Product product in productWrapper.Products)
            {
                if (product.ProductCategory == selectedCategory)
                {
                    filteredProducts.Add(product.ProductName);
                }
            }

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
            Product foundProduct = ProductList.CheckProduct(cbb_CartName.Text); //tìm product khớp với tên SP trong file 

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
                dataTable.Rows.Add(i, product.ProductId, product.ProductName, product.ProductPrice, txt_CartAmount.Text, cbb_Discount.Text, product.amountCal(product.ProductPrice, int.Parse(txt_CartAmount.Text), float.Parse(cbb_Discount.Text)));
                i++;
            }
            return dataTable;
        }
        private void btn_CartAdd_Click(object sender, EventArgs e)
        {
            Product selectedProduct = ProductList.CheckProduct(txt_CartID.Text); // use the entered Product ID
            int temporary;
            if (int.Parse(txt_CartQuantity.Text) > 0 && int.Parse(txt_CartQuantity.Text) >= int.Parse(txt_CartAmount.Text))
            {
                if (selectedProduct != null)
                {
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
                    float amount = selectedProduct.amountCal(selectedProduct.ProductPrice, quantity, discount);

                    DataTable dataTable = (DataTable)dataGridViewCart.DataSource ?? dataTableCart(new List<Product>());
                    DataRow existingRow = null;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        //kiểm tra nếu giá trị trong cột "Name" trùng với ProductName của sản phẩm
                        if (row["Name"].ToString() == selectedProduct.ProductName)
                        {
                            existingRow = row;
                            break;
                        }
                    }

                    if (existingRow != null)
                    {
                        int existingQuantity = int.Parse(existingRow["Quantity"].ToString());
                        int newQuantity = existingQuantity + quantity;
                        existingRow["Quantity"] = newQuantity;
                        existingRow["Amount"] = selectedProduct.amountCal(selectedProduct.ProductPrice, newQuantity, discount);
                        temporary = newQuantity;
                    }
                    else
                    {
                        //thêm dòng
                        dataTable.Rows.Add(dataTable.Rows.Count + 1, selectedProduct.ProductId, selectedProduct.ProductName, selectedProduct.ProductPrice, quantity, discount, amount);
                        temporary = quantity;
                    }
                    totalPrice += selectedProduct.amountCal(selectedProduct.ProductPrice, quantity, discount);
                    txt_TotalPrice.Text = totalPrice.ToString();

                    selectedProduct.ReduceStock(temporary);
                    txt_CartQuantity.Text = selectedProduct.ProductQuantity.ToString();

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
            if (!string.IsNullOrWhiteSpace(txt_CartRemove.Text))
            {
                if (int.TryParse(txt_CartRemove.Text, out int noToRemove))
                {
                    DataTable dataTable = (DataTable)dataGridViewCart.DataSource;

                    DataRow rowToRemove = null;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (int.TryParse(row["N0"].ToString(), out int rowNo) && rowNo == noToRemove)
                        {
                            rowToRemove = row;
                            break;
                        }
                    }
                    float price = Convert.ToSingle(rowToRemove["Price"]);
                    int quantity = Convert.ToInt32(rowToRemove["Quantity"]);
                    float discount = Convert.ToSingle(rowToRemove["Discount"]);

                    float amount = price * quantity * (1 - discount / 100);

                    totalPrice -= amount;
                    txt_TotalPrice.Text = totalPrice.ToString();

                    int temporary = int.Parse(txt_CartQuantity.Text);
                    temporary += quantity;
                    txt_CartQuantity.Text = temporary.ToString();
                    //xóa dòng
                    if (rowToRemove != null)
                    {
                        dataTable.Rows.Remove(rowToRemove);
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
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(printCart_PrintPage);

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument; 

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocument.Print();
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

            float yPos = e.MarginBounds.Top; 
            int rowHeight = 30; 
            int columnWidth = 100;
            float totalPrice = 0;

            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font contentFont = new Font("Arial", 10);
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Brush brush = Brushes.Black;

            e.Graphics.DrawString("Welcome to THE4 SMART", titleFont, brush, e.MarginBounds.Left, yPos);
            yPos += rowHeight + 10;

            string currentDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            e.Graphics.DrawString("Date: " + currentDate, headerFont, brush, e.MarginBounds.Left, yPos);
            yPos += rowHeight; 

            e.Graphics.DrawString("N0", headerFont, brush, e.MarginBounds.Left, yPos);
            e.Graphics.DrawString("Name", headerFont, brush, e.MarginBounds.Left + columnWidth, yPos);
            e.Graphics.DrawString("Price", headerFont, brush, e.MarginBounds.Left + 2 * columnWidth, yPos);
            e.Graphics.DrawString("Quantity", headerFont, brush, e.MarginBounds.Left + 3 * columnWidth, yPos);
            e.Graphics.DrawString("Discount", headerFont, brush, e.MarginBounds.Left + 4 * columnWidth, yPos);
            e.Graphics.DrawString("Amount", headerFont, brush, e.MarginBounds.Left + 5 * columnWidth, yPos);

            yPos += rowHeight;

            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.IsNewRow) continue;

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

                if (float.TryParse(amount, out float parsedAmount))
                {
                    totalPrice += parsedAmount;
                }

                yPos += rowHeight;
            }

            yPos += rowHeight;
            e.Graphics.DrawString("Total Price: " + totalPrice.ToString("C"), headerFont, brush, e.MarginBounds.Left, yPos);
        }
        private void UpdateProductQuantities()
        {
            try
            {
                string filePath = "productList.json";
                string jsonData = File.ReadAllText(filePath);
                ProductWrapper productsWrapper = JsonConvert.DeserializeObject<ProductWrapper>(jsonData);

                foreach (DataGridViewRow row in dataGridViewCart.Rows)
                {
                    if (row.IsNewRow) continue;

                    string productId = row.Cells["Id"].Value.ToString();
                    int quantityPurchased = Convert.ToInt32(row.Cells["Quantity"].Value);

                    Product product = null;
                    foreach (var p in productsWrapper.Products)
                    {
                        if (p.ProductId == productId)
                        {
                            product = p;
                            break;
                        }
                    }
                    if (product != null)
                    {
                        product.ProductQuantity -= quantityPurchased;
                    }
                }

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
            dataGridView.EndEdit();

            if (dataGridView.Rows.Count > 1) 
            {
                for (int i = dataGridView.Rows.Count - 2; i >= 0; i--)
                {
                    dataGridView.Rows.RemoveAt(i);
                }
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
            string filePath = @"staffList.json";
            string staffIdToRemove = txt_SackID.Text;

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

            if (staffWrapper.Staffs == null || staffWrapper.Staffs.Count == 0)
            {
                MessageBox.Show("No staff members found.");
                return;
            }

            Staff staffToRemove = null;
            foreach (var staff in staffWrapper.Staffs)
            {
                if (staff.User_id == staffIdToRemove)
                {
                    staffToRemove = staff;
                    break;
                }
            }
            if (staffToRemove != null)
            {
                staffWrapper.Staffs.Remove(staffToRemove);

                File.WriteAllText(filePath, JsonConvert.SerializeObject(staffWrapper, Formatting.Indented));

                MessageBox.Show("Staff member removed successfully.");

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