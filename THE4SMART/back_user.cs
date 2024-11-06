using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace THE4SMART
{
    [Serializable]
    public class User : ISerializable
    {
        public string User_id { get; set; }
        public string User_Password { get; set; }
        public string User_name { get; set; }
        public string User_Phone { get; set; }
        public string User_Address { get; set; }

        public User() { }
        [JsonConstructor]

        public User(string id, string password, string name, string phone, string address)
        {
            User_id = id;
            User_Password = password;
            User_name = name;
            User_Phone = phone;
            User_Address = address;
        }

        public User(SerializationInfo info, StreamingContext context)
        {
            User_id = info.GetString("User_id");
            User_Password = info.GetString("User_Password");
            User_name = info.GetString("User_name");
            User_Phone = info.GetString("User_Phone");
            User_Address = info.GetString("User_Address");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("User_id", User_id);
            info.AddValue("User_Password", User_Password);
            info.AddValue("User_name", User_name);
            info.AddValue("User_Phone", User_Phone);
            info.AddValue("User_Address", User_Address);
        }
        public virtual void ShowInfo()
        {
        }
    }

    [Serializable]
    public class Manager : User
    {
        public Manager(string id, string password, string name, string phone, string address)
            : base(id, password, name, phone, address)
        {
        }
        public Manager(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Manager ID: {User_id}, Name: {User_name}");
        }
    }
    [Serializable]
    public class Staff : User
    {

        public string StaffShift { get; set; }
        public Staff() { }
        [JsonConstructor]
        public Staff(string user_id, string user_password, string user_name, string user_phone, string user_address, string staffShift)
            : base(user_id, user_password, user_name, user_phone, user_address)
        {
            StaffShift = staffShift;
        }

        public Staff(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            StaffShift = info.GetString("StaffShift");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("StaffShift", StaffShift);
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Staff ID: {User_id}, Name: {User_name}, Shift: {StaffShift}");
        }
    }
}
