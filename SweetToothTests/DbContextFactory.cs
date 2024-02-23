using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
namespace SweetToothTests
    
{
    public class DbContextFactory
    {
        
    public SweetToothDbContext CreateDbContext(string databaseName)
    {
        var options = new DbContextOptionsBuilder<SweetToothDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
        .Options;

        var dbContext = new SweetToothDbContext(options);
        return dbContext;
    }

}

   
}

