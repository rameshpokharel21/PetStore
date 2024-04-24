namespace ProductCollection
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        List<string> GetOnlyInStockProducts();
        List<Product> GetOutOfStockProducts();
    }
}
