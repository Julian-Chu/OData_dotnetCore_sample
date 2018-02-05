using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataTest.DbContext;
using ODataTest.Models;

namespace ODataTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]


  public class PersonController : ODataController
    {
      private readonly SampleODataDbContext _appDbContext;

      public PersonController(SampleODataDbContext sampleODataDbContext)
      {
        _appDbContext = sampleODataDbContext;
      }
    // GET: api/Person
      [EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
    [HttpGet]
        public ICollection<Person> Get()
        {
          var person = new List<Person>()
          {
                  new Person()
                  {
                          Name = "John",
                          Age = 22,
                          Id = 0,
                  },
                  new Person()
                  {
                          Name = "Tom", 
                          Age = 32,
                          Id = 1
                  }
          };
          return person;
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Person
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        

    }
}
