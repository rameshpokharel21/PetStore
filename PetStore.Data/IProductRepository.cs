namespace PetStore.Data;

public interface IProductRepository
{

    public void AddProduct(Product product);
    public Product GetProductById(int id);
    public IEnumerable<Product> GetAll();
    public void DeleteProductById(int id);
}