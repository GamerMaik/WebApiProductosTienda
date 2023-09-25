using System;
using System.Collections.Generic;
using Models;
using DAL.Interfaces;
using LN.Interfaces;

namespace LN.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product AddProduct(Product product)
        {
            // Realiza la lógica de negocio antes de agregar el producto, si es necesario.
            // Por ejemplo, puedes validar los datos, verificar duplicados, etc.
            if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0 || product.StockQuantity < 0)
            {
                // Puedes lanzar una excepción o manejar la validación de acuerdo a tus requisitos.
                throw new ArgumentException("Los datos del producto son inválidos.");
            }

            // Llama al método AddProduct del repositorio para agregar el producto a la base de datos
            var addedProduct = _productRepository.AddProduct(product);

            // Realiza más operaciones si es necesario después de agregar el producto
            // Por ejemplo, realizar registro de auditoría, notificar eventos, etc.
            // Puedes agregar esta lógica aquí.

            return addedProduct;
        }

        public bool UpdateProduct(Product product)
        {
            // Llama al método de la DAL para actualizar el producto en la base de datos
            bool updatedProduct = _productRepository.UpdateProduct(product);

            if (updatedProduct)
            {
                // La actualización se realizó con éxito
                // Aquí puedes implementar lógica de negocios adicional si es necesario

                // Por ejemplo, podrías registrar un evento de auditoría
                // Log.Audit($"Se actualizó el producto con ID {product.Id}");

                // O notificar a otros sistemas o usuarios
                // NotificationService.NotifyUser(product.Id, "Se actualizó la información del producto");

                // También puedes devolver algún valor o indicador adicional si es necesario
            }
            else
            {
                // La actualización falló o el producto no existe en la base de datos
                // Aquí también puedes implementar lógica de negocios si es necesario

                // Por ejemplo, podrías registrar un error
                // Log.Error($"No se pudo actualizar el producto con ID {product.Id}");

                // O notificar a otros sistemas o usuarios sobre el error
                // NotificationService.NotifyAdmin("Error al actualizar producto", "No se pudo actualizar la información del producto");

                // También puedes devolver algún valor o indicador adicional si es necesario
            }

            // Devuelve el resultado de la actualización
            return updatedProduct;
        }

        public bool DeleteProduct(int id)
        {
            // Validación de producto existente en la DAL
            return _productRepository.DeleteProduct(id);
        }
    }
}
