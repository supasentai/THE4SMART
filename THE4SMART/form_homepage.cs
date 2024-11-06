using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            string json_product = File.ReadAllText(@"D:\C#\THE4SMART\THE4SMART\bin\Debug\productList.json");
            ProductWrapper productWrapper = JsonConvert.DeserializeObject<ProductWrapper>(json_product);
            dataGridView1.DataSource = dataTableProduct(productWrapper.Products);
            dataGridViewStorage.DataSource = dataTableProduct(productWrapper.Products);

            string json_staff = File.ReadAllText(@"D:\C#\THE4SMART\THE4SMART\bin\Debug\staffList.json");
            StaffWrapper staffWrapper = JsonConvert.DeserializeObject<StaffWrapper>(json_staff);
            dataGridViewStaff.DataSource = dataTableStaff(staffWrapper.Staffs);

            // Nạp dữ liệu sản phẩm từ file JSON và gán vào ProductList
            ProductList = LoadProductsFromJson(@"D:\C#\THE4SMART\THE4SMART\bin\Debug\productList.json");

            // Đảm bảo ProductList đã chứa sản phẩm
            if (ProductList.Products == null || ProductList.Products.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm trống hoặc không thể đọc dữ liệu từ file JSON.");
                return;
            }

            // Cập nhật DataGridView với dữ liệu sản phẩm
            dataGridView1.DataSource = dataTableProduct(ProductList.Products);
            dataGridViewStorage.DataSource = dataTableProduct(ProductList.Products);

            // Nạp dữ liệu staff từ file JSON và hiển thị trong DataGridView
            StaffList = LoadStaffsFromJson(@"D:\C#\THE4SMART\THE4SMART\bin\Debug\staffList.json");
            if (StaffList.Staffs != null)
            {
                dataGridViewStaff.DataSource = dataTableStaff(StaffList.Staffs);
            }

            // Cập nhật danh sách danh mục sản phẩm
            updateCategory(@"D:\C#\THE4SMART\THE4SMART\bin\Debug\productList.json");
        }
        public class ProductWrapper
        {
            public List<Product> Products { get; set; }
        }
        public class StaffWrapper
        {
            public List<Staff> Staffs { get; set; }
        }
        private DataTable dataTableProduct(List<Product> products)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id"); // Adjust column names accordingly
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Quatity");
            dataTable.Columns.Add("Category");
            dataTable.Columns.Add("Manufacturer");

            foreach (Product product in products)
            {
                dataTable.Rows.Add(product.ProductId, product.ProductName, product.ProductPrice, product.ProductQuantity, product.ProductCategory, product.ProductManufacturer); // Adjust properties accordingly
            }
            return dataTable;
        }
        private DataTable dataTableStaff(List<Staff> staffs)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Shift");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("Phone");
            // Add rows
            foreach (Staff staff in staffs)
            {
                dataTable.Rows.Add(staff.User_id, staff.User_name, staff.StaffShift, staff.User_Address, staff.User_Phone); // Adjust properties accordingly
            }
            return dataTable;
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
            updateCategory(@"D:\C#\THE4SMART\THE4SMART\bin\Debug\productList.json");
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
        private list_product LoadProductsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new list_product();
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<list_product>(jsonData) ?? new list_product();
        }
        private void btn_StaffAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (StaffList.CheckStaffNotExist(txt_StaffID.Text))
                {//string user_id, string user_password, string user_name, string user_phone, string user_address, string staffShift
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
                    string filePath = @"D:\C#\THE4SMART\THE4SMART\bin\Debug\staffList.json";
                    StaffList = LoadStaffsFromJson(filePath);

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
        private list_Staff LoadStaffsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new list_Staff();
            }

            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<list_Staff>(jsonData) ?? new list_Staff();
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

            // Đọc dữ liệu từ file JSON
            string jsonData = File.ReadAllText(filePath);
            ProductWrapper productsWrapper = JsonConvert.DeserializeObject<ProductWrapper>(jsonData);

            if (productsWrapper != null && productsWrapper.Products != null)
            {
                var uniqueCategories = productsWrapper.Products
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

            string selectedCategory = cbb_CartCategory.SelectedItem.ToString();

            if (selectedCategory == null) return;

            var filteredProducts = ProductList.Products
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
        public bool CheckProductNotExist(string id)
        {
            // Đọc file JSON
            string filePath = @"D:\C#\THE4SMART\THE4SMART\bin\Debug\productList.json";
            string jsonData = File.ReadAllText(filePath);

            // Chuyển đổi JSON thành đối tượng ProductList
            ProductList productList = JsonConvert.DeserializeObject<ProductList>(jsonData);

            // Kiểm tra xem ProductId có tồn tại không
            bool productNotFound = !productList.Products.Any(product => product.ProductId == id);

            return productNotFound;
        }
        private void RefreshDataGridView()
        {
            string filePath = @"D:\C#\THE4SMART\THE4SMART\bin\Debug\productList.json";
            ProductList = LoadProductsFromJson(filePath);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTableProduct(ProductList.Products);

            dataGridViewStorage.DataSource = null;
            dataGridViewStorage.DataSource = dataTableProduct(ProductList.Products);
        }

        private DataTable dataTableCart(List<Product> products)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("N0");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Discount");
            dataTable.Columns.Add("Amount");

            int i = 1;
            foreach (Product product in products)
            {
                dataTable.Rows.Add(i, product.ProductName, product.ProductPrice, txt_CartAmount.Text, cbb_Discount.Text, product.amountCal(product.ProductPrice, int.Parse(txt_CartAmount.Text), float.Parse(cbb_Discount.Text))); // Adjust properties accordingly
                i++;
            }
            return dataTable;
        }

        private void btn_CartAdd_Click(object sender, EventArgs e)
        {
            // Retrieve product by ID from the list
            Product selectedProduct = ProductList.CheckProduct(txt_CartID.Text); // use the entered Product ID
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
                }
                else
                {
                    // Add new row for the product
                    dataTable.Rows.Add(dataTable.Rows.Count + 1, selectedProduct.ProductName, selectedProduct.ProductPrice, quantity, discount, amount);
                    
                }
                totalPrice += selectedProduct.amountCal(selectedProduct.ProductPrice, quantity, discount);
                txt_TotalPrice.Text = totalPrice.ToString();

                // Re-bind updated DataTable to DataGridView
                dataGridViewCart.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Selected product not found.");
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

                    // Remove the row if found
                    if (rowToRemove != null)
                    {
                        dataTable.Rows.Remove(rowToRemove);

                        // Re-index the N0 column (optional, to maintain sequential numbering)
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataTable.Rows[i]["N0"] = i + 1;
                        }

                        // Re-bind the updated DataTable to the DataGridView
                        dataGridViewCart.DataSource = dataTable;
                        MessageBox.Show("Product removed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Product with the specified N0 not found in the cart.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid N0 number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter an N0 number.");
            }
        }

        private void txt_TotalPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
