using System;
using ENTIDADES;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SWLNPersona
    {
        // Método para agregar un nuevo producto a la base de datos
        public void Adicionar_EProducto(EProduct eProduct)
        {
            try
            {
                // Crear un contexto de base de datos
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    // Agregar el nuevo producto al conjunto de entidades
                    context.Product.Add(eProduct);

                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine("Error al guardar cambios en la base de datos");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // Método para eliminar un producto de la base de datos por su ID
        public void Eliminar_Producto(int productId)
        {
            try
            {
                // Crear un contexto de base de datos
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    // Buscar el producto por su ID
                    var productToDelete = context.Product.Find(productId);

                    if (productToDelete != null)
                    {
                        // Si se encuentra el producto, eliminarlo de la base de datos
                        context.Product.Remove(productToDelete);

                        // Guardar los cambios en la base de datos
                        context.SaveChanges();
                        Console.WriteLine("Producto eliminado correctamente.");
                    }
                    else
                    {
                        // Si no se encuentra el producto, mostrar un mensaje
                        Console.WriteLine("No se encontró el producto con el ID especificado.");
                    }
                }
            }

            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine("Error al eliminar el producto de la base de datos.");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // Método para actualizar un producto en la base de datos por su ID
        public void Actualizar_Producto(int productId, EProduct newProductData)
        {
            try
            {
                // Crear un contexto de base de datos
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    // Buscar el producto por su ID
                    var productToUpdate = context.Product.Find(productId);

                    if (productToUpdate != null)
                    {
                        // Si se encuentra el producto, actualizar sus campos con los nuevos datos
                        productToUpdate.Name = newProductData.Name;
                        productToUpdate.Description = newProductData.Description;
                        productToUpdate.Price = newProductData.Price;
                        productToUpdate.StockQuantity = newProductData.StockQuantity;
                        // Agregar otras actualizaciones aquí según tu modelo de datos

                        // Guardar los cambios en la base de datos
                        context.SaveChanges();
                        Console.WriteLine("Producto actualizado correctamente.");
                    }
                    else
                    {
                        // Si no se encuentra el producto, mostrar un mensaje
                        Console.WriteLine("No se encontró el producto con el ID especificado.");
                    }
                }
            }

            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine("Error al actualizar el producto en la base de datos.");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

    }
}
