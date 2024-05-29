using PetStore.Data;

namespace ProductCollection.Logic;

public class ProductLogic : IProductLogic
{
    
    private readonly IProductRepository _repository;
   

    public ProductLogic(IProductRepository repository)
    {
     
        _repository = repository;

       

/*
        AddProduct(new DogLeash("amazon leash", 23.33m, 2, "Strong and reliable", 48, "Leather"));
        AddProduct(new CatFood("freshy fish", 35.50m, 3, "healthy for cat", 2.5, true));
        AddProduct(new DogLeash("homeMade leash", 10.50m, 0, "local product", 60, "Plastic"));
    */
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
