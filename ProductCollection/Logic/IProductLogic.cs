using PetStore.Data;

namespace ProductCollection.Logic;

public interface IProductLogic
{
    void AddProduct(Product product);
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    void DeleteAProductById(int id);

}
