using System;
using System.Collections.Generic;
using Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException($"No se encontró un producto con el ID {id}");
                // También puedes devolver null o un valor predeterminado en lugar de lanzar una excepción,
                // dependiendo de cómo desees manejar esta situación.
            }

            return product;
        }

        public Product AddProduct(Product product)
        {
            // Llama al método Add del contexto para agregar el producto a la base de datos
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var existingProduct = _context.Products.Find(product.Id);

            if (existingProduct == null)
            {
                return false; // El producto no existe en la base de datos
            }

            // Actualiza las propiedades del producto existente
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            _context.Products.Update(existingProduct);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var existingProduct = _context.Products.Find(id);

            if (existingProduct == null)
            {
                return false; // El producto no existe en la base de datos
            }

            _context.Products.Remove(existingProduct);
            _context.SaveChanges();

            return true;
        }
    }
}
