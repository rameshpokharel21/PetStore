using PetStore.Data;

namespace ProductCollection.Logic;

public class ProductLogic : IProductLogic
{
    
    private readonly IProductRepository _repository;
   

    public ProductLogic(IProductRepository repository)
    {
     
        _repository = repository;

     
        }

    public void AddProduct(Product product)
    {
        if(product == null)
        {
            throw new ArgumentNullException("Product is Null");
        }
        _repository.AddProduct(product);

    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public Product GetProductById(int id)

    {
        return _repository.GetProductById(id);
           
    }

    public void DeleteAProductById(int id)
    {
        _repository.DeleteProductById(id);
    }

}
