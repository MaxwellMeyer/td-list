using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; }


    public Item(string description)
    {
      Description = description;
    }

    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {

    }

    public static Item Find(int searchId)
    {
      return [searchId - 1];
    }
  }
}