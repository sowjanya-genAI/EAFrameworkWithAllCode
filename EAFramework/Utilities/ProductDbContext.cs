using Microsoft.EntityFrameworkCore;

namespace EAFramework.Utilities;

public interface IProductDbContext
{
    DbSet<DbHelperForSqlite.Product> Products { get; set; }
}

public class ProductDbContext : DbContext, IProductDbContext
{
    public DbSet<DbHelperForSqlite.Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\karthik\\source\\EAFrameworkWithAllCode\\ProductAPI\\Product.db");
    }
}