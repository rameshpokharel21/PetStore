namespace ProductCollection;

internal class ProductLogic
{
    private List<Product> _products;
    private Dictionary<string, DogLeash> _dogLeash;
    private Dictionary<string, CatFood> _catFood;

    public ProductLogic()
    {
        _products = new List<Product>();
        _dogLeash = new Dictionary<string, DogLeash>();
        _catFood = new Dictionary<string, CatFood>();
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
}
