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

    //if key is not found, null is thrown
    //that should be caught inside main program
    public DogLeash GetDogLeashByName(string name)
    {
        if (_dogLeash.ContainsKey(name))
        {
            return _dogLeash[name];
            //throw new ArgumentException($"No dog leash with name: {name}");
        }
        return null;

    }

    //if key is not found, null is thrown
    //should be caught in main program
    public CatFood GetCatFoodByName(string name)
    {
        if (_catFood.ContainsKey(name))
        {
            return _catFood[name];
            //throw new ArgumentException($"No cat food with name: {name}");
        }
        return null;
    }
}
