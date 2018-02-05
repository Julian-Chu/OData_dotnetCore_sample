using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataTest.Models;
using Microsoft.AspNet.OData.Routing;

namespace ODataTest.Controllers
{
  //[Produces("application/json")]
  //[Route("api/Products")]
  [EnableQuery]
  public class ProductsController : ODataController
    {
      private List<Product> products = new List<Product>()
      {
              new Product()
              {
                      Id = 0,
                      Detail = new ProductDetail()
                      {
                              Desc = "Product 0",
                              Created = DateTime.Now
                      },
                      Category = new ProductCategory()
                      {
                              Id = 0,
                              Desc = "Cate0"
                      }
              },
              new Product()
              {
                      Id = 1,
                      Detail = new ProductDetail()
                      {
                              Desc = "Product 1",
                              Created = DateTime.Now
                      },
                      Category = new ProductCategory()
                      {
                              Id = 1,
                              Desc = "Cate1"
                      }
              },
              new Product()
              {
                      Id = 2,
                      Detail = new ProductDetail()
                      {
                              Desc = "Product 2",
                              Created = DateTime.Now
                      },
                      Category = new ProductCategory()
                      {
                              Id = 2,
                              Desc = "Cate2"
                      }
              },
      };

    //[HttpGet]
      [ODataRoute("Products")]
    [ODataRoute("products")]
    public List<Product> Get()
      {
        return products;
      }

      [HttpGet]
      [Route("api/products/{Id}")]
      [ODataRoute("products({Id})")]
      [ODataRoute("Products({Id})")]

    //[ODataRoute("Products({Id})")]
    public IActionResult GetById(int Id)
      {
        var item = products.FirstOrDefault(x => x.Id == Id);
        return Ok(item);
      }

      [HttpGet]
      [ODataRoute("Products({Id})/detail")]

      //[ODataRoute("Products({Id})")]
      public IActionResult GetDetailByProductId(int Id)
      {
        var item = products.FirstOrDefault(x => x.Id == Id);
        var detail = item.Detail;
        return Ok(detail);
      }
  }
}