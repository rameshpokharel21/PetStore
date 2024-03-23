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
            _dogLeash.Add(key: product.Name, value: product as DogLeash);
        }

        if (product is CatFood)
        {
            _catFood.Add(key: product.Name, value: product as CatFood);
        }
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public DogLeash GetDogLeashByName(string name)
    {
        if(!_dogLeash.ContainsKey(name.ToLower()))
        {
            throw new ArgumentException($"Wrong name {name}");
        }
        return _dogLeash[name];
    }

    public CatFood GetCatFoodByName(string name)
    {
        if (!_catFood.ContainsKey(name.ToLower()))
        {
            throw new ArgumentException($"Wrong name {name}");
        }
        return _catFood[name];
    }
}
