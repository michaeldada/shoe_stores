using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Shoes
{
  public class Brand
  {
    private int _id;
    private string _name;

    public Brand(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
  }
}
