using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using THE4SMART;

[Serializable]
public class list_Manager : ISerializable
{
    public static bool permission = false;
    public List<Manager> Managers { get; set; } = new List<Manager>();
    public list_Manager() { }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Managers", Managers);
    }

    public list_Manager(SerializationInfo info, StreamingContext context)
    {
        Managers = (List<Manager>)info.GetValue("Managers", typeof(List<Manager>));
    }
}
public class ManagerList
{
    public List<Manager> Managers { get; set; }

}