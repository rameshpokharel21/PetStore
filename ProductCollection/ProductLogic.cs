namespace ProductCollection;

internal class ProductLogic : IProductLogic
{
    private List<Product> _products;
    private Dictionary<string, DogLeash> _dogLeash;
    private Dictionary<string, CatFood> _catFood;

    public ProductLogic()
    {
        _products = new List<Product>();
        _dogLeash = new Dictionary<string, DogLeash>();
        _catFood = new Dictionary<string, CatFood>();

        _products.Add(new DogLeash("amazon leash", 23.33m, 2, "Strong and reliable", 48, "Leather"));
        _products.Add(new CatFood("freshy fish", 35.50m, 3, "healthy for cat", 2.5, true));
        _products.Add(new DogLeash("homeMade leash", 0m, 0, "local product", 60, "Plastic"));
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);

        if(product is DogLeash)
        {
            _dogLeash.Add(key: product.Name, value: (DogLeash) product);
        }

        if (product is CatFood)
        {
            _catFood.Add(key: product.Name, value:( CatFood) product);
        }
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    //if key is not found, null is returned
    public DogLeash GetDogLeashByName(string name)
    {   try{
            
            return _dogLeash[name];           
        }
        catch(Exception)
        {
            return null;
        }
 
    }

    //if key is not found, null is returned
    public CatFood GetCatFoodByName(string name)
    {
        try
        {            
            return _catFood[name];         
        }
        catch (Exception)
        {  
            return null;
        }
        
    }

    public List<string> GetOnlyInStockProducts()
    {
        return _products
            .Where(product => product.Quantity > 0)
            .Select(product => product.Name)
            .ToList();
            
    }
}
