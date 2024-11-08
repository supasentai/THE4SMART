using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using THE4SMART;
using System.Linq;
using System.Xml.Linq;
using System.Data;

[Serializable]
public class list_product: ISerializable
{
    public List<Product> Products { get; set; } = new List<Product>();
    public list_product() { }
  
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Products", Products);
    }
    public list_product(SerializationInfo info, StreamingContext context)
    {
        Products = (List<Product>)info.GetValue("Products", typeof(List<Product>));
    }
    public void Add(string id, int quantity)
    {
        string filePath = @"productList.json";
        ProductList loadedProducts = ProductList.LoadProductsFromJson(filePath);
        List<Product> products = loadedProducts?.Products;

        if (products == null)
        {
            MessageBox.Show("Product list is empty or failed to load.");
            return;
        }

        // Find the product with the specified ID and increase its quantity
        Product productToAdd = products.FirstOrDefault(product => product.ProductId == id);

        if (productToAdd != null)
        {
            productToAdd.ProductQuantity += quantity; // Increase the quantity by 1 (or any other number as needed)

            // Save the updated product list back to the JSON file
            File.WriteAllText(filePath, JsonConvert.SerializeObject(loadedProducts, Formatting.Indented));
        }
        else
        {
            MessageBox.Show("Product with specified ID not found.");
        }
    }
    public list_product LoadProductsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new list_product();
        }

        string jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<list_product>(jsonData) ?? new list_product();
    }
    public Product CheckProduct(string id)
    {
        string fileProducts = @"productList.json";
        try
        {
            ProductList loadedProducts = ProductList.LoadProductsFromJson(fileProducts);
            List<Product> products = loadedProducts?.Products;

            foreach (Product product in products)
            {
                if (id == product.ProductId)
                {
                    return product; // Trả về đối tượng sản phẩm tìm thấy
                }
                else if (id == product.ProductName)
                {
                    return product; // Trả về đối tượng sản phẩm tìm thấy
                };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi tải sản phẩm: {ex.Message}");
            MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại sau.");
        }

        return null; // Trả về null nếu không tìm thấy sản phẩm
    }
    public bool CheckProductNotExist(string id)
    {
        // Đọc file JSON
        string filePath = @"productList.json";
        string jsonData = File.ReadAllText(filePath);

        // Chuyển đổi JSON thành đối tượng ProductList
        ProductList productList = JsonConvert.DeserializeObject<ProductList>(jsonData);

        // Kiểm tra xem ProductId có tồn tại không
        bool productNotFound = !productList.Products.Any(product => product.ProductId == id);

        return productNotFound;
    }
    public void AddProductToFile(Product newProduct)
    {
        // Đường dẫn đến file JSON
        string filePath = @"productList.json";

        // Đọc dữ liệu hiện tại từ file JSON
        ProductList productList;

        if (File.Exists(filePath))
        {
            // Nếu file tồn tại, đọc và chuyển đổi dữ liệu JSON thành đối tượng ProductList
            string jsonData = File.ReadAllText(filePath);
            productList = JsonConvert.DeserializeObject<ProductList>(jsonData) ?? new ProductList();
        }
        else
        {
            // Nếu file không tồn tại, tạo đối tượng ProductList mới
            productList = new ProductList();
        }

        // Thêm sản phẩm mới vào danh sách
        productList.Products.Add(newProduct);

        // Ghi lại danh sách vào file JSON
        string updatedJsonData = JsonConvert.SerializeObject(productList, Formatting.Indented);
        File.WriteAllText(filePath, updatedJsonData);
    }
    public DataTable dataTableProduct(List<Product> products)
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
    
}
public class ProductList
{
    public List<Product> Products { get; set; }
    public static ProductList LoadProductsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new ProductList();
        }

        string jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<ProductList>(jsonData) ?? new ProductList();
    }
}
public class ProductWrapper
{
    public List<Product> Products { get; set; }
}