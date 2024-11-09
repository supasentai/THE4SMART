using System.IO;
using System.Text.Json;

public class back_menu
{
    public static void init_product()
    {
        string fileProduct = "productList.json";

        list_product productList;
        if (File.Exists(fileProduct))
        {
            string jsonProduct = File.ReadAllText(fileProduct);
            productList = JsonSerializer.Deserialize<list_product>(jsonProduct) ?? new list_product();
        }
        else
        {
            productList = new list_product();
        }
        //serialized
        string newJsonProduct = JsonSerializer.Serialize(productList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileProduct, newJsonProduct);
    }
    public static void init_staff()
    {
        string fileStaff = "staffList.json";

        list_Staff staffList;
        if (File.Exists(fileStaff))
        {
            string jsonStaff = File.ReadAllText(fileStaff);
            staffList = JsonSerializer.Deserialize<list_Staff>(jsonStaff) ?? new list_Staff();
        }
        else
        {
            staffList = new list_Staff();
        }
        string newJsonStaff = JsonSerializer.Serialize(staffList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileStaff, newJsonStaff);
    }
}