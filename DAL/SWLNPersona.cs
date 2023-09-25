using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SWLNPersona
    {      
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

        public void Actualizar_Producto(int productId, EProduct newProductData)
        {
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    var productToUpdate = context.Product.Find(productId);

                    if (productToUpdate != null)
                    {
                        // Actualiza los campos del producto con los nuevos datos.
                        productToUpdate.Name = newProductData.Name;
                        productToUpdate.Description = newProductData.Description;
                        productToUpdate.Price = newProductData.Price;
                        productToUpdate.StockQuantity = newProductData.StockQuantity;
                        // Agrega otros campos aquí según tu modelo.

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
                Console.WriteLine("Error al actualizar el producto en la base de datos.");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
