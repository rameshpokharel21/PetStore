using ProductCollection.ProductModel;

namespace ProductCollection.Logic;

public interface IProductLogic
{
    void AddProduct(Product product);
    List<Product> GetAllProducts();
    List<string> GetOnlyInStockProducts();
    List<Product> GetOutOfStockProducts();
    public T? GetProductByName<T>(string name) where T : Product;


}
