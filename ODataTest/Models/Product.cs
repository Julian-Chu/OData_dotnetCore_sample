using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataTest.Models
{
    public class Product
    {
      public int Id { get; set; }
      public ProductDetail Detail { get; set; }
      public ProductCategory Category { get; set; }
  }
}
