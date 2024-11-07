using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using THE4SMART;
using System.Data;

[Serializable]
public class list_Staff : ISerializable
{
    public static bool isSignIN = false;
    public List<Staff> Staffs { get; set; } = new List<Staff>();
    public list_Staff() { }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Staffs", Staffs);
    }

    public list_Staff(SerializationInfo info, StreamingContext context)
    {
        Staffs = (List<Staff>)info.GetValue("Staffs", typeof(List<Staff>));
    }
    
    public void Add(Staff nv)
    {
        Staffs.Add(nv);
    }
    public StaffList LoadUsersFromJson(string filePath)
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);
            StaffList users = JsonConvert.DeserializeObject<StaffList>(jsonData); // Deserialize thành đối tượng StaffList
            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
            return null;
        }
    }


    public void check_user(string username, string password)
    {
        string fileStaffs = @"staffList.json"; // Ensure this path is correct

        try
        {
            StaffList loadedUsers = LoadUsersFromJson(fileStaffs);
            if (loadedUsers == null)
            {
                MessageBox.Show("Failed to load users.");
                return;
            }

            List<Staff> users = loadedUsers.Staffs;

            string enteredUsername = username.Trim().ToLower();
            string enteredPassword = password.Trim();
            Console.WriteLine(enteredUsername);
            // Debugging output
            Console.WriteLine($"Entered Username: {enteredUsername}, Entered Password: {enteredPassword}");

            Staff loggedInStaff = null;
            foreach (Staff user in users)
            {
                if (user.User_id == enteredUsername && user.User_Password == enteredPassword)
                {
                    loggedInStaff = user;
                    break; // Exit the loop once a match is found
                }
            }
            if (loggedInStaff != null)
            {
                isSignIN = true;
                MessageBox.Show($"Welcome, {loggedInStaff.User_name}!");
                Form currentForm = Application.OpenForms["form_Home"];
                if (currentForm != null)
                {
                    currentForm.Close(); // Hoặc bạn có thể dùng this.Close() nếu gọi từ form_Home
                }

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading users: {ex.Message}");
            MessageBox.Show("An error occurred. Please try again later.");
        }
    }
    public bool CheckStaffNotExist(string id)
    {
        // Đọc file JSON
        string filePath = @"staffList.json";
        string jsonData = File.ReadAllText(filePath);

        // Chuyển đổi JSON thành đối tượng StaffList
        StaffList staffList = JsonConvert.DeserializeObject<StaffList>(jsonData);

        // Kiểm tra xem StaffId có tồn tại không
        bool staffNotFound = !staffList.Staffs.Any(staff => staff.User_id == id);

        return staffNotFound;
    }
    public void AddStaffToFile(Staff newStaff)
    {
        // Đường dẫn đến file JSON
        string filePath = @"staffList.json";

        // Đọc dữ liệu hiện tại từ file JSON
        StaffList staffList;

        if (File.Exists(filePath))
        {
            // Nếu file tồn tại, đọc và chuyển đổi dữ liệu JSON thành đối tượng StaffList
            string jsonData = File.ReadAllText(filePath);
            staffList = JsonConvert.DeserializeObject<StaffList>(jsonData) ?? new StaffList();
        }
        else
        {
            // Nếu file không tồn tại, tạo đối tượng StaffList mới
            staffList = new StaffList();
        }

        // Thêm sản phẩm mới vào danh sách
        staffList.Staffs.Add(newStaff);

        // Ghi lại danh sách vào file JSON
        string updatedJsonData = JsonConvert.SerializeObject(staffList, Formatting.Indented);
        File.WriteAllText(filePath, updatedJsonData);
    }
    public DataTable dataTableStaff(List<Staff> staffs)
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
}
public class StaffList
{
    public List<Staff> Staffs { get; set; }

}
public class StaffWrapper
{
    public List<Staff> Staffs { get; set; }
}