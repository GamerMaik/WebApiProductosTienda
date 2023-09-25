using System;
using ENTIDADES;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SWLNPersona
    {
        // Método para agregar un producto a la base de datos.
        public void Adicionar_EProducto(EProduct eProduct)
        {
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    context.Product.Add(eProduct);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar cambios en la base de datos");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // Método para eliminar un producto por su ID.
        public void Eliminar_Producto(int productId)
        {
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    var productToDelete = context.Product.Find(productId);

                    if (productToDelete != null)
                    {
                        context.Product.Remove(productToDelete);
                        context.SaveChanges();
                        Console.WriteLine("Producto eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el producto con el ID especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el producto de la base de datos.");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // Método para actualizar un producto por su ID con nuevos datos.
        public void Actualizar_Producto(int productId, EProduct newProductData)
        {
            try
            {
                // Crea un contexto de base de datos utilizando Entity Framework Core.
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    // Busca el producto en la base de datos por su ID.
                    var productToUpdate = context.Product.Find(productId);

                    if (productToUpdate != null)
                    {
                        // Actualiza los campos del producto con los nuevos datos proporcionados.
                        productToUpdate.Name = newProductData.Name;
                        productToUpdate.Description = newProductData.Description;
                        productToUpdate.Price = newProductData.Price;
                        productToUpdate.StockQuantity = newProductData.StockQuantity;
                        // Puedes agregar más campos aquí según tu modelo de datos.

                        // Guarda los cambios en la base de datos.
                        context.SaveChanges();
                        Console.WriteLine("Producto actualizado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el producto con el ID especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Captura y maneja cualquier excepción que pueda ocurrir durante la actualización.
                Console.WriteLine("Error al actualizar el producto en la base de datos.");
                Console.WriteLine(ex.ToString());
                throw; // Relanza la excepción para su manejo por código externo si es necesario.
            }
        }
    }
}
