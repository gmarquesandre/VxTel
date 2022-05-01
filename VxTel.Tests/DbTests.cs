using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VxTel.Api;

namespace VxTel.Tests
{
    public class DbTests
    {

        public async Task<VxTelDbContext> CreateTestDbAsync()
        {
            var options = new DbContextOptionsBuilder<VxTelDbContext>()
               .UseInMemoryDatabase("VxTelDbContext")
               .Options;

            var context = new VxTelDbContext(options);

            await context.Database.EnsureCreatedAsync();

            return context;
        }

        public async Task DeleteTestDbAsync(VxTelDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
        }
    }
}