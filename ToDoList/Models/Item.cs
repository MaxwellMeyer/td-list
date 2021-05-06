using System.Collections.Generic;


namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Priority { get; set; }
    private static List<Item> _instances = new List<Item> {};
    public static List<Item> GetAll()
  {
    return _instances;
  }
  public static void ClearAll()
  {
    _instances.Clear();
  }

    public Item(string description, int priority)
    {
      Description = description;
      Priority = priority;
      _instances.Add(this);
    }
  }
}