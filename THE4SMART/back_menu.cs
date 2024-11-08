using System;
using System.IO;
using System.Text.Json;
using THE4SMART;

public class back_menu
{
    public static void init_product()
    {
        string fileProduct = "productList.json";

        // Kiểm tra xem file JSON có tồn tại không
        list_product productList;
        if (File.Exists(fileProduct))
        {
            // Đọc dữ liệu từ file JSON nếu file tồn tại
            string jsonProduct = File.ReadAllText(fileProduct);
            productList = JsonSerializer.Deserialize<list_product>(jsonProduct) ?? new list_product();
        }
        else
        {
            // Nếu file không tồn tại, khởi tạo danh sách khách hàng mới
            productList = new list_product();
        }
        // Ghi lại toàn bộ danh sách khách hàng vào file JSON
        string newJsonProduct = JsonSerializer.Serialize(productList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileProduct, newJsonProduct);

        if (productList.Products.Count > 0)
        {
            for (int i = 0; i < productList.Products.Count; i++)
            {
                Product product = productList.Products[i];
                Console.WriteLine($"{product.ProductId,-10}{product.ProductQuantity,-15}{product.ProductPrice,-10}");
            }
        }
    }
    public static void init_manager()
    {
        string fileManager = "managerList.json";

        // Kiểm tra xem file JSON có tồn tại không
        list_Manager managerList;
        if (File.Exists(fileManager))
        {
            // Đọc dữ liệu từ file JSON nếu file tồn tại
            string jsonManager = File.ReadAllText(fileManager);
            managerList = JsonSerializer.Deserialize<list_Manager>(jsonManager) ?? new list_Manager();
        }
        else
        {

            managerList = new list_Manager();
        }

        Console.WriteLine("Nhập thông tin quản lí:");
        Console.Write("ID: ");
        string id = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        Console.Write("Tên: ");
        string name = Console.ReadLine();
        Console.Write("Số điện thoại: ");
        string phone = Console.ReadLine();
        Console.Write("Địa chỉ: ");
        string address = Console.ReadLine();

        managerList.Add(new Manager(id, password, name, phone, address));

        // Ghi lại toàn bộ danh sách khách hàng vào file JSON
        string newJsonManager = JsonSerializer.Serialize(managerList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileManager, newJsonManager);

        Console.WriteLine("Danh sách quản lí:");
        Console.WriteLine(new string('-', 60));  // Dòng phân cách
        Console.WriteLine($"{"ID",-10}{"Tên",-15}{"SĐT",-15}{"Địa chỉ",-10}{"Quản lí",-10}");
        Console.WriteLine(new string('-', 60));  // Dòng phân cách

        if (managerList.Managers.Count > 0)
        {
            for (int i = 0; i < managerList.Managers.Count; i++)
            {
                Manager manager = managerList.Managers[i];
                Console.WriteLine($"{manager.User_id,-10}{manager.User_name,-15}{manager.User_Phone,-15}{manager.User_Address,-10}");
            }
        }
        else
        {
            Console.WriteLine("Danh sách quản lí trống.");
        }
    }
    public static void init_staff()
    {
        string fileStaff = "staffList.json";

        // Kiểm tra xem file JSON có tồn tại không
        list_Staff staffList;
        if (File.Exists(fileStaff))
        {
            // Đọc dữ liệu từ file JSON nếu file tồn tại
            string jsonStaff = File.ReadAllText(fileStaff);
            staffList = JsonSerializer.Deserialize<list_Staff>(jsonStaff) ?? new list_Staff();
        }
        else
        {

            staffList = new list_Staff();
        }


        string newJsonStaff = JsonSerializer.Serialize(staffList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileStaff, newJsonStaff);

        Console.WriteLine("Danh sách quản lí:");
        Console.WriteLine(new string('-', 60));  // Dòng phân cách
        Console.WriteLine($"{"ID",-10}{"Tên",-15}{"SĐT",-15}{"Địa chỉ",-10}{"Ca",-10}");
        Console.WriteLine(new string('-', 60));  // Dòng phân cách

        if (staffList.Staffs.Count > 0)
        {
            for (int i = 0; i < staffList.Staffs.Count; i++)
            {
                Staff staff = staffList.Staffs[i];
                Console.WriteLine($"{staff.User_id,-10}{staff.User_name,-15}{staff.User_Phone,-15}{staff.User_Address,-10}{staff.StaffShift,-10}");
            }
        }
        else
        {
            Console.WriteLine("Danh sách nhân viên trống.");
        }
    }
}