using Microsoft.EntityFrameworkCore;
using Bibliotheque.Models;
using Bibliotheque.Tools;

namespace Bibliotheque.Test
{
    public class DataBaseTests
    {
        [Fact]
        public void DBConnectionTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliothequeContext>();
            optionsBuilder.UseSqlServer(ConnectionTools.getConnectionString());

            using var context = new BibliothequeContext(optionsBuilder.Options);
            Assert.True(context.Database.CanConnect());
        }
    }
}