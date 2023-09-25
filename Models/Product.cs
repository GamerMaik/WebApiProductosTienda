using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }             // Identificador único del producto
        
        [Required]
        public string Name { get; set; }        // Nombre del producto
        
        public string Description { get; set; } // Descripción del producto
        
        [Required]
        public decimal Price { get; set; }      // Precio del producto

        [Required]
        public int StockQuantity { get; set; }  // Cantidad en stock del producto
    }
}
