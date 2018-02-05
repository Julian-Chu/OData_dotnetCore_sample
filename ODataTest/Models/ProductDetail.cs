using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODataTest.Models
{
  public class ProductDetail
  {
    public string Desc { get; set; }
    public DateTimeOffset Created { get; set; }
  }
}
