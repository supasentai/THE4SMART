using System.Runtime.Serialization;
using System;

[Serializable]
public class Product : ISerializable
{
    public string ProductId { get; set; }
    public int ProductQuantity { get; set; }
    public int ProductPrice { get; set; }
    public string ProductName { get; set; }
    public string ProductManufacturer { get; set; }
    public string ProductCategory { get; set; }
    public float ProductDiscount { get; set; } 
    //khởi tạo constructers
    public Product(string productId,string productName, int productQuantity, int productPrice, string productCategory, string productManufacturer)
    {
        ProductId = productId;
        ProductName = productName;
        ProductQuantity = productQuantity;
        ProductPrice = productPrice;
        ProductCategory = productCategory;
        ProductManufacturer = productManufacturer;
        ProductDiscount = 0;
    }
    //serialized
    protected Product(SerializationInfo info, StreamingContext context)
    {
        ProductId = info.GetString("ProductId");
        ProductName = info.GetString("ProductName");
        ProductQuantity = info.GetInt32("ProductQuantity");
        ProductPrice = info.GetInt32("ProductPrice");
        ProductCategory = info.GetString("ProductCategory");
        ProductManufacturer = info.GetString("ProductManufacturer");
        ProductDiscount = info.GetSingle("ProductDiscount");
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("ProductId", ProductId);
        info.AddValue("ProductName", ProductName);
        info.AddValue("ProductQuantity", ProductQuantity);
        info.AddValue("ProductPrice", ProductPrice);
        info.AddValue("ProductCategory", ProductCategory);
        info.AddValue("ProductManufacturer", ProductManufacturer);
        info.AddValue("ProductDiscount", ProductDiscount);
    }
    //hàm giảm SL
    public void ReduceStock(int amount)
    {
        if (ProductQuantity > 0)
        {
            ProductQuantity -= amount;
        }
        else
        {
            Console.WriteLine("Out of stock!");
        }
    }
    //tính tổng tiền thanh toán
    public float amountCal(int price, int quantity, float discount)
    {
        return price * quantity * (1 - discount / 100);
    }
}