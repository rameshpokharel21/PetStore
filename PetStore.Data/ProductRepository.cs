

using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Collections.Immutable;

namespace PetStore.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

   /* public void AddProducts()
    {
        Console.WriteLine("Inserting a new Product");
      
        _context.Products.Add(new ProductEntity(
        
            name: "fresh meat", price: 12.50M, quantity: 1, description: "good for dog and cat"
        ));

        _context.Products.Add(new ProductEntity(

           name: "dog leash", price: 12.20M, quantity: 1, description: "a strong leash"
       ));


        _context.SaveChanges();
    }*/

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public Product GetProductById(int id)
    {
       
        var productResult =  _context.Products.Where(product => product.ProductId == id).FirstOrDefault();
        if(productResult == null)
        {
            throw new ArgumentNullException("Product Not Found!");
        }
        return productResult;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToImmutableList();
    }

    public async void DeleteProductById(int id)
    {
     await   _context
            .Products
            .Where(product => product.ProductId == id)
            .ExecuteDeleteAsync();
        _context.SaveChanges();
    }
}
