

using SQLitePCL;

namespace PetStore.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public void AddDogLeash()
    {
       
    }
}
