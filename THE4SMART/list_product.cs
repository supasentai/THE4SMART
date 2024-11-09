using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
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
        //tìm product với id tương ứng
        Product productToAdd = null;
        foreach (Product product in products)
        {
            if (product.ProductId == id)
            {
                productToAdd = product;
                break;
            }
        }

        if (productToAdd != null)
        {
            productToAdd.ProductQuantity += quantity; //tăng 1 lượng nhapaj vào

            //serialized
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
                    return product;
                }
                else if (id == product.ProductName)
                {
                    return product;
                };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi tải sản phẩm: {ex.Message}");
            MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại sau.");
        }
        return null;
    }
    public bool CheckProductNotExist(string id)
    {
        string filePath = @"productList.json";
        string jsonData = File.ReadAllText(filePath);

        //convert JSON thành ProductList
        ProductList productList = JsonConvert.DeserializeObject<ProductList>(jsonData);

        //check productId tồn tại không
        bool productNotFound = true; 
        foreach (Product product in productList.Products)
        {
            if (product.ProductId == id)
            {
                productNotFound = false; 
                break;
            }
        }
        return productNotFound;
    }
    public void AddProductToFile(Product newProduct)
    {
        string filePath = @"productList.json";

        ProductList productList;

        if (File.Exists(filePath))
        {
            //nếu file tồn tại, convert JSON thành ProductList
            string jsonData = File.ReadAllText(filePath);
            productList = JsonConvert.DeserializeObject<ProductList>(jsonData) ?? new ProductList();
        }
        else
        {
            //nếu file không tồn tại, tạo ProductList mới
            productList = new ProductList();
        }

        productList.Products.Add(newProduct);

        //serialize
        string updatedJsonData = JsonConvert.SerializeObject(productList, Formatting.Indented);
        File.WriteAllText(filePath, updatedJsonData);
    }
    public DataTable dataTableProduct(List<Product> products)
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Id"); 
        dataTable.Columns.Add("Name");
        dataTable.Columns.Add("Price");
        dataTable.Columns.Add("Quatity");
        dataTable.Columns.Add("Category");
        dataTable.Columns.Add("Manufacturer");

        foreach (Product product in products)
        {
            dataTable.Rows.Add(product.ProductId, product.ProductName, product.ProductPrice, product.ProductQuantity, product.ProductCategory, product.ProductManufacturer);
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