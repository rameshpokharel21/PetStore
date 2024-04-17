using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCollection
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        List<string> GetOnlyInStockProducts();
    }
}
