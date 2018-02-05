using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ODataTest.Models;

namespace ODataTest.DbContext
{
    public class SampleODataDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
      public SampleODataDbContext(DbContextOptions options): base(options)
      {
        
      }

      public SampleODataDbContext()
      {
        
      }

      public DbSet<Person> Persons { get; set; }
    }
}
