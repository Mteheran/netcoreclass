using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DBContext;
using Microsoft.EntityFrameworkCore;

namespace api.tests
{
    public static class StoreContextInitializer
    {
        public static StoreContext GetContext()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                            .UseInMemoryDatabase(databaseName: "StoreInMemory")
                            .Options;

            var context = new StoreContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
        
    }
}