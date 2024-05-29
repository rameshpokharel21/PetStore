
using Microsoft.EntityFrameworkCore;

namespace PetStore.Data;

public class ProductContext : DbContext
{
 
    public DbSet<Product> Products { get; set; }
  

    public string DbPath { get; }

    public ProductContext()
    {
        var folder = Environment.SpecialFolder.DesktopDirectory;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "product.db");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

}
