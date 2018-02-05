using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODataTest.Models;
//using ODataTest.DbContext;
using Product = ODataTest.Models.Product;

namespace ODataTest
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddDbContext<SampleODataDbContext>(options =>
      //{
      //  options.UseInMemoryDatabase("InMemoryDb");
      //});

      services.AddMvc();
      services.AddOData();

      // Workaround: https://github.com/OData/WebApi/issues/1177
      //services.AddMvcCore(options =>
      //{
      //  foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
      //  {
      //    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
      //  }
      //  foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
      //  {
      //    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
      //  }
      //});

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      var builder = new ODataConventionModelBuilder(app.ApplicationServices);
      builder.EntitySet<Product>("Products");

      builder.EntitySet<Product>("products");
      //builder.EntitySet<ProductDetail>("Detail");
      builder.ComplexType<ProductCategory>();

      // Convert all query data to lower case
      builder.EnableLowerCamelCase(); // with this option, "Products({Id})/Detail" must change to "Products({Id})/detail"

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      
      //app.UseMvc();
      app.UseMvc(routeBuilder =>
      {
        // Enable query operators in the routing
        routeBuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
        // Odata Route: ~/odata/~
        routeBuilder.MapODataServiceRoute("OData", "odata", builder.GetEdmModel());
        // Workaround: https://github.com/OData/WebApi/issues/1175
        routeBuilder.EnableDependencyInjection();
      });

    }
  }
}
