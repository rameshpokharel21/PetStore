

using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace PetStore.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

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
        return _context.Products.ToList();
    }

    public void DeleteProductById(int id)
    {
        Product queryProduct = GetProductById(id);
        if (queryProduct != null)
        {
            _context
            .Products
            .Remove(queryProduct);
            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentNullException($"{nameof(id)} not found");
        }

    }

}
