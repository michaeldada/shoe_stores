using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Shoes
{
  public class Store
  {
    private int _id;
    private string _name;

    public Store(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

  }
}
