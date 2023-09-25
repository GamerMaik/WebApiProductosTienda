using Models;
using System.Collections.Generic;

namespace LN.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
