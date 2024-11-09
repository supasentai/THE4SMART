using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using THE4SMART;
using System.Data;

[Serializable]
public class list_Staff : ISerializable
{
    public static bool isSignIN = false; //tạo biến kiểm tra đăng nhập thành công
    public List<Staff> Staffs { get; set; } = new List<Staff>();
    public list_Staff() { }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {//serialized
        info.AddValue("Staffs", Staffs);
    }
    public list_Staff(SerializationInfo info, StreamingContext context)
    {
        Staffs = (List<Staff>)info.GetValue("Staffs", typeof(List<Staff>));
    }
    public list_Staff LoadStaffsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new list_Staff();
        }
        string jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<list_Staff>(jsonData) ?? new list_Staff();
    }
    public void check_user(string username, string password)
    {//kiểm tra TT đăng nhập
        string fileStaffs = @"staffList.json";
        try
        {
            StaffList loadedUsers = StaffList.LoadUsersFromJson(fileStaffs);
            if (loadedUsers == null)
            {
                MessageBox.Show("Failed to load users.");
                return;
            }
            List<Staff> users = loadedUsers.Staffs;

            string enteredUsername = username.Trim().ToLower();
            string enteredPassword = password.Trim();

            Staff loggedInStaff = null;
            foreach (Staff user in users)
            {
                if (user.User_id == enteredUsername && user.User_Password == enteredPassword)
                {
                    loggedInStaff = user;
                    break;
                }
            }
            if (loggedInStaff != null)
            {
                isSignIN = true;
                MessageBox.Show($"Welcome, {loggedInStaff.User_name}!");
                Form currentForm = Application.OpenForms["form_Home"];
                if (currentForm != null)
                {
                    currentForm.Close();
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
        //đọc file JSON
        string filePath = @"staffList.json";
        string jsonData = File.ReadAllText(filePath);

        //convert JSON thành đối tượng StaffList
        StaffList staffList = JsonConvert.DeserializeObject<StaffList>(jsonData);

        //?StaffId có tồn tại
        bool staffNotFound = true;

        foreach (Staff staff in staffList.Staffs)
        {
            if (staff.User_id == id)
            {
                staffNotFound = false;
                break;
            }
        }
        return staffNotFound;
    }
    public void AddStaffToFile(Staff newStaff)
    {
        string filePath = @"staffList.json";
        StaffList staffList;

        if (File.Exists(filePath))
        {
            //Nếu file tồn tại, convert dữ liệu JSON thành StaffList
            string jsonData = File.ReadAllText(filePath);
            staffList = JsonConvert.DeserializeObject<StaffList>(jsonData) ?? new StaffList();
        }
        else
        {
            //nếu file không tồn tại, tạo StaffList mới
            staffList = new StaffList();
        }

        staffList.Staffs.Add(newStaff);

        //serialized
        string updatedJsonData = JsonConvert.SerializeObject(staffList, Formatting.Indented);
        File.WriteAllText(filePath, updatedJsonData);
    }
    public DataTable dataTableStaff(List<Staff> staffs)
    {//tạo bảng
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Id");
        dataTable.Columns.Add("Name");
        dataTable.Columns.Add("Shift");
        dataTable.Columns.Add("Address");
        dataTable.Columns.Add("Phone");

        foreach (Staff staff in staffs)
        {
            dataTable.Rows.Add(staff.User_id, staff.User_name, staff.StaffShift, staff.User_Address, staff.User_Phone);
        }
        return dataTable;
    }
}
public class StaffList
{
    public List<Staff> Staffs { get; set; }
    public static StaffList LoadUsersFromJson(string filePath)
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);
            StaffList users = JsonConvert.DeserializeObject<StaffList>(jsonData); //deserialize
            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
            return null;
        }
    }
}
public class StaffWrapper
{
    public List<Staff> Staffs { get; set; }
}