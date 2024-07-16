using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF
{
    public class MyStoreContextFactory : IDesignTimeDbContextFactory<MyStoreDBContext>
    {
        public MyStoreDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var connectionString = configuration.GetConnectionString("MyStore");
            var optionsBuilder = new DbContextOptionsBuilder<MyStoreDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MyStoreDBContext(optionsBuilder.Options);
        }
    }
}
