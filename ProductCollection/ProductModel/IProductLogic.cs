namespace ProductCollection.ProductModel;

public interface IProductLogic
{
    void AddProduct(Product product);
    List<Product> GetAllProducts();
    List<string> GetOnlyInStockProducts();
    List<Product> GetOutOfStockProducts();
    Product GetDogLeashByName(string name);
    Product GetCatFoodByName(string name);
}
