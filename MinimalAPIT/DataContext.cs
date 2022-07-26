global using Microsoft.EntityFrameworkCore;
namespace MinimalAPIT
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AllOrder> allOrders => Set<AllOrder>();
    }
}
