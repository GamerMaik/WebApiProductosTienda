using Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
