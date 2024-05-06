using ProductCollection.ProductModel;

namespace ProductCollection.Logic;

public class ProductLogic : IProductLogic
{
    private List<Product> _products;
    private Dictionary<string, DogLeash> _dogLeash;
    private Dictionary<string, CatFood> _catFood;
    // private Dictionary<string, T> _product;

    public ProductLogic()
    {
        _products = new List<Product>();
        _dogLeash = new Dictionary<string, DogLeash>();
        _catFood = new Dictionary<string, CatFood>();
        //_product = new Dictionary<string, T>();


        AddProduct(new DogLeash("amazon leash", 23.33m, 2, "Strong and reliable", 48, "Leather"));
        AddProduct(new CatFood("freshy fish", 35.50m, 3, "healthy for cat", 2.5, true));
        AddProduct(new DogLeash("homeMade leash", 10.50m, 0, "local product", 60, "Plastic"));
    }

    public void AddProduct(Product product)
    {


        if (product is DogLeash && !_dogLeash.ContainsKey(product.Name) && !_catFood.ContainsKey(product.Name))
        {
            _dogLeash.Add(key: product.Name.ToLower(), value: (DogLeash)product);
        }

        else if (product is CatFood && !_catFood.ContainsKey(product.Name) && !_dogLeash.ContainsKey(product.Name))
        {
            _catFood.Add(product.Name.ToLower(), (CatFood)product);
        }
        else
        {
            throw new ArgumentException("\nProduct not added: Duplicate Key.");
        }
        _products.Add(product);

    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }



    public T? GetProductByName<T>(string name) where T : Product

    {
        try
        {
            name = name.ToLower();
            if (typeof(T) == typeof(DogLeash))
            {
                return _dogLeash[name] as T;
            }
            else if (typeof(T) == typeof(CatFood))
            {
                return _catFood[name] as T;
            }
            else
            {
                throw new ArgumentException($"{name} is not a product.");
            }
        }
        catch (Exception ex)
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

    public List<Product> GetOutOfStockProducts()
    {
        return _products
            .Where(product => product.Quantity == 0)
            .ToList();
    }
}
