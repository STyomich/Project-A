using Infrastructure.DbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace API.Tests.Integration
{
    public class ProgramWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(temp => temp.ServiceType == typeof(DbContextOptions<DataContext>));
                if(descriptor !=null) services.Remove(descriptor);
                services.AddDbContext<DataContext>(Options=>{
                    Options.UseInMemoryDatabase("DatabaseForTesting");
                });
            });
        }
    }
}